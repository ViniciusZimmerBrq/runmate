# Template - Campos do GitHub Projects

## Revisao do modelo

O board deve ser simples de ler e rapido de operar.

Recomendacao:

- evitar campos binarios visuais demais como `Yes/No` quando o proprio fluxo ja comunica isso
- evitar redundancia entre `Blocked` e `Status = Blocked`
- usar nomes curtos e fortes nos selects para ficar menos cinza e mais facil de bater o olho

## Campos recomendados

| Field | Type | Purpose |
|---|---|---|
| Status | Single select | estado atual do item |
| Priority | Single select | prioridade do trabalho |
| Sprint | Single select | sprint associada |
| Area | Single select | area principal |
| Primary Agent | Single select | dono principal |
| Secondary Agent | Single select | agente de apoio |
| Estimate | Number | esforco |
| Risk | Single select | risco principal |

## Campos que eu removeria

- `Blocked`
  Motivo: o proprio `Status = Blocked` ja cobre isso

- `Security Impact`
  Motivo: `Yes/No` fica visualmente fraco e cinza; melhor consolidar em `Risk`

- `QA Ready`
  Motivo: o fluxo `Review -> QA -> Done` ja comunica isso com mais clareza

## Valores recomendados

### Status

- Backlog
- Ready
- In Progress
- Review
- QA
- Done
- Blocked

### Priority

- P1 High
- P2 Medium
- P3 Low

### Sprint

- Backlog
- Sprint 3
- Sprint 4

### Area

- Backend
- Flutter
- Product
- QA
- Security
- Platform

### Primary Agent

- PM
- PO
- UX/UI
- Tech Lead
- Flutter Dev
- Backend Dev
- QA
- Security
- DevOps

### Secondary Agent

- PM
- PO
- UX/UI
- Tech Lead
- Flutter Dev
- Backend Dev
- QA
- Security
- DevOps

### Risk

- None
- Security
- Dependency
- Product Clarification

## Visual recomendado

Para o board ficar mais legivel:

- mostrar `Priority`
- mostrar `Sprint`
- mostrar `Primary Agent`
- mostrar `Area`
- mostrar `Risk`

Evitar mostrar campos demais no card.

## Regra pratica

Se algo estiver travado:

- mover para `Status = Blocked`
- usar `Risk = Dependency` ou `Product Clarification`

Se algo for sensivel:

- manter `Risk = Security`
