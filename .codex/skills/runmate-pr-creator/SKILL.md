---
name: runmate-pr-creator
description: Draft RunMate pull requests from implemented changes. Use when the user asks for a PR title, PR description, merge-ready summary, validation notes, scope clarification, risk callouts, review handoff, or help packaging a RunMate diff into a clear pull request.
---

# RunMate PR Creator

Read these files first:
- `/Users/user/Desktop/CODE/Run/docs/context/PROJECT_CONTEXT.md`
- `/Users/user/Desktop/CODE/Run/docs/process/GIT_GITHUB_FLOW.md`
- `/Users/user/Desktop/CODE/Run/docs/process/CI_CD_STRATEGY.md`
- `/Users/user/Desktop/CODE/Run/agents/PR_CREATOR_AGENT.md`

Read these files only when relevant:
- `/Users/user/Desktop/CODE/Run/docs/architecture/PROJECT_STRUCTURE.md` for architecture-sensitive changes
- `/Users/user/Desktop/CODE/Run/docs/architecture/SECURE_AUTH_ARCHITECTURE.md` for auth, token, role, or security-impacting changes

## Workflow

1. Inspect the actual change first: diff, changed files, tests, commands run, and any linked ticket or task.
2. Infer the user-facing or developer-facing problem solved. Describe impact, not a file inventory.
3. Write one focused semantic PR title aligned to the main objective.
4. State scope clearly:
   - what changed
   - what intentionally stayed out
   - any migration, rollout, or follow-up needed
5. Record validation truthfully:
   - tests or checks that ran
   - checks not run
   - manual validation when present
6. Call out risks explicitly, especially architecture, auth, data, CI/CD, and regression risk.
7. Add review guidance so the next reviewer knows where to focus.
8. Reference the issue, branch, or release context when available.
9. Review the final PR text before delivering it and fix any error in:
   - semantic title
   - mismatch between summary and actual diff
   - invented or inconsistent validation
   - missing scope, risk, or review handoff
   - ambiguous, generic, or grammatically broken wording

## Guardrails

- Keep the PR centered on one primary objective.
- Prefer concrete outcomes over generic phrases like "adjustments" or "improvements".
- Never invent validations, approvals, linked issues, or rollout steps.
- If context is missing, say what is assumed and keep the wording conditional.
- Highlight security-sensitive impact whenever auth, tokens, roles, secrets, API boundaries, or critical config changed.
- Mention unfinished edges or known gaps instead of hiding them.
- If the PR text has errors, rewrite it instead of only pointing them out.
- Treat PR text quality as part of the deliverable, not as an optional polish pass.

## Output

Prefer this structure in Portuguese unless the user asks otherwise:

1. `Titulo do PR`
2. `Contexto`
3. `Entrega`
4. `Escopo fora`
5. `Validacoes`
6. `Riscos e pontos de atencao`
7. `Proximo handoff`

Use this compact template when the user wants ready-to-paste output:

```md
Titulo do PR
<tipo>: <objetivo principal>

Contexto
- <problema e impacto>

Entrega
- <mudanca principal>
- <mudanca complementar>

Escopo fora
- <o que nao entrou, se aplicavel>

Validacoes
- <comando, teste, ou validacao manual>
- <pendencia nao validada, se houver>

Riscos e pontos de atencao
- <risco tecnico, funcional, seguranca, ou rollout>

Proximo handoff
- <onde o reviewer deve focar>
- <follow-up opcional>
```
