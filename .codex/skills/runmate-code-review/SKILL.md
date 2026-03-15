---
name: runmate-code-review
description: Code review guidance for RunMate. Use when the user asks for a review of code, diffs, PRs, or implementation changes and wants bugs, regressions, architecture violations, security issues, test gaps, or corrections to PR text and review artifacts prioritized.
---

# RunMate Code Review

Read these files first:
- `/Users/user/Desktop/CODE/Run/docs/context/PROJECT_CONTEXT.md`
- `/Users/user/Desktop/CODE/Run/docs/process/GIT_GITHUB_FLOW.md`
- `/Users/user/Desktop/CODE/Run/docs/architecture/PROJECT_STRUCTURE.md`
- `/Users/user/Desktop/CODE/Run/docs/architecture/SECURE_AUTH_ARCHITECTURE.md`
- `/Users/user/Desktop/CODE/Run/agents/CODE_REVIEW_AGENT.md`

## Workflow

1. Inspect the relevant diff or changed files.
2. Prioritize concrete findings: bugs, regressions, security issues, architecture violations, and missing tests.
3. If a PR description, title, or review summary is part of the artifact, review that text too.
4. Flag and fix PR communication errors when they exist:
   - title does not match the main change
   - summary overstates or understates the diff
   - validations are missing, inconsistent, or misleading
   - risks, rollout notes, or out-of-scope items are omitted
   - wording is vague enough to hurt review quality
5. Keep summaries brief and findings first.
6. If there are no findings, say that explicitly and mention residual risk.

## Guardrails

- Treat inaccurate PR text as a real review finding because it misleads reviewers.
- When possible, provide corrected wording, not only criticism.
- Never approve invented validation, hidden risk, or mismatched scope language.

## Output

Prefer this structure:
1. Findings em ordem de severidade
2. Perguntas abertas
3. Resumo curto do impacto
