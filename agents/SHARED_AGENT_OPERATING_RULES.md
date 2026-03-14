# Shared Agent Operating Rules

## Objetivo

Definir as regras comuns que todos os agentes do RunMate devem seguir.

## Contexto base

- Produto: `RunMate`
- Dominio: app de corrida
- Frontend: `Flutter`
- Backend: `C# / ASP.NET Core`
- Gestao: `GitHub Projects`
- Modelo de time: squad multi-agent com handoff sequencial

## Fontes obrigatorias de contexto

Quando relevante, os agentes devem consultar:

- [Project Context](/Users/user/Desktop/CODE/Run/docs/context/PROJECT_CONTEXT.md)
- [Project Structure](/Users/user/Desktop/CODE/Run/docs/architecture/PROJECT_STRUCTURE.md)
- [Secure Auth Architecture](/Users/user/Desktop/CODE/Run/docs/architecture/SECURE_AUTH_ARCHITECTURE.md)
- [Roadmap](/Users/user/Desktop/CODE/Run/docs/roadmap/ROADMAP_RUNMATE.md)
- [Squad Operating Model](/Users/user/Desktop/CODE/Run/docs/process/SQUAD_OPERATING_MODEL.md)
- [Story Workflow](/Users/user/Desktop/CODE/Run/docs/process/STORY_WORKFLOW.md)
- [Agent Handoff Contract](/Users/user/Desktop/CODE/Run/docs/process/AGENT_HANDOFF_CONTRACT.md)

## Regras comuns

- trabalhe com foco em MVP e evolucao gradual
- nao invente requisito sem sinalizar suposicao
- explicite trade-offs quando houver mais de um caminho valido
- prefira clareza operacional a resposta generica
- respeite o fluxo do squad e o handoff entre papeis
- entregue uma saida que o proximo agente consiga usar

## Formato padrao de resposta

Todo agente deve responder com:

1. `Contexto`
2. `Decisao ou entrega`
3. `Riscos e dependencias`
4. `Proximo handoff`

## Gatilhos de escalada

- chamar `UX/UI` quando houver mudanca de fluxo
- chamar `Security` quando houver auth, token, segredo ou dado sensivel
- chamar `Tech Lead` quando houver impacto arquitetural
- chamar `QA` quando a entrega estiver pronta para validacao
- chamar `PR Creator` e `Code Review` na fase de review

## Anti-patterns

Evitar:

- resposta vaga
- backlog ambiguo
- recomendacao sem dono
- solucao excessivamente sofisticada
- handoff sem proximo passo claro
