from __future__ import annotations

import argparse
import json
import os
import subprocess
import sys
from pathlib import Path


ROOT_DIR = Path(__file__).resolve().parents[1]
OWNER = os.getenv("RUNMATE_OWNER", "ViniciusZimmerBrq")
REPO = os.getenv("RUNMATE_REPO", "runmate")
PROJECT_NUMBER = os.getenv("RUNMATE_PROJECT_NUMBER", "2")
DEFAULT_MODEL = os.getenv("RUNMATE_SWARMS_MODEL", "gpt-4o-mini")
STATE_DIR = ROOT_DIR / ".runmate"
STATE_FILE = STATE_DIR / "ops-state.json"


AGENT_FILES = {
    "pm": ROOT_DIR / "agents" / "PM_AGENT.md",
    "po": ROOT_DIR / "agents" / "PO_AGENT.md",
    "uxui": ROOT_DIR / "agents" / "UX_UI_AGENT.md",
    "techlead": ROOT_DIR / "agents" / "TECH_LEAD_AGENT.md",
    "flutter": ROOT_DIR / "agents" / "FLUTTER_DEV_AGENT.md",
    "backend": ROOT_DIR / "agents" / "BACKEND_CSHARP_AGENT.md",
    "security": ROOT_DIR / "agents" / "SECURITY_AGENT.md",
    "qa": ROOT_DIR / "agents" / "QA_AGENT.md",
    "devops": ROOT_DIR / "agents" / "DEVOPS_AGENT.md",
    "prcreator": ROOT_DIR / "agents" / "PR_CREATOR_AGENT.md",
    "codereview": ROOT_DIR / "agents" / "CODE_REVIEW_AGENT.md",
}

AGENT_LABELS = {
    "pm": "PM",
    "po": "PO",
    "uxui": "UX/UI",
    "techlead": "Tech Lead",
    "flutter": "Flutter Dev",
    "backend": "Backend Dev",
    "security": "Security",
    "qa": "QA",
    "devops": "DevOps",
    "prcreator": "PR Creator",
    "codereview": "Code Review",
}

LABEL_TO_KEY = {value: key for key, value in AGENT_LABELS.items()}


def require_cmd(name: str) -> None:
    if not shutil_which(name):
        raise SystemExit(f"Missing required command: {name}")


def shutil_which(name: str) -> str | None:
    from shutil import which

    return which(name)


def print_header() -> None:
    print("\nRunMate Ops")
    print(f"Project: {OWNER}/{REPO} - board {PROJECT_NUMBER}\n")


def ensure_state_file() -> None:
    STATE_DIR.mkdir(parents=True, exist_ok=True)
    if not STATE_FILE.exists():
        STATE_FILE.write_text(json.dumps({"issues": {}}, indent=2) + "\n")


def load_state() -> dict:
    ensure_state_file()
    return json.loads(STATE_FILE.read_text())


def save_state(state: dict) -> None:
    ensure_state_file()
    STATE_FILE.write_text(json.dumps(state, indent=2) + "\n")


def gh_json(args: list[str]) -> dict:
    require_cmd("gh")
    proc = subprocess.run(
        ["gh", *args],
        cwd=ROOT_DIR,
        check=True,
        capture_output=True,
        text=True,
    )
    return json.loads(proc.stdout)


def fetch_items() -> dict:
    return gh_json(
        [
            "project",
            "item-list",
            PROJECT_NUMBER,
            "--owner",
            OWNER,
            "--format",
            "json",
            "--limit",
            "100",
        ]
    )


def get_items_for_sprint(sprint_name: str) -> list[dict]:
    items = fetch_items()["items"]
    selected = [item for item in items if item.get("sprint") == sprint_name]
    selected.sort(
        key=lambda item: (
            item.get("priority", ""),
            item.get("estimate", 0),
            item["content"]["number"],
        )
    )
    return selected


def get_issue(issue_number: int) -> dict:
    items = fetch_items()["items"]
    for item in items:
        if item.get("content", {}).get("number") == issue_number:
            return item
    raise SystemExit("Issue not found in project.")


def extract_prompt_block(agent_file: Path) -> str:
    lines = agent_file.read_text().splitlines()
    capture = False
    output: list[str] = []
    for line in lines:
        if line.strip() == "```text":
            capture = True
            continue
        if capture and line.strip() == "```":
            break
        if capture:
            output.append(line)
    return "\n".join(output).strip()


