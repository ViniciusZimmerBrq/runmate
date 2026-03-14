# RunMate

RunMate e um projeto de estudo e execucao de um app de corrida com:

- `Flutter` no app mobile
- `ASP.NET Core` em `C#` no backend
- `GitHub Projects` para operacao Scrum
- um squad multi-agent para produto, design, engenharia, QA e governanca

## Estrutura principal

- [agents](/Users/user/Desktop/CODE/Run/agents)
- [docs](/Users/user/Desktop/CODE/Run/docs)
- [runmate_app](/Users/user/Desktop/CODE/Run/runmate_app)
- [runmate_backend](/Users/user/Desktop/CODE/Run/runmate_backend)

## Comece por aqui

### Time e processo

- [Agent Prompts](/Users/user/Desktop/CODE/Run/AGENT_PROMPTS_RUNMATE.md)
- [Squad Operating Model](/Users/user/Desktop/CODE/Run/docs/process/SQUAD_OPERATING_MODEL.md)
- [Story Workflow](/Users/user/Desktop/CODE/Run/docs/process/STORY_WORKFLOW.md)
- [GitHub Projects System](/Users/user/Desktop/CODE/Run/docs/process/GITHUB_PROJECTS_SYSTEM.md)

### Produto

- [Project Context](/Users/user/Desktop/CODE/Run/docs/context/PROJECT_CONTEXT.md)
- [Roadmap](/Users/user/Desktop/CODE/Run/docs/roadmap/ROADMAP_RUNMATE.md)

### Arquitetura

- [Project Structure](/Users/user/Desktop/CODE/Run/docs/architecture/PROJECT_STRUCTURE.md)
- [Secure Auth Architecture](/Users/user/Desktop/CODE/Run/docs/architecture/SECURE_AUTH_ARCHITECTURE.md)
- [Secrets and Env Setup](/Users/user/Desktop/CODE/Run/docs/architecture/SECRETS_AND_ENV_SETUP.md)

## Estado atual

O projeto esta estruturado para seguir um fluxo com historias no GitHub, board em GitHub Projects e handoff entre agentes por papel.

O board e as issues no GitHub sao a fonte oficial da execucao. O repositorio guarda contexto, processo, templates e regras operacionais do squad.

## Operacao via terminal

Use o hub de terminal para visualizar board, fila de tarefas e handoff entre agents:

```bash
bash ./scripts/runmate-ops summary
bash ./scripts/runmate-ops ready
bash ./scripts/runmate-ops next
bash ./scripts/runmate-ops show 2
bash ./scripts/runmate-ops team
bash ./scripts/runmate-ops timeline 2
bash ./scripts/runmate-ops run 2
bash ./scripts/runmate-ops approve 2
```

O hub tambem mantém um estado local por issue em `.runmate/ops-state.json`, liberando os agents em ordem:

- Product: `PM -> PO -> Tech Lead`
- Flutter: `PM -> PO -> Tech Lead -> UX/UI -> Flutter Dev -> QA -> PR Creator`
- Backend: `PM -> PO -> Tech Lead -> Backend Dev -> Security -> QA -> PR Creator`
