# GitHub Projects System - RunMate

## Objetivo

Definir como o RunMate opera usando apenas `GitHub Projects`, com um fluxo simples, visualmente claro e bom para scrum.

## Principio principal

O board nao deve parecer um formulario.

Ele deve responder rapidamente:

- o que esta pronto
- o que esta em execucao
- o que esta travado
- quem esta puxando cada item
- qual item merece mais atencao

## Estrutura recomendada

### GitHub Issues

Guardam:

- historias
- bugs
- tasks tecnicas
- spikes

### GitHub Projects

Guarda:

- sprint atual
- board da execucao
- ownership
- prioridade
- risco

### Docs do repo

Guardam:

- contexto
- roadmap
- sprint docs
- playbooks

## Modelo recomendado de campos

- `Status`
- `Priority`
- `Sprint`
- `Area`
- `Primary Agent`
- `Secondary Agent`
- `Estimate`
- `Risk`

## Modelo recomendado de status

- Backlog
- Ready
- In Progress
- Review
- QA
- Done
- Blocked

## O que evitar

- campos binarios redundantes
- `Yes/No` para tudo
- muitos campos visiveis ao mesmo tempo
- `Blocked` separado de `Status = Blocked`

## Regras de operacao

### Quando criar uma issue

preencher:

- Priority
- Area
- Primary Agent
- Sprint

### Quando a issue entrar na sprint

- `Status = Ready`

### Quando alguem comecar

- `Status = In Progress`

### Quando abrir PR

- `Status = Review`

### Quando for para validacao

- `Status = QA`

### Quando concluir

- `Status = Done`

### Quando travar

- `Status = Blocked`
- `Risk = Dependency` ou `Product Clarification`

## Views recomendadas

### Sprint Board

- tipo: Board
- agrupamento: `Status`
- filtro: `Sprint = Sprint 3`

### Sprint Table

- tipo: Table
- filtro: `Sprint = Sprint 3`

### Review and QA

- tipo: Board
- filtro: `Status = Review` ou `QA`

### Blocked

- tipo: Table
- filtro: `Status = Blocked`

### Risk Review

- tipo: Table
- filtro: `Risk != None`

### Backlog Ready

- tipo: Table
- filtro: `Status = Ready`

## Ritual do squad

### Refinamento

- PO deixa a issue clara
- Tech Lead revisa impacto
- QA revisa testabilidade
- Security revisa itens sensiveis

### Planning

- puxar itens `Ready`
- marcar `Sprint`
- revisar prioridade e ordem

### Daily

- atualizar `Status`
- destacar itens em `Blocked`
- destravar dependencies

### Review

- olhar `Done`
- revisar PRs merged

### Retro

- converter aprendizados em novas issues

## Regra de ouro

Se o board estiver “muito cinza”, normalmente o problema e:

- campo demais
- semantica fraca
- excesso de `Yes/No`

A solucao e:

- menos campos
- nomes mais claros
- risco consolidado em um unico campo