def normalize_agent_key(value: str) -> str:
    value = value.strip()
    lowered = value.lower()
    aliases = {
        "pm": "pm",
        "po": "po",
        "ux": "uxui",
        "uxui": "uxui",
        "ux/ui": "uxui",
        "tech": "techlead",
        "techlead": "techlead",
        "flutter": "flutter",
        "backend": "backend",
        "security": "security",
        "qa": "qa",
        "devops": "devops",
        "pr": "prcreator",
        "prcreator": "prcreator",
        "review": "codereview",
        "codereview": "codereview",
    }
    return aliases.get(lowered) or LABEL_TO_KEY.get(value, "")


def flow_for_issue(item: dict) -> list[str]:
    base = ["pm", "po", "techlead"]
    area = item.get("area")
    risk = item.get("risk")
    secondary = item.get("secondary Agent")
    if area == "Flutter":
        return base + ["uxui", "flutter", "qa", "prcreator"]
    if area == "Backend":
        flow = base + ["backend"]
        if risk == "Security" or secondary == "Security":
            flow.append("security")
        flow += ["qa", "prcreator"]
        return flow
    return base


def ensure_issue_state(issue_number: int, item: dict) -> dict:
    state = load_state()
    key = str(issue_number)
    if key not in state["issues"]:
        state["issues"][key] = {"flow": flow_for_issue(item), "completed": []}
        save_state(state)
    return state["issues"][key]


def current_stage(issue_number: int, item: dict) -> str:
    issue_state = ensure_issue_state(issue_number, item)
    idx = len(issue_state["completed"])
    return issue_state["flow"][idx] if idx < len(issue_state["flow"]) else ""


def next_stage(issue_number: int, item: dict) -> str:
    issue_state = ensure_issue_state(issue_number, item)
    idx = len(issue_state["completed"]) + 1
    return issue_state["flow"][idx] if idx < len(issue_state["flow"]) else ""


def approve_stage(issue_number: int, item: dict, agent_key: str | None = None) -> tuple[str, str]:
    state = load_state()
    issue_state = ensure_issue_state(issue_number, item)
    current = current_stage(issue_number, item)
    if not current:
        return "", ""
    if agent_key and agent_key != current:
        raise SystemExit(
            f"Blocked: current allowed agent is {AGENT_LABELS[current]}, not {agent_key}."
        )
    key = str(issue_number)
    state = load_state()
    state["issues"][key]["completed"].append(current)
    save_state(state)
    return current, next_stage(issue_number, item)


def timeline_lines(issue_number: int, item: dict) -> list[str]:
    issue_state = ensure_issue_state(issue_number, item)
    completed = len(issue_state["completed"])
    lines = []
    for idx, stage in enumerate(issue_state["flow"]):
        prefix = "[x]" if idx < completed else "[>]" if idx == completed else "[ ]"
        lines.append(f"- {prefix} {AGENT_LABELS[stage]}")
    return lines


def task_context(item: dict) -> str:
    return "\n".join(
        [
            f"- Issue title: {item['title']}",
            f"- Area: {item['area']}",
            f"- Status: {item['status']}",
            f"- Sprint: {item['sprint']}",
            f"- Priority: {item['priority']}",
            f"- Risk: {item['risk']}",
            f"- Primary agent: {item['primary Agent']}",
            f"- Secondary agent: {item['secondary Agent']}",
            "",
            "Use the GitHub issue body and acceptance criteria as the source of truth.",
        ]
    )


def handoff_flow(item: dict) -> str:
    area = item.get("area")
    if area == "Backend":
        return "PM -> PO -> Tech Lead -> Backend Dev -> Security -> QA -> PR Creator"
    if area == "Flutter":
        return "PM -> PO -> Tech Lead -> UX/UI -> Flutter Dev -> QA -> PR Creator"
    return "PM -> PO -> Tech Lead"


def build_agent_briefing(agent_key: str, item: dict) -> str:
    prompt = extract_prompt_block(AGENT_FILES[agent_key])
    return "\n".join(
        [
            "Agent briefing",
            "",
            f"Agent: {AGENT_LABELS[agent_key]}",
            f"Issue: #{item['content']['number']} {item['title']}",
            f"Status: {item['status']}",
            f"Sprint: {item['sprint']}",
            f"Priority: {item['priority']}",
            f"Area: {item['area']}",
            f"Primary agent: {item['primary Agent']}",
            f"Secondary agent: {item['secondary Agent']}",
            f"Risk: {item['risk']}",
            f"URL: {item['content']['url']}",
            "",
            f"Current process stage:\n- {AGENT_LABELS[agent_key]}",
            "",
            f"Suggested handoff:\n{handoff_flow(item)}",
            "",
            "Prompt:",
            "",
            prompt,
            "",
            "Task context:",
            "",
            task_context(item),
        ]
    )


