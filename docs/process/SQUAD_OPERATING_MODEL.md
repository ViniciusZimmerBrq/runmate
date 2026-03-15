# Squad Operating Model - RunMate

## Objetivo

Definir como o squad do RunMate funciona como um time multi-agent real, com papéis claros, handoffs previsiveis, estados de trabalho e rituais operacionais.

## Quando usar este documento

Use este documento para alinhar:

- quem decide
- quem detalha
- quem implementa
- quem valida
- como um ciclo de trabalho nasce e termina

## Organograma do squad

### Core squad

Responsavel pela entrega do ciclo de trabalho.

- `PM`
- `PO`
- `Tech Lead`
- `Flutter Dev`
- `Backend Dev`
- `QA`

### Advisory squad

Entra por gatilho, risco ou necessidade da entrega.

- `UX/UI`
- `Security`
- `DevOps`
- `PR Creator`
- `Code Review`

## Modelo de responsabilidade

### PM

Responsavel por:

- visao do produto
- objetivo do ciclo
- prioridade macro
- decisao de escopo

Nao deve:

- detalhar implementacao tecnica
- escrever task tecnica no lugar do time

### PO

Responsavel por:

- backlog
- historias
- criterio de aceite
- definicao funcional de pronto

Nao deve:

- mandar historia ambigua para execucao

### UX/UI

Responsavel por:

- jornada
- fluxo
- estados da tela
- microcopy

Entra quando:

- existe tela nova
- existe mudanca de fluxo
- existe duvida de experiencia

### Tech Lead

Responsavel por:

- arquitetura
- contratos
- padroes
- trade-offs
- quebra tecnica da entrega

Nao deve:

- centralizar toda decisao sem handoff

### Flutter Dev

Responsavel por:

- interface
- navegacao
- integracao mobile
- sessao local
- estados da feature

### Backend Dev

Responsavel por:

- API
- regras de negocio
- autenticacao
- persistencia
- contratos do backend

### QA

Responsavel por:

- cenarios de teste
- validacao funcional
- regressao
- decisao de pronto funcional

### Security

Responsavel por:

- auth
- tokens
- secrets
- armazenamento seguro
- validacao de risco sensivel

Entra quando:

- mexe com login
- mexe com cadastro
- mexe com token
- mexe com segredo
- mexe com dado sensivel

### DevOps

Responsavel por:

- CI/CD
- automacao
- release
- ambiente
- observabilidade

### PR Creator

Responsavel por:

- abrir PR claro
- resumir escopo
- listar validacoes
- registrar riscos e follow-ups

### Code Review

Responsavel por:

- revisar bugs
- revisar regressao
- revisar seguranca
- revisar aderencia arquitetural

## Operating model

O squad opera em 3 niveis:

### Nivel 1 - Produto

Define o que vale a pena fazer.

Papéis:

- `PM`
- `PO`
- `UX/UI`

Saidas:

- objetivo
- problema
- usuario alvo
- backlog inicial

### Nivel 2 - Entrega

Define como construir com seguranca e clareza.

Papéis:

- `Tech Lead`
- `Flutter Dev`
- `Backend Dev`
- `Security`
- `QA`

Saidas:

- desenho tecnico
- fluxo de implementacao
- cenarios de validacao

### Nivel 3 - Governanca

Garante qualidade, rastreabilidade e fluidez.

Papéis:

- `QA`
- `Security`
- `PR Creator`
- `Code Review`
- `DevOps`

Saidas:

- PR claro
- validacao registrada
- pipeline confiavel
- risco documentado

## Estados oficiais do trabalho

O squad usa estes estados no `GitHub Project`:

- `Backlog`
- `Refinement`
- `Ready`
- `In Progress`
- `Review`
- `QA`
- `Done`
- `Blocked`

## Significado de cada estado

### Backlog

Item identificado, mas ainda sem detalhamento suficiente.

### Refinement

Item em clarificacao funcional e tecnica.

### Ready

Item apto a entrar no ciclo ou ser puxado para execucao.

### In Progress

Implementacao em andamento.

### Review

Implementacao concluida e em revisao tecnica.

### QA

Item em validacao funcional.

### Done

Entrega aceita e encerrada.

### Blocked

Item travado por dependencia, decisao ou risco.

## Regras de transicao

- `Backlog -> Refinement`: PO assume o item
- `Refinement -> Ready`: PO + Tech Lead consideram o item executavel
- `Ready -> In Progress`: agente responsavel puxa o item
- `In Progress -> Review`: existe PR ou entrega equivalente pronta para revisao
- `Review -> QA`: revisao tecnica concluida
- `QA -> Done`: cenarios aceitos
- qualquer estado -> `Blocked`: impedimento explicito

## Rituais oficiais do squad

### 1. Backlog Refinement

Objetivo:

deixar historias pequenas, claras e testaveis

Participantes:

- `PO`
- `Tech Lead`
- `QA`
- `Security` quando necessario

Saida:

- historias em `Ready`

### 2. Planning

Objetivo:

definir meta, capacidade e comprometimento

Participantes:

- `PM`
- `PO`
- `Tech Lead`
- `Flutter Dev`
- `Backend Dev`
- `QA`

Saida:

- meta do ciclo
- ordem de execucao
- riscos conhecidos

### 3. Daily Async

Objetivo:

dar visibilidade e destravar rapido

Formato:

- o que mudou ontem
- o que entra hoje
- o que esta bloqueando

### 4. Review

Objetivo:

validar se o ciclo entregou o resultado esperado

Participantes:

- `PM`
- `PO`
- `QA`
- `Tech Lead`

### 5. Retro

Objetivo:

melhorar a forma de trabalhar do squad

Saida:

- manter
- melhorar
- parar

## Definition of Ready

Uma historia so pode entrar em `Ready` se:

- [ ] problema estiver claro
- [ ] usuario estiver claro
- [ ] criterio de aceite estiver testavel
- [ ] fora de escopo estiver explicito
- [ ] risco principal estiver identificado
- [ ] ownership estiver definido

## Definition of Done

Uma historia so pode ir para `Done` se:

- [ ] entrega implementada
- [ ] revisao tecnica concluida
- [ ] QA concluido
- [ ] risco critico resolvido ou aceito
- [ ] docs relevantes atualizadas
- [ ] board refletindo o status real

## Gatilhos para chamar agentes advisory

- `UX/UI`: tela nova, fluxo novo, duvida de experiencia
- `Security`: auth, secrets, tokens, storage seguro
- `DevOps`: pipeline, release, ambiente, automacao
- `PR Creator`: abertura de PR relevante
- `Code Review`: PR pronto para revisao

## Ordem recomendada de atuacao

1. `PM` define objetivo
2. `PO` detalha backlog
3. `UX/UI` define fluxo quando necessario
4. `Tech Lead` faz leitura tecnica
5. `Security` entra se houver sensibilidade
6. `Flutter Dev` e `Backend Dev` implementam
7. `PR Creator` organiza a submissao
8. `Code Review` revisa
9. `QA` valida
10. `PO` e `PM` aceitam

## Artefatos deste pacote

- [Story Workflow](/Users/user/Desktop/CODE/Run/docs/process/STORY_WORKFLOW.md)
- [Agent Handoff Contract](/Users/user/Desktop/CODE/Run/docs/process/AGENT_HANDOFF_CONTRACT.md)
