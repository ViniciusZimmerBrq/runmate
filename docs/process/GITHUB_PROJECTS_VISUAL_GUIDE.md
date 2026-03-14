# GitHub Projects Visual Guide - RunMate

## Objetivo

Deixar o board do RunMate facil de ler, bonito o suficiente e pratico para operar.

## Diagnostico do board atual

Pontos bons:

- o fluxo principal ja existe
- as historias `US-301` a `US-307` ja estao no board
- os agentes principais e secundarios ja foram criados

Pontos a melhorar:

- `Yes/No` deixa o card visualmente fraco
- `Blocked` separado do status gera redundancia
- muitos pills podem poluir o card

## Modelo visual recomendado

### Colunas do board

- Backlog
- Ready
- In Progress
- Review
- QA
- Done
- Blocked

### Campos visiveis no card

Mostrar:

- Title
- Priority
- Sprint
- Primary Agent
- Area
- Risk

Ocultar no card:

- Secondary Agent
- Estimate

Esses podem continuar existindo, mas nao precisam ficar sempre visiveis.

## Campos recomendados

- `Status`
- `Priority`
- `Sprint`
- `Area`
- `Primary Agent`
- `Secondary Agent`
- `Estimate`
- `Risk`

## Campos que eu removeria

- `Blocked`
- `Security Impact`

Motivo:

- o primeiro ja e coberto por `Status = Blocked`
- o segundo fica melhor como `Risk = Security`

## Valores sugeridos

### Priority

- P1 High
- P2 Medium
- P3 Low

### Risk

- None
- Security
- Dependency
- Product Clarification

## Views recomendadas

### 1. Sprint Board

- tipo: Board
- group by: `Status`
- filtro: `Sprint = Sprint 3`

### 2. Sprint Table

- tipo: Table
- filtro: `Sprint = Sprint 3`

### 3. Ready Queue

- tipo: Table
- filtro: `Status = Ready`

### 4. Review and QA

- tipo: Board
- filtro: `Status = Review` ou `QA`

### 5. Blocked

- tipo: Table
- filtro: `Status = Blocked`

### 6. Risk Review

- tipo: Table
- filtro: `Risk != None`

## Regra visual pratica

Se um campo nao ajuda voce a decidir nada em poucos segundos, ele nao deve aparecer no card.

## Fluxo recomendado

### Produto pronto para entrar na sprint

- `Status = Ready`

### Dev comecou

- `Status = In Progress`

### PR aberto

- `Status = Review`

### Validacao

- `Status = QA`

### Concluido

- `Status = Done`

### Travado

- `Status = Blocked`
- `Risk = Dependency` ou `Product Clarification`

## O que eu mudaria agora no seu board

1. renomear prioridades para `P1 High`, `P2 Medium`, `P3 Low`
2. manter `Risk` como campo unico de alerta
3. parar de usar qualquer campo separado de bloqueio
4. criar a view `Ready Queue`
5. ocultar `Secondary Agent` e `Estimate` do card