def load_swarms() -> tuple[object, object]:
    try:
        from swarms import Agent, SequentialWorkflow
    except Exception as exc:  # pragma: no cover - runtime guidance
        raise SystemExit(
            "Swarms is not installed. Run `pip install swarms` or `python3 -m pip install swarms`."
        ) from exc
    return Agent, SequentialWorkflow


def build_swarms_agent(agent_key: str, item: dict):
    Agent, _ = load_swarms()
    system_prompt = extract_prompt_block(AGENT_FILES[agent_key])
    return Agent(
        agent_name=AGENT_LABELS[agent_key],
        system_prompt=system_prompt,
        model_name=DEFAULT_MODEL,
        max_loops=1,
    )


def build_task_prompt(item: dict) -> str:
    body = item["content"].get("body", "").strip()
    return "\n".join(
        [
            f"Issue #{item['content']['number']}: {item['title']}",
            "",
            f"Sprint: {item['sprint']}",
            f"Priority: {item['priority']}",
            f"Area: {item['area']}",
            f"Primary agent: {item['primary Agent']}",
            f"Secondary agent: {item['secondary Agent']}",
            f"Risk: {item['risk']}",
            "",
            "Issue body:",
            body,
        ]
    )


def run_single_stage(issue_number: int) -> None:
    item = get_issue(issue_number)
    stage = current_stage(issue_number, item)
    if not stage:
        print_header()
        print(f"Task #{issue_number} is already complete in the local process flow.")
        return

    print_header()
    print(build_agent_briefing(stage, item))
    print("\nSwarms output:\n")
    agent = build_swarms_agent(stage, item)
    result = agent.run(build_task_prompt(item))
    print(result)


def run_remaining_swarm(issue_number: int) -> None:
    item = get_issue(issue_number)
    issue_state = ensure_issue_state(issue_number, item)
    current = len(issue_state["completed"])
    remaining = issue_state["flow"][current:]
    if not remaining:
        print_header()
        print(f"Task #{issue_number} is already complete in the local process flow.")
        return

    Agent, SequentialWorkflow = load_swarms()
    agents = [
        Agent(
            agent_name=AGENT_LABELS[key],
            system_prompt=extract_prompt_block(AGENT_FILES[key]),
            model_name=DEFAULT_MODEL,
            max_loops=1,
        )
        for key in remaining
    ]

    workflow = SequentialWorkflow(
        agents=agents,
        team_awareness=True,
        multi_agent_collab_prompt=True,
    )

    print_header()
    print(f"Running Swarms sequential workflow for issue #{issue_number}")
    print("Flow:")
    print(" -> ".join(AGENT_LABELS[key] for key in remaining))
    print()
    result = workflow.run(build_task_prompt(item))
    print(result)


def sprint_start_report(sprint_name: str) -> str:
    items = get_items_for_sprint(sprint_name)
    if not items:
        return f"No tasks found for sprint {sprint_name}."

    lines = [
        f"Sprint start plan: {sprint_name}",
        "",
        f"Total tasks: {len(items)}",
        "",
        "Kickoff queue:",
    ]

    for item in items:
        issue_number = item["content"]["number"]
        ensure_issue_state(issue_number, item)
        current = current_stage(issue_number, item)
        lines.append(
            f"- #{issue_number} {item['title']}"
            f" | Area: {item['area']}"
            f" | Primary: {item['primary Agent']}"
            f" | Current stage: {AGENT_LABELS[current] if current else 'Complete'}"
        )

    lines.extend(
        [
            "",
            "Suggested sprint start order:",
            "- 1. PM and PO prepare the top Ready items",
            "- 2. Tech Lead reviews the first backend and flutter items",
            "- 3. Backend and Flutter lanes begin after Tech Lead handoff",
            "",
            "Suggested commands:",
        ]
    )

    for item in items[:3]:
        lines.append(f"- python3 -m runmate_ops_swarms.cli run {item['content']['number']}")

    return "\n".join(lines)


