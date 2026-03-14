# Sprint 1 - RunMate

## Objetivo da sprint

Entregar a primeira fatia funcional do MVP com:

- estrutura base do app Flutter
- estrutura base do backend em C#
- autenticacao inicial desenhada
- fluxo inicial de dashboard e treinos alinhado
- backlog pronto para implementacao da Sprint 2

## Resultado esperado

Ao fim da Sprint 1, o time deve ter:

- arquitetura inicial aprovada
- home inicial do app funcionando
- dominio principal mapeado
- contratos iniciais da API definidos
- historias refinadas e testaveis

## Historias da Sprint 1

### US-01 - Definir visao e escopo do MVP

User story:

Como time de produto, queremos definir o escopo do MVP para alinhar o que sera construido primeiro.

Criterios de aceite:

- proposta de valor do app esta documentada
- usuario principal esta definido
- lista de funcionalidades do MVP esta priorizada
- itens fora do MVP estao explicitados

Tarefas:

- PM definir proposta de valor
- PM definir usuario principal
- PM priorizar funcionalidades
- PM listar exclusoes do MVP

### US-02 - Detalhar backlog inicial do produto

User story:

Como time de desenvolvimento, queremos um backlog inicial claro para iniciar a implementacao com menos ambiguidade.

Criterios de aceite:

- backlog contem historias independentes e pequenas
- cada historia possui criterio de aceite testavel
- dependencias entre historias estao identificadas
- duvidas abertas estao registradas

Tarefas:

- PO quebrar epicos em historias
- PO escrever criterios de aceite
- PO mapear dependencias
- QA revisar testabilidade das historias

### US-03 - Definir arquitetura inicial do app e da API

User story:

Como time tecnico, queremos uma arquitetura inicial simples e consistente para desenvolver com seguranca.

Criterios de aceite:

- estrutura base do Flutter foi definida
- estrutura base do backend em C# foi definida
- contratos iniciais entre app e API foram documentados
- riscos tecnicos principais estao registrados

Tarefas:

- Tech Lead definir estrutura por camadas
- Tech Lead propor contratos principais
- Flutter Dev alinhar estrutura do app
- Backend Dev alinhar estrutura da API

### US-04 - Criar shell inicial do app Flutter

User story:

Como usuario, quero abrir o app e visualizar uma home inicial do produto para validar direcao e navegacao base.

Criterios de aceite:

- app abre com identidade inicial do RunMate
- tela inicial mostra resumo de progresso
- tela inicial mostra proximo treino
- tela inicial lista ultimos treinos de forma estatica
- codigo esta organizado em estrutura evolutiva

Tarefas:

- criar tema inicial
- criar widget principal do app
- criar dashboard inicial
- criar cards de resumo
- criar lista inicial de treinos
- criar teste de widget da home

### US-05 - Criar shell inicial do backend

User story:

Como time de desenvolvimento, queremos um backend estruturado para evoluir endpoints do MVP sem retrabalho grande.

Criterios de aceite:

- projeto contem camadas API, Application, Domain e Infrastructure
- entidades iniciais estao definidas
- DTOs iniciais estao definidos
- endpoint de healthcheck ou bootstrap esta previsto
- contratos iniciais de auth, workouts e dashboard existem

Tarefas:

- criar estrutura de pastas do backend
- modelar entidades iniciais
- criar DTOs de treino e resumo
- criar controller inicial
- preparar Program.cs com endpoints base

### US-06 - Validar qualidade inicial da base

User story:

Como time, queremos validacoes iniciais para garantir que a base nasce utilizavel.

Criterios de aceite:

- app Flutter analisa sem erros
- teste de widget principal passa
- riscos do backend manual foram documentados
- limitacoes atuais do ambiente estao registradas

Tarefas:

- rodar analyze do Flutter
- rodar test do Flutter
- revisar estrutura criada
- registrar limitacoes do ambiente

## Definicao de pronto da Sprint 1

- documentacao principal criada
- arquitetura inicial revisada
- app Flutter inicial funcional
- backend inicial estruturado
- backlog da proxima sprint preparado

## Fora do escopo da Sprint 1

- autenticacao completa funcionando
- persistencia real com banco de dados
- integracao real entre Flutter e API
- notificacoes
- dashboard com dados reais
- tracking por GPS

## Riscos conhecidos

- `dotnet` nao esta instalado no ambiente atual, entao o backend sera scaffold manual
- dependencias extras de Flutter nao foram adicionadas ainda
- contratos podem evoluir quando a Sprint 2 detalhar autenticacao e persistencia

## Entregas candidatas para Sprint 2

- tela de login e cadastro
- endpoint real de autenticacao
- cadastro de treino manual
- listagem real de treinos
- validacoes de formulario no app
