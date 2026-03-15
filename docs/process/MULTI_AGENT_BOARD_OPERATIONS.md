# Multi-Agent Board Operations - RunMate

## Objetivo

Transformar o `RunMate Delivery Board` em um board operacional real para um squad multi-agent, com dono claro, handoff previsivel e movimentacao consistente dos itens.

## Fonte oficial de operacao

Use sempre esta separacao:

- `GitHub Issues`: unidade de trabalho
- `GitHub Project`: estado atual da operacao
- `Repositorio`: contexto, processo, templates e regras

O board deve responder rapidamente:

- quem esta puxando o item
- em que estado ele esta
- qual risco principal existe
- qual agente recebe o proximo handoff

## Setup final do board

### Campos oficiais

Campos que devem continuar como padrao:

- `Status`
- `Priority`
- `Sprint`
- `Primary Agent`
- `Secondary Agent`
- `Area`
- `Estimate`
- `Risk`

### Views oficiais

O board deve operar com estas views:

1. `Sprint Board`
   Group by: `Status`
   Filter: `Sprint = Sprint 3`

2. `Sprint Table`
   Type: `Table`
   Filter: `Sprint = Sprint 3`

3. `Ready Queue`
   Type: `Table`
   Filter: `Status = Ready`

4. `Review and QA`
   Type: `Board`
   Filter: `Status = Review` or `QA`

5. `Blocked`
   Type: `Table`
   Filter: `Status = Blocked`

6. `Risk Review`
   Type: `Table`
   Filter: `Risk != None`

### Card layout

Deixar visivel no card:

- `Priority`
- `Sprint`
- `Primary Agent`
- `Area`
- `Risk`

Ocultar do card:

- `Secondary Agent`
- `Estimate`

## Regra de movimento do item

### Backlog

Usar quando:

- a issue existe, mas ainda nao esta pronta para entrar em execucao

Dono natural:

- `PO`

Proximo handoff:

- `Tech Lead`
- `UX/UI` quando houver tela ou fluxo novo

### Ready

Usar quando:

- criterio de aceite esta claro
- risco principal foi identificado
- area e agentes ja foram definidos

Dono natural:

- `PO`

Proximo handoff:

- `Primary Agent`

### In Progress

Usar quando:

- o agente principal assumiu a implementacao ou analise ativa do item

Dono natural:

- `Primary Agent`

Proximo handoff:

- `Secondary Agent` quando houver dependencia direta
- `PR Creator` quando houver PR aberta

### Review

Usar quando:

- existe PR aberta
- a implementacao principal terminou

Dono natural:

- `PR Creator`
- `Code Review`

Proximo handoff:

- `QA`

### QA

Usar quando:

- a entrega esta pronta para validacao funcional

Dono natural:

- `QA`

Proximo handoff:

- `PM` e `PO` para aceite funcional

### Done

Usar quando:

- PR mergeada
- validacao concluida
- sem bloqueio aberto relevante

Dono natural:

- `PM`
- `PO`

### Blocked

Usar quando:

- existe dependencia tecnica
- existe falta de definicao
- existe dependencia entre backend e flutter

Regra obrigatoria:

- atualizar `Risk` com `Dependency`, `Product Clarification` ou `Security`

## Regra de handoff por area

### Product

Fluxo:

`PM -> PO -> Tech Lead`

Entradas:

- objetivo
- valor
- prioridade

Saida esperada:

- issue clara e pronta para execucao

### Backend

Fluxo:

`Tech Lead -> Backend Dev -> Security -> PR Creator -> QA`

Quando usar:

- API
- regra de negocio
- persistencia
- auth

### Flutter

Fluxo:

`Tech Lead -> UX/UI -> Flutter Dev -> QA -> PR Creator`

Quando usar:

- tela
- navegacao
- estado de sessao
- integracao mobile

### Security

Fluxo:

entra por gatilho e devolve para:

- `Backend Dev`
- `Flutter Dev`
- `Tech Lead`

Quando chamar:

- token
- secret
- sessao
- storage
- autenticacao

### DevOps

Fluxo:

entra por gatilho e devolve para:

- `Tech Lead`
- `QA`

Quando chamar:

- CI/CD
- ambiente
- release
- automacao

## Regra de autonomia do time

O time multi-agent nao deve esperar comando humano em cada passo.

Cada agente se move com base nestes gatilhos:

- item em `Ready`: `Primary Agent` assume
- item em `In Progress` com dependencia clara: chamar `Secondary Agent`
- PR aberta: mover para `Review`
- review concluida: mover para `QA`
- bug ou dependencia real: mover para `Blocked` e atualizar `Risk`
- merge + validacao: mover para `Done`

## Ordem recomendada de execucao do Sprint 3

Para o board andar com menos bloqueio, usar esta sequencia:

1. `US-301`
   JWT real no backend

2. `US-302`
   cadastro real de usuario

3. `US-303`
   login real

4. `US-304`
   telas reais de login e cadastro

5. `US-305`
   integracao Flutter com API real

6. `US-306`
   persistencia de sessao

7. `US-307`
   navegacao protegida

## Dependencias operacionais do Sprint 3

- `US-305` depende de `US-301`, `US-302`, `US-303` e `US-304`
- `US-306` depende de `US-305`
- `US-307` depende de `US-306`

## Checklist de setup final

- [ ] validar que as 6 views oficiais existem
- [ ] deixar apenas os 5 campos principais visiveis no card
- [ ] revisar se todas as issues possuem `Primary Agent`
- [ ] revisar se todas as issues possuem `Secondary Agent`
- [ ] revisar se todas as issues possuem `Risk`
- [ ] confirmar que os itens do Sprint 3 estao em `Sprint = Sprint 3`
- [ ] usar `Status = Blocked` como unico estado de bloqueio
- [ ] mover por gatilho, nao por percepcao subjetiva

## Regra de ouro

Se um item esta parado e ninguem sabe quem age agora, o board esta incompleto.

Todo item precisa deixar claro:

- quem esta com a bola
- quem entra se travar
- qual e o proximo handoff