def cmd_summary(_: argparse.Namespace) -> None:
    items = fetch_items()["items"]
    print_header()
    statuses = ["Ready", "In Progress", "Review", "QA", "Blocked", "Done"]
    print(f"Planned sprints: {len({item.get('sprint') for item in items if item.get('sprint')})}")
    print(f"Total tasks: {len(items)}\n")
    print("Status:")
    for status in statuses:
        count = sum(1 for item in items if item.get("status") == status)
        print(f"- {status}: {count}")
    print(
        "\nCore flow:\n"
        "- Product: PM -> PO -> Tech Lead\n"
        "- Flutter: PM -> PO -> Tech Lead -> UX/UI -> Flutter Dev -> QA -> PR Creator\n"
        "- Backend: PM -> PO -> Tech Lead -> Backend Dev -> Security -> QA -> PR Creator"
    )


def cmd_ready(_: argparse.Namespace) -> None:
    items = [item for item in fetch_items()["items"] if item.get("status") == "Ready"]
    items.sort(key=lambda item: (item.get("priority", ""), item.get("estimate", 0), item["content"]["number"]))
    print_header()
    if not items:
        print("No tasks in Ready.")
        return
    for item in items:
        print(
            f"- #{item['content']['number']} [{item['priority']}] {item['title']}\n"
            f"  Sprint: {item['sprint']} | Area: {item['area']} | Owner: {item['primary Agent']} | "
            f"Support: {item['secondary Agent']} | Risk: {item['risk']}"
        )


def cmd_next(_: argparse.Namespace) -> None:
    items = [item for item in fetch_items()["items"] if item.get("status") == "Ready"]
    items.sort(key=lambda item: (item.get("priority", ""), item.get("estimate", 0), item["content"]["number"]))
    print_header()
    if not items:
        print("No task ready to pull.")
        return
    item = items[0]
    print(
        "Recommended next task:\n"
        f"- #{item['content']['number']} {item['title']}\n"
        f"- Priority: {item['priority']}\n"
        f"- Area: {item['area']}\n"
        f"- Primary agent: {item['primary Agent']}\n"
        f"- Secondary agent: {item['secondary Agent']}\n"
        f"- Risk: {item['risk']}\n"
        f"- Estimate: {item['estimate']}\n\n"
        "Required process:\n"
        f"{handoff_flow(item)}"
    )


def cmd_team(_: argparse.Namespace) -> None:
    print_header()
    print(
        "Multi-agent operating flow:\n\n"
        "- Product: PM -> PO -> Tech Lead\n"
        "- Backend: PM -> PO -> Tech Lead -> Backend Dev -> Security -> QA -> PR Creator\n"
        "- Flutter: PM -> PO -> Tech Lead -> UX/UI -> Flutter Dev -> QA -> PR Creator\n\n"
        "Movement rules:\n"
        "- run <id> only unlocks the next allowed agent\n"
        "- approve <id> closes the current stage and unlocks the next\n"
        "- swarm <id> runs the remaining allowed chain with Swarms SequentialWorkflow\n"
        "- timeline <id> shows the full process for a task\n"
        "- sprint-start <name> prepares the kickoff for a whole sprint"
    )


def cmd_show(args: argparse.Namespace) -> None:
    item = get_issue(args.issue)
    print_header()
    print(
        f"#{item['content']['number']} {item['title']}\n"
        f"- Status: {item['status']}\n"
        f"- Sprint: {item['sprint']}\n"
        f"- Priority: {item['priority']}\n"
        f"- Area: {item['area']}\n"
        f"- Primary agent: {item['primary Agent']}\n"
        f"- Secondary agent: {item['secondary Agent']}\n"
        f"- Risk: {item['risk']}\n"
        f"- Estimate: {item['estimate']}\n"
        f"- URL: {item['content']['url']}\n"
    )


def cmd_agents(_: argparse.Namespace) -> None:
    print_header()
    print(
        "Available agents:\n\n"
        "- pm\n- po\n- techlead\n- uxui\n- backend\n- flutter\n- security\n- qa\n- devops\n- prcreator\n- codereview\n\n"
        "Examples:\n"
        "- python3 -m runmate_ops_swarms.cli timeline 2\n"
        "- python3 -m runmate_ops_swarms.cli run 2\n"
        "- python3 -m runmate_ops_swarms.cli approve 2\n"
        "- python3 -m runmate_ops_swarms.cli swarm 2\n"
        "- python3 -m runmate_ops_swarms.cli sprint-start \"Sprint 3\""
    )


def cmd_timeline(args: argparse.Namespace) -> None:
    item = get_issue(args.issue)
    print_header()
    print(f"Timeline for #{args.issue} {item['title']}\n")
    for line in timeline_lines(args.issue, item):
        print(line)


def cmd_run(args: argparse.Namespace) -> None:
    run_single_stage(args.issue)


def cmd_swarm(args: argparse.Namespace) -> None:
    run_remaining_swarm(args.issue)


