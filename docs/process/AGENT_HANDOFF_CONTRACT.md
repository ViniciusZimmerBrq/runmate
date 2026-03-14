# Agent Handoff Contract - RunMate

## Objetivo

Definir o contrato de saida de cada agente para que o time multi-agent opere com handoffs claros, sem ambiguidade e sem conversas soltas demais.

## Regra principal

Todo agente deve entregar uma saida padronizada.

A saida precisa responder:

- o que entendeu
- o que decidiu
- o que esta faltando
- o que o proximo agente precisa fazer

## Estrutura padrao de saida

Todo agente deve responder com estes blocos:

### 1. Contexto

O que esta sendo resolvido e por que isso importa.

### 2. Decisao ou analise

Qual foi a leitura do agente e qual a recomendacao principal.

### 3. Artefato entregue

O que o agente produziu:

- historia
- fluxo
- contrato
- recomendacao
- checklist
- PR

### 4. Riscos e dependencias

O que pode travar, o que precisa de validacao, o que depende de outro papel.

### 5. Proximo handoff

Quem recebe agora e o que deve fazer.

## Contrato por agente

### PM

Deve entregar:

- objetivo da sprint
- problema a resolver
- valor esperado
- prioridade
- fora de escopo

Handoff normal:

- `PO`

### PO

Deve entregar:

- user story
- criterio de aceite
- regra de negocio
- fora de escopo
- duvidas abertas

Handoff normal:

- `UX/UI`
- `Tech Lead`

### UX/UI

Deve entregar:

- fluxo da jornada
- estados da tela
- comportamento esperado
- observacoes de UX

Handoff normal:

- `Tech Lead`
- `Flutter Dev`

### Tech Lead

Deve entregar:

- leitura tecnica
- recomendacao arquitetural
- impacto por camada
- tarefas tecnicas
- risco tecnico

Handoff normal:

- `Flutter Dev`
- `Backend Dev`
- `Security` quando necessario

### Flutter Dev

Deve entregar:

- implementacao da feature mobile
- observacoes tecnicas
- testes executados
- gaps conhecidos

Handoff normal:

- `PR Creator`
- `Code Review`
- `QA`

### Backend Dev

Deve entregar:

- implementacao da API
- contrato atualizado
- testes executados
- gaps conhecidos

Handoff normal:

- `PR Creator`
- `Code Review`
- `QA`

### QA

Deve entregar:

- cenarios validados
- resultado
- bugs encontrados
- recomendacao de aceite

Handoff normal:

- `PO`
- `PM`

### Security

Deve entregar:

- risco identificado
- impacto
- controle recomendado
- status de aprovacao

Handoff normal:

- `Tech Lead`
- `Backend Dev`
- `Flutter Dev`

### DevOps

Deve entregar:

- alteracao de pipeline ou ambiente
- impacto operacional
- como validar
- risco de release

Handoff normal:

- `Tech Lead`
- `QA`

### PR Creator

Deve entregar:

- titulo
- resumo
- escopo
- validacoes
- riscos

Handoff normal:

- `Code Review`

### Code Review

Deve entregar:

- findings
- gravidade
- risco de regressao
- status de aprovacao

Handoff normal:

- `Devs`
- `QA`

## Protocolo de conversa entre agents

O time nao deve operar com todos os agentes falando ao mesmo tempo.

Modelo correto:

### 1. Handoff sequencial

Cada agente recebe um contexto e devolve uma saida fechada para o proximo.

### 2. Um dono por etapa

Cada etapa do fluxo precisa de um `Primary Agent`.

### 3. Escalada por gatilho

Agentes advisory entram so quando ha sinal real:

- `UX/UI` por mudanca de fluxo
- `Security` por item sensivel
- `DevOps` por item operacional

### 4. Duvida aberta vira dependencia

Se a conversa terminar com pergunta critica em aberto, isso precisa virar:

- risco
- dependencia
- ou retorno ao estado anterior

## Templates de handoff

### Template curto

```text
Contexto:

Decisao:

Artefato entregue:

Riscos e dependencias:

Proximo handoff:
```

### Template para implementacao

```text
Contexto:

O que foi implementado:

Como validar:

Riscos remanescentes:

Proximo handoff:
```

### Template para review

```text
Escopo revisado:

Findings:

Risco:

Status:

Proximo handoff:
```

## Anti-patterns

Evitar:

- agente respondendo sem dono claro
- handoff sem saida objetiva
- criterio de aceite escondido em texto livre
- review sem risco explicito
- QA sem evidenciar o resultado

## Como usar junto com o board

Os campos do `GitHub Project` ajudam a mostrar o handoff:

- `Primary Agent`: quem puxa
- `Secondary Agent`: quem apoia
- `Area`: onde a entrega acontece
- `Risk`: o que merece atencao
- `Status`: em qual etapa do fluxo o item esta
