# RunMate Product Hub

## Visao

**Produto:** RunMate  
**Missao:** criar um app de corrida com foco em autenticacao robusta, boa arquitetura e evolucao fluida.  
**Fase atual:** execucao via GitHub Project + backlog em issues

## Objetivo atual

Avancar o produto com clareza entre contexto estavel no repositorio e execucao operacional no GitHub:

- backlog claro
- historias refinadas
- handoffs consistentes entre agentes
- execucao rastreavel no board

## Links principais

- Roadmap: [ROADMAP_RUNMATE.md](/Users/user/Desktop/CODE/Run/docs/roadmap/ROADMAP_RUNMATE.md)
- Sprint atual: GitHub Issues + GitHub Project
- Playbook do squad: [SQUAD_PLAYBOOK_RUNMATE.md](/Users/user/Desktop/CODE/Run/docs/process/SQUAD_PLAYBOOK_RUNMATE.md)
- Guia visual do GitHub Projects: [GITHUB_PROJECTS_VISUAL_GUIDE.md](/Users/user/Desktop/CODE/Run/docs/process/GITHUB_PROJECTS_VISUAL_GUIDE.md)
- Sistema de sprint no GitHub Projects: [GITHUB_PROJECTS_SYSTEM.md](/Users/user/Desktop/CODE/Run/docs/process/GITHUB_PROJECTS_SYSTEM.md)

## Dashboard operacional

### Meta atual

Executar o fluxo do squad sem duplicar operacao entre repo e GitHub Project.

### Entregas principais

- historias prontas para execucao
- dependencias visiveis no board
- criterios de aceite claros
- handoff registravel entre agentes

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

- puxar do GitHub Project
- priorizar por `Ready`, `Priority` e dependencias

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
- Sprint execution: [SPRINT_EXECUTION_TEMPLATE.md](/Users/user/Desktop/CODE/Run/docs/templates/SPRINT_EXECUTION_TEMPLATE.md)

## Decisao de ferramenta

Se voce quer operacao em tempo real e integracao nativa com PRs/issues, a melhor opcao gratuita para este projeto e `GitHub Projects`.

Motivos:

- ja esta no mesmo fluxo do codigo
- atualiza em tempo real com issues e PRs
- permite tabela, board e roadmap
- reduz friccao entre produto e desenvolvimento

## Proximo passo recomendado

Usar `GitHub Projects` e `Issues` como fonte oficial da sprint e manter o repositorio apenas como fonte de contexto, processo e templates.