def cmd_approve(args: argparse.Namespace) -> None:
    item = get_issue(args.issue)
    key = normalize_agent_key(args.agent) if args.agent else None
    current, nxt = approve_stage(args.issue, item, key)
    print_header()
    if not current:
        print(f"Task #{args.issue} is already complete.")
        return
    print(f"Approved stage:\n- {AGENT_LABELS[current]}\n")
    if nxt:
        print(f"Next unlocked stage:\n- {AGENT_LABELS[nxt]}\n")
        print(f"Next command:\n- python3 -m runmate_ops_swarms.cli run {args.issue}")
    else:
        print(f"Process complete for issue #{args.issue}.")


def cmd_agent(args: argparse.Namespace) -> None:
    item = get_issue(args.issue)
    agent_key = normalize_agent_key(args.agent)
    if not agent_key:
        raise SystemExit(f"Unknown agent: {args.agent}")
    current = current_stage(args.issue, item)
    if current and current != agent_key:
        raise SystemExit(
            f"Blocked: current allowed agent is {AGENT_LABELS[current]}.\n"
            f"Use: python3 -m runmate_ops_swarms.cli timeline {args.issue}"
        )
    print_header()
    print(build_agent_briefing(agent_key, item))


def cmd_start(args: argparse.Namespace) -> None:
    item = get_issue(args.issue)
    current = current_stage(args.issue, item)
    print_header()
    print(
        "Start task\n\n"
        f"Issue:\n- #{item['content']['number']} {item['title']}\n\n"
        f"Execution lane:\n- Area: {item['area']}\n- Current allowed agent: {AGENT_LABELS[current]}\n"
        f"- Process: {handoff_flow(item)}\n\n"
        "Suggested commands:\n"
        f"- python3 -m runmate_ops_swarms.cli timeline {args.issue}\n"
        f"- python3 -m runmate_ops_swarms.cli run {args.issue}\n"
        f"- python3 -m runmate_ops_swarms.cli approve {args.issue}"
    )


def cmd_handoff(args: argparse.Namespace) -> None:
    item = get_issue(args.issue)
    current = current_stage(args.issue, item)
    nxt = next_stage(args.issue, item)
    print_header()
    print(
        "Handoff plan\n\n"
        f"Issue:\n- #{item['content']['number']} {item['title']}\n\n"
        f"Current stage:\n- {AGENT_LABELS[current] if current else 'Complete'}\n"
    )
    if nxt:
        print(f"\nNext stage after approval:\n- {AGENT_LABELS[nxt]}")
    elif current:
        print("\nNo further stages after the current one.")
    else:
        print("\nNo further stages. Task flow is complete.")


def cmd_reset(args: argparse.Namespace) -> None:
    state = load_state()
    state["issues"].pop(str(args.issue), None)
    save_state(state)
    print_header()
    print(f"Reset local process state for issue #{args.issue}.")


def cmd_sprint_start(args: argparse.Namespace) -> None:
    print_header()
    print(sprint_start_report(args.sprint))


def build_parser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(prog="runmate-ops")
    sub = parser.add_subparsers(dest="command", required=True)

    sub.add_parser("summary").set_defaults(func=cmd_summary)
    sub.add_parser("ready").set_defaults(func=cmd_ready)
    sub.add_parser("next").set_defaults(func=cmd_next)
    sub.add_parser("team").set_defaults(func=cmd_team)
    sub.add_parser("agents").set_defaults(func=cmd_agents)

    p = sub.add_parser("sprint-start")
    p.add_argument("sprint")
    p.set_defaults(func=cmd_sprint_start)

    for name, func in {
        "show": cmd_show,
        "timeline": cmd_timeline,
        "run": cmd_run,
        "swarm": cmd_swarm,
        "start": cmd_start,
        "handoff": cmd_handoff,
        "reset": cmd_reset,
    }.items():
        p = sub.add_parser(name)
        p.add_argument("issue", type=int)
        p.set_defaults(func=func)

    p = sub.add_parser("approve")
    p.add_argument("issue", type=int)
    p.add_argument("agent", nargs="?")
    p.set_defaults(func=cmd_approve)

    p = sub.add_parser("agent")
    p.add_argument("agent")
    p.add_argument("issue", type=int)
    p.set_defaults(func=cmd_agent)
    return parser


def main(argv: list[str] | None = None) -> int:
    parser = build_parser()
    args = parser.parse_args(argv)
    args.func(args)
    return 0


if __name__ == "__main__":
    raise SystemExit(main())
