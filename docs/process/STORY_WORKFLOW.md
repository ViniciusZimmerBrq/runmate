# Story Workflow - RunMate

## Objetivo

Definir o caminho oficial de uma historia desde `Backlog` ate `Done`, com quem entra em cada etapa e o que precisa ser entregue em cada handoff.

## Fluxo oficial

1. `Backlog`
2. `Refinement`
3. `Ready`
4. `In Progress`
5. `Review`
6. `QA`
7. `Done`

Se houver travamento:

- `Blocked`

## Etapa por etapa

### 1. Backlog

Responsavel principal:

- `PO`

Objetivo:

registrar a oportunidade, problema ou demanda

Entrada minima:

- titulo
- contexto resumido
- area

Saida esperada:

- issue criada
- prioridade inicial
- dono de refinamento

Nao deve acontecer aqui:

- task tecnica detalhada
- criterio de aceite mal escrito como adivinhacao

### 2. Refinement

Responsaveis:

- `PO`
- `Tech Lead`
- `QA`
- `Security` quando necessario
- `UX/UI` quando houver impacto de fluxo

Objetivo:

transformar demanda em trabalho executavel

Checklist:

- user story clara
- problema claro
- criterio de aceite testavel
- fora de escopo claro
- risco principal marcado
- dependencia identificada
- ownership definido

Saida esperada:

- issue pronta para entrar em `Ready`

### 3. Ready

Responsavel principal:

- `PO`

Objetivo:

deixar o item apto para ser puxado pelo time na sprint

Condicoes obrigatorias:

- criterio de aceite validado
- abordagem tecnica minimamente alinhada
- risco principal mapeado
- prioridade e sprint preenchidas

Saida esperada:

- item elegivel para implementacao

### 4. In Progress

Responsavel principal:

- `Primary Agent`

Apoio:

- `Secondary Agent`

Objetivo:

tirar o item do papel e implementar a entrega

Regras:

- um item em progresso precisa ter dono claro
- duvida de produto volta para `PO`
- duvida de UX chama `UX/UI`
- duvida de arquitetura chama `Tech Lead`
- risco sensivel chama `Security`

Saida esperada:

- implementacao concluida
- testes locais feitos
- observacoes registradas

### 5. Review

Responsaveis:

- `Code Review`
- `Tech Lead` quando necessario
- `Security` em itens sensiveis

Objetivo:

validar qualidade tecnica antes do aceite funcional

Entrada obrigatoria:

- PR ou diff revisavel
- descricao clara do que mudou
- validacoes executadas
- riscos conhecidos

Saida esperada:

- findings resolvidos
- aprovacao tecnica

### 6. QA

Responsavel principal:

- `QA`

Apoio:

- `PO`
- `Flutter Dev`
- `Backend Dev`

Objetivo:

validar comportamento real contra criterio de aceite

Checklist:

- fluxo principal
- edge cases previstos
- regressao basica
- mensagens e estado de erro

Saida esperada:

- aceite funcional
- bug aberto
- ou retorno para `In Progress`

### 7. Done

Responsaveis:

- `PO`
- `PM` quando o item impacta meta da sprint

Objetivo:

encerrar o item com rastreabilidade

Condicoes:

- criterio de aceite atendido
- board atualizado
- docs relevantes atualizadas

## Estado especial - Blocked

Use `Blocked` quando houver:

- dependencia externa
- clarificacao de produto pendente
- risco tecnico impeditivo
- ambiente indisponivel

Regras:

- todo `Blocked` precisa ter motivo escrito
- todo `Blocked` precisa ter proximo dono do destravamento

## Handoffs oficiais

### PM -> PO

Entregar:

- objetivo
- resultado esperado
- prioridade
- restricoes

### PO -> UX/UI

Entregar:

- historia
- persona ou contexto
- criterio de aceite

### PO + UX/UI -> Tech Lead

Entregar:

- fluxo
- estados
- regras
- duvidas abertas

### Tech Lead -> Devs

Entregar:

- recomendacao tecnica
- impacto nas camadas
- contrato
- riscos

### Devs -> Review

Entregar:

- PR
- checklist executado
- observacoes de implementacao
- pontos de atencao

### Review -> QA

Entregar:

- status da revisao
- riscos remanescentes
- como validar

### QA -> PO/PM

Entregar:

- resultado da validacao
- bugs encontrados
- recomendacao de aceite

## Regras de fluxo

- o board deve refletir a realidade do trabalho
- uma historia nao pula `Refinement`
- uma historia nao entra em `Done` sem passar por `QA`
- o squad deve preferir historias pequenas e completas
- trabalho parcialmente pronto nao vale como concluido

## Como o board deve ser lido

Se o board estiver saudavel, ele responde rapido:

- o que esta pronto para puxar
- quem esta executando
- o que depende de decisao
- o que esta em revisao
- o que esta pronto para demonstrar
