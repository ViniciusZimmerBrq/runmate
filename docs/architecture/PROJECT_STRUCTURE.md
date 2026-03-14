# Estrutura do Projeto - RunMate

## Organizacao do workspace

```text
Run/
  agents/
  docs/
    architecture/
    context/
    sprints/
  runmate_app/
  runmate_backend/
```

## agents/

Guarda os prompts operacionais dos agentes, um arquivo por papel.

Sugestao:

```text
agents/
  PM_AGENT.md
  PO_AGENT.md
  UX_UI_AGENT.md
  TECH_LEAD_AGENT.md
  FLUTTER_DEV_AGENT.md
  BACKEND_CSHARP_AGENT.md
  QA_AGENT.md
  DEVOPS_AGENT.md
  SECURITY_AGENT.md
```

## docs/context/

Documentacao de contexto para todos os agentes:

- produto
- momento atual do projeto
- escopo da sprint
- definicoes importantes

## docs/architecture/

Documentacao tecnica persistente:

- estrutura do projeto
- estrategia de autenticacao
- contratos
- ADRs futuras

## docs/sprints/

Planejamento por sprint:

- objetivo
- historias
- criterios de aceite
- definicao de pronto
- riscos

## Estrutura recomendada do Flutter

```text
lib/
  app/
    runmate_app.dart
    theme/
    navigation/
  core/
    error/
    networking/
    storage/
    utils/
    widgets/
  features/
    auth/
      data/
        datasources/
        dtos/
        repositories/
      domain/
        entities/
        repositories/
        usecases/
      presentation/
        controllers/
        pages/
        widgets/
    dashboard/
    workouts/
```

Regras:

- `core/` e para codigo compartilhado
- cada `feature/` deve ser autocontida
- `presentation` nao conhece detalhes de transporte HTTP
- `data` implementa repositorios e traduz contratos
- `domain` contem regras de negocio e interfaces

## Estrutura recomendada do backend

```text
src/
  RunMate.Api/
    Endpoints/
    Middleware/
    Contracts/
    Configuration/
  RunMate.Application/
    Auth/
      Commands/
      Queries/
      Dtos/
      Validators/
      Interfaces/
  RunMate.Domain/
    Entities/
    ValueObjects/
    Services/
    Rules/
  RunMate.Infrastructure/
    Persistence/
    Security/
    Services/
```

Regras:

- `Api` recebe e devolve HTTP
- `Application` orquestra casos de uso
- `Domain` concentra o nucleo do negocio
- `Infrastructure` integra banco, hashing, JWT e servicos externos

## Convencoes de contexto

- toda sprint gera um documento em `docs/sprints/`
- toda decisao arquitetural importante pode virar um ADR
- agentes recebem sempre o contexto a partir de `docs/context/PROJECT_CONTEXT.md`
