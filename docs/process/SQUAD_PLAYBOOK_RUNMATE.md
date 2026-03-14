# Squad Playbook - RunMate

## Objetivo

Definir como o squad do RunMate trabalha no dia a dia, da descoberta ate a entrega, com papéis claros, rituais, handoffs e forma de operar no GitHub Projects.

## Leitura recomendada

Para operar o time multi-agent com mais clareza, use este playbook junto com:

- [Squad Operating Model](/Users/user/Desktop/CODE/Run/docs/process/SQUAD_OPERATING_MODEL.md)
- [Story Workflow](/Users/user/Desktop/CODE/Run/docs/process/STORY_WORKFLOW.md)
- [Agent Handoff Contract](/Users/user/Desktop/CODE/Run/docs/process/AGENT_HANDOFF_CONTRACT.md)

## Visao do squad

O RunMate funciona como um squad enxuto com apoio de agentes especializados.

Papéis principais:

- PM
- PO
- UX/UI
- Tech Lead
- Flutter Dev
- Backend C# Dev
- QA
- Security
- DevOps
- PR Creator
- Code Review

## Principios de operacao

- uma sprint deve ter foco claro
- historias pequenas vencem historias grandes
- definicao de pronto importa mais que volume
- seguranca entra no desenho, nao no fim
- backlog deve reduzir ambiguidade
- handoff entre papéis deve deixar rastro claro

## Ciclo de trabalho do squad

### 1. Descoberta

Responsaveis:

- PM
- PO
- UX/UI
- Tech Lead

Saidas esperadas:

- problema claro
- usuario alvo claro
- proposta de entrega
- escopo inicial
- riscos principais

Artefatos:

- roadmap
- epic
- notas de descoberta

## 2. Refinamento

Responsaveis:

- PO
- Tech Lead
- QA
- Security

Saidas esperadas:

- historias refinadas
- criterios de aceite testaveis
- dependencias mapeadas
- riscos registrados

Artefatos:

- user stories
- checklist de refinamento
- notas tecnicas

## 3. Sprint Planning

Responsaveis:

- PM
- PO
- Tech Lead
- Devs
- QA

Saidas esperadas:

- meta da sprint
- historias comprometidas
- ordem de execucao
- definicao de pronto

Artefatos:

- documento da sprint
- board da sprint no GitHub Projects

## 4. Implementacao

Responsaveis:

- Flutter Dev
- Backend Dev
- Tech Lead
- Security

Saidas esperadas:

- codigo implementado
- PRs pequenos
- testes e validacoes basicas

Artefatos:

- branches
- pull requests
- notas de implementacao

## 5. Review e QA

Responsaveis:

- Code Review
- QA
- Security

Saidas esperadas:

- findings resolvidos
- regressao controlada
- aprovacao funcional

Artefatos:

- comentarios de review
- cenarios de teste
- status da historia

## 6. Review da sprint

Responsaveis:

- PM
- PO
- QA
- Tech Lead

Saidas esperadas:

- validacao do objetivo da sprint
- status das historias
- riscos remanescentes

## 7. Retrospectiva

Responsaveis:

- todo o squad

Saidas esperadas:

- o que funcionou
- o que travou
- o que mudar

## Responsabilidades por papel

### PM

Responsavel por:

- visao do produto
- foco da sprint
- prioridades
- cortes de escopo

Nao deve:

- detalhar implementacao tecnica

### PO

Responsavel por:

- backlog
- historias
- criterios de aceite
- definicao de pronto funcional

Nao deve:

- deixar historia ambigua entrar na sprint

### UX/UI

Responsavel por:

- fluxos
- hierarquia de informacao
- estados de tela
- microcopy

### Tech Lead

Responsavel por:

- arquitetura
- contratos
- padroes
- trade-offs

### Flutter Dev

Responsavel por:

- UI
- estado
- integracao mobile
- sessao local

### Backend Dev

Responsavel por:

- API
- regras de negocio
- autenticacao
- persistencia

### QA

Responsavel por:

- cenarios
- cobertura funcional
- regressao
- qualidade perceptivel

### Security

Responsavel por:

- revisar auth
- secrets
- tokens
- armazenamento seguro

### DevOps

Responsavel por:

- CI/CD
- ambiente
- pipeline
- release

### PR Creator

Responsavel por:

- preparar PR claro
- listar escopo
- listar validacoes
- listar riscos

### Code Review

Responsavel por:

- revisar bugs
- revisar regressao
- revisar arquitetura
- revisar seguranca

## Handoffs do squad

### PM -> PO

Entregar:

- objetivo
- prioridade
- escopo
- fora de escopo

### PO -> UX/UI

Entregar:

- historia refinada
- contexto do usuario
- criterio de aceite

### PO + UX/UI -> Tech Lead

Entregar:

- fluxo
- estados
- regras
- dependencias

### Tech Lead -> Devs

Entregar:

- estrutura
- contratos
- padroes
- recomendacao tecnica

### Devs -> QA

Entregar:

- PR
- fluxo implementado
- riscos conhecidos
- como validar

### QA -> PM/PO

Entregar:

- status funcional
- bugs
- impacto
- recomendacao de aceite

## Rituais

### Refinamento semanal

Objetivo:

deixar backlog pronto para a proxima sprint

Entrada:

- roadmap
- historias candidatas

Saida:

- historias Ready

### Planning

Objetivo:

fechar escopo e meta da sprint

Entrada:

- historias Ready
- capacidade do time

Saida:

- sprint comprometida

### Daily

Objetivo:

acompanhar progresso e bloqueios

Formato:

- o que foi feito
- o que vem agora
- o que bloqueia

### Review

Objetivo:

validar entrega contra o objetivo da sprint

### Retro

Objetivo:

melhorar o processo do squad

## Definition of Ready do squad

Uma historia so entra na sprint se:

- [ ] objetivo estiver claro
- [ ] criterio de aceite estiver testavel
- [ ] dependencias estiverem mapeadas
- [ ] risco principal estiver conhecido
- [ ] dono estiver definido

## Definition of Done do squad

Uma historia so sai como done se:

- [ ] codigo foi implementado
- [ ] PR foi revisado
- [ ] QA validou
- [ ] docs relevantes foram atualizadas
- [ ] riscos criticos foram resolvidos

## Regras para PR

- um PR por objetivo principal
- titulo semantico
- descricao com validacao e riscos
- CI verde
- sem segredo em codigo

## Como o squad opera no GitHub Projects

Estruturas principais:

- GitHub Project principal
- GitHub Issues
- Pull Requests
- Docs do repositorio

Views principais:

- Sprint atual
- Backlog pronto
- Itens bloqueados
- Historias com impacto de seguranca
- Review / QA

## Regras de status no GitHub Projects

### Story

- Backlog
- Refinement
- Ready
- In Progress
- Review
- QA
- Done
- Blocked

### Sprint

- Planned
- Active
- Closed

## Indicadores do squad

- historias prontas por sprint
- historias bloqueadas
- quantidade de bugs por sprint
- lead time de PR
- historias com impacto de seguranca

## Cadencia recomendada

- roadmap: quinzenal ou mensal
- refinamento: semanal
- planning: por sprint
- daily: diario
- review: fim da sprint
- retro: fim da sprint
