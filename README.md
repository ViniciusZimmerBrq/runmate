# RunMate

App de corrida com Flutter mobile + ASP.NET Core backend, operado por um squad multi-agente Claude Code.

## Estrutura

```
Run/
  runmate_app/       # Flutter mobile (Dart, SDK ^3.7.2)
  runmate_backend/   # ASP.NET Core C# (RunMate.sln)
  .claude/agents/    # 10 subagentes Claude Code nativos
  .github/           # Workflows CI/CD + templates de issue e PR
  docs/              # Arquitetura, contexto, processo e roadmap
  Makefile           # Dev local em paralelo
  CLAUDE.md          # Guia para Claude Code
```

## Dev local

```bash
make dev          # backend :5000 + Flutter app em paralelo
make test         # todos os testes
```

Veja `CLAUDE.md` para comandos completos, arquitetura e guia de agentes em paralelo com worktrees.

## Documentação

| Categoria | Arquivo |
|-----------|---------|
| Contexto do produto | `docs/context/PROJECT_CONTEXT.md` |
| Roadmap | `docs/roadmap/ROADMAP_RUNMATE.md` |
| Estrutura do projeto | `docs/architecture/PROJECT_STRUCTURE.md` |
| Arquitetura de auth | `docs/architecture/SECURE_AUTH_ARCHITECTURE.md` |
| Secrets e env | `docs/architecture/SECRETS_AND_ENV_SETUP.md` |
| Story workflow | `docs/process/STORY_WORKFLOW.md` |
| Handoff de agentes | `docs/process/AGENT_HANDOFF_CONTRACT.md` |
| Git & GitHub flow | `docs/process/GIT_GITHUB_FLOW.md` |
| CI/CD | `docs/process/CI_CD_STRATEGY.md` |
| Squad operating model | `docs/process/SQUAD_OPERATING_MODEL.md` |
| GitHub Projects | `docs/process/GITHUB_PROJECTS_SYSTEM.md` |
