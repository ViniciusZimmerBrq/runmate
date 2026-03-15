# Template - Campos do GitHub Projects

## Estado atual do board

Project atual identificado:

- `RunMate Delivery Board`

Campos que ja existem no project:

- `Status`
- `Priority`
- `Sprint`
- `Primary Agent`
- `Secondary Agent`
- `Area`
- `Estimate`
- `Risk`

Itens ja presentes no board:

- `US-301`
- `US-302`
- `US-303`
- `US-304`
- `US-305`
- `US-306`
- `US-307`

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
| Sprint | Single select | ciclo atual de execucao |
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

## Configuracao operacional recomendada agora

### Views para criar ou validar

- `Sprint Board`
  Agrupar por `Status`
  Filtro: `Sprint = Sprint 3`

- `Sprint Table`
  Tipo `Table`
  Filtro: `Sprint = Sprint 3`

- `Ready Queue`
  Tipo `Table`
  Filtro: `Status = Ready`

- `Review and QA`
  Tipo `Board`
  Filtro: `Status = Review` ou `QA`

- `Blocked`
  Tipo `Table`
  Filtro: `Status = Blocked`

- `Risk Review`
  Tipo `Table`
  Filtro: `Risk != None`

### Campos visiveis no card

Deixar visivel:

- `Priority`
- `Sprint`
- `Primary Agent`
- `Area`
- `Risk`

Ocultar do card:

- `Secondary Agent`
- `Estimate`

## Checklist de operacao

- toda issue nova entra com `Priority`, `Area`, `Primary Agent` e `Sprint`
- issue pronta para ser puxada fica em `Status = Ready`
- quando alguem assumir, mover para `In Progress`
- PR aberta move o item para `Review`
- validacao funcional move para `QA`
- item travado vai para `Blocked`
- travou por dependencia ou definicao? atualizar `Risk`

## Regra pratica

Se algo estiver travado:

- mover para `Status = Blocked`
- usar `Risk = Dependency` ou `Product Clarification`

Se algo for sensivel:

- manter `Risk = Security`
