# RunMate Product Hub

## Visao

**Produto:** RunMate  
**Missao:** criar um app de corrida com foco em autenticacao robusta, boa arquitetura e evolucao fluida.  
**Fase atual:** Sprint 3 - Auth real ponta a ponta

## Objetivo atual

Entregar autenticacao real de ponta a ponta:

- cadastro real
- login real
- sessao persistida
- navegacao protegida

## Links principais

- Roadmap: [ROADMAP_RUNMATE.md](/Users/user/Desktop/CODE/Run/docs/roadmap/ROADMAP_RUNMATE.md)
- Sprint atual: [SPRINT_3_AUTH_IMPLEMENTATION.md](/Users/user/Desktop/CODE/Run/docs/sprints/SPRINT_3_AUTH_IMPLEMENTATION.md)
- Playbook do squad: [SQUAD_PLAYBOOK_RUNMATE.md](/Users/user/Desktop/CODE/Run/docs/process/SQUAD_PLAYBOOK_RUNMATE.md)
- Guia visual do GitHub Projects: [GITHUB_PROJECTS_VISUAL_GUIDE.md](/Users/user/Desktop/CODE/Run/docs/process/GITHUB_PROJECTS_VISUAL_GUIDE.md)
- Sistema de sprint no GitHub Projects: [GITHUB_PROJECTS_SYSTEM.md](/Users/user/Desktop/CODE/Run/docs/process/GITHUB_PROJECTS_SYSTEM.md)

## Dashboard da sprint

### Meta da sprint

Transformar a base atual em autenticacao funcional, segura e integrada.

### Entregas principais

- JWT real no backend
- cadastro real
- login real
- telas reais de auth
- integracao Flutter + API
- sessao persistida
- navegacao protegida

### Indicadores para acompanhar

- historias em `Ready`
- historias em `In Progress`
- historias em `Review`
- historias em `QA`
- historias bloqueadas
- PRs abertos
- CI verde ou vermelho

## Produto

### Roadmap atual

1. Auth real ponta a ponta
2. Sessao e navegacao protegida
3. Cadastro manual de treino
4. Historico real
5. Dashboard real

### Epics ativas

- Auth
- Platform Foundation

## Backlog pronto

### Ready agora

- US-301 - JWT real no backend
- US-302 - Cadastro real no backend
- US-303 - Login real no backend
- US-304 - Telas reais de login e cadastro
- US-305 - Integracao Flutter com API de auth
- US-306 - Persistir sessao no app
- US-307 - Navegacao protegida

## Qualidade e risco

### Itens com impacto de seguranca

- JWT e configuracao de secret
- hash de senha
- armazenamento local da sessao

### Riscos atuais

- divergencia entre validacao do Flutter e do backend
- acoplamento entre UI e transporte HTTP
- persistencia inicial do usuario no backend

## Ritual da sprint

### Refinamento

- revisar historias novas
- confirmar criterios de aceite
- mapear dependencias e riscos

### Daily

- o que foi feito
- o que entra hoje
- bloqueios

### Review

- validar o objetivo principal da sprint
- revisar PRs e entregas

### Retro

- o que funcionou
- o que travou
- o que mudar

## Estrutura recomendada no GitHub Projects

### Estruturas

- Project principal
- Issues
- PRs
- Docs do repo

### Views da pagina principal

- Sprint atual
- Board da sprint
- Itens bloqueados
- Review e QA
- Backlog Ready
- Stories com Security Impact
- Epics ativas

## Templates para uso

- Story template: [PO_USER_STORY_TEMPLATE.md](/Users/user/Desktop/CODE/Run/docs/templates/PO_USER_STORY_TEMPLATE.md)
- Sprint planning: [SPRINT_PLANNING_TEMPLATE.md](/Users/user/Desktop/CODE/Run/docs/templates/SPRINT_PLANNING_TEMPLATE.md)
- Cards da Sprint 3: [SPRINT_3_NOTION_CARDS.md](/Users/user/Desktop/CODE/Run/docs/templates/SPRINT_3_NOTION_CARDS.md)

## Decisao de ferramenta

Se voce quer operacao em tempo real e integracao nativa com PRs/issues, a melhor opcao gratuita para este projeto e `GitHub Projects`.

Motivos:

- ja esta no mesmo fluxo do codigo
- atualiza em tempo real com issues e PRs
- permite tabela, board e roadmap
- reduz friccao entre produto e desenvolvimento

## Proximo passo recomendado

Criar um board da Sprint 3 em `GitHub Projects` e usar apenas o repositorio como fonte de contexto e documentacao.
