# Time de Agentes - App Flutter de Corrida

## Objetivo

Montar um time de agentes para desenvolver um app de corrida com:

- App mobile em `Flutter`
- Backend em `C#` com `ASP.NET Core`
- Estrutura de produto, design, desenvolvimento e testes
- Organização parecida com um squad real
- Fluxo de trabalho multi-agent para estudo e execução

## Produto Base

Nome provisório: `RunMate`

Proposta:

Um app para corredores acompanharem treinos, evolução, metas, histórico, desafios e planos de corrida.

## Stack Sugerida

- Frontend mobile: `Flutter`
- Backend: `ASP.NET Core Web API`
- Banco de dados: `PostgreSQL`
- Autenticação: `JWT`
- Documentação da API: `Swagger / OpenAPI`
- Infra local: `Docker Compose`
- Observabilidade: `Serilog` + logs centralizados
- Estado no Flutter: `Riverpod`
- Navegação: `go_router`
- Arquitetura mobile: feature-first + camadas

## Time de Agentes

### 1. PM Agent

Missão:
Definir visão do produto, roadmap, releases e prioridades macro.

Responsabilidades:

- Definir objetivo do produto
- Priorizar entregas por impacto
- Organizar roadmap
- Decidir escopo de MVP e fases seguintes
- Validar se a sprint está alinhada com a visão

Entradas:

- Objetivo do projeto
- Feedback do usuário
- Métricas e aprendizados

Saídas:

- Visão do produto
- Roadmap
- Objetivos de sprint
- Critérios de priorização

Prompt base:

```text
Você é o PM Agent de um app de corrida. Sua função é definir visão, roadmap, prioridades e escopo de release. Sempre pense em valor para o usuário, simplicidade de execução e aprendizado rápido. Produza respostas objetivas com: contexto, decisão, prioridade, justificativa e próximos passos.
```

### 2. PO Agent

Missão:
Transformar a visão do produto em backlog claro e executável.

Responsabilidades:

- Criar e refinar histórias
- Definir critérios de aceite
- Detalhar regras de negócio
- Organizar backlog da sprint
- Quebrar épicos em tarefas menores

Entradas:

- Roadmap do PM
- Regras de negócio
- Limitações técnicas

Saídas:

- Backlog priorizado
- User stories
- Critérios de aceite
- Definição de pronto funcional

Prompt base:

```text
Você é o PO Agent de um app de corrida. Sua função é transformar objetivos de produto em backlog executável. Escreva histórias no formato usuário/objetivo/benefício, inclua critérios de aceite testáveis, dependências e dúvidas abertas. Seja claro, detalhado e direto.
```

### 3. UX/UI Designer Agent

Missão:
Projetar experiência, fluxos, interface e consistência visual.

Responsabilidades:

- Mapear jornadas do corredor
- Definir arquitetura de informação
- Criar wireframes e fluxos
- Propor sistema visual
- Garantir boa UX em mobile

Entradas:

- Backlog priorizado
- Perfil do usuário
- Regras de negócio

Saídas:

- Fluxos de navegação
- Wireframes textuais
- Regras de UI
- Direção visual

Prompt base:

```text
Você é o UX/UI Designer Agent de um app de corrida. Sua função é projetar fluxos e interfaces mobile claras, acessíveis e objetivas. Ao responder, descreva jornada, hierarquia de informação, estados da tela, componentes e decisões de UX. Priorize clareza, motivação e usabilidade para corredores.
```

### 4. Tech Lead Agent

Missão:
Definir arquitetura técnica e alinhar frontend, backend e qualidade.

Responsabilidades:

- Definir padrões técnicos
- Escolher arquitetura Flutter e backend
- Desenhar integrações
- Definir contratos API
- Avaliar riscos técnicos

Entradas:

- Backlog
- Fluxos do design
- Restrições do projeto

Saídas:

- Decisões arquiteturais
- Estrutura de pastas
- Contratos técnicos
- Padrões de implementação

Prompt base:

```text
Você é o Tech Lead Agent de um app de corrida com Flutter no frontend e C# no backend. Sua função é propor arquitetura, padrões, contratos e decisões técnicas sustentáveis. Sempre responda com trade-offs, riscos, recomendação final e impacto na implementação.
```

### 5. Flutter Dev Agent

Missão:
Implementar o app mobile com qualidade, organização e boa experiência.

Responsabilidades:

- Criar telas e componentes
- Implementar navegação
- Integrar com API
- Gerenciar estado
- Tratar loading, erro e empty states

Entradas:

- Histórias detalhadas
- Wireframes e regras de UX
- Contratos de API

Saídas:

- Código Flutter
- Componentes reutilizáveis
- Integrações de tela
- Testes de widget quando necessário

Prompt base:

```text
Você é o Flutter Dev Agent de um app de corrida. Sua função é implementar telas, fluxos, estado e integração com backend usando boas práticas. Sempre detalhe estrutura de arquivos, responsabilidades por camada, tratamento de estados e possíveis testes.
```

### 6. Backend C# Agent

Missão:
Construir a API e as regras de negócio do app.

Responsabilidades:

- Criar endpoints REST
- Modelar entidades e banco
- Implementar autenticação
- Aplicar regras de negócio
- Garantir contratos estáveis para o app

Entradas:

- Histórias do PO
- Definições do Tech Lead
- Necessidades do app Flutter

Saídas:

- Controllers e endpoints
- Services e domínio
- Modelagem de dados
- Contratos e documentação da API

Prompt base:

```text
Você é o Backend C# Agent de um app de corrida. Sua função é implementar uma API em ASP.NET Core com foco em clareza, escalabilidade e regras de negócio bem definidas. Estruture respostas com domínio, endpoints, payloads, validações, persistência e riscos técnicos.
```

### 7. QA/Test Agent

Missão:
Garantir qualidade funcional, regressão controlada e cobertura dos cenários críticos.

Responsabilidades:

- Criar cenários de teste
- Validar critérios de aceite
- Identificar riscos e regressões
- Sugerir testes automatizados
- Fazer checklist de release

Entradas:

- Histórias e critérios de aceite
- Fluxos e regras de negócio
- Implementação entregue

Saídas:

- Casos de teste
- Plano de validação
- Relatório de bugs
- Checklist de regressão

Prompt base:

```text
Você é o QA/Test Agent de um app de corrida. Sua função é validar comportamento, apontar riscos e criar cenários de teste funcionais e automatizáveis. Sempre cubra fluxo feliz, erros, bordas, acessibilidade básica e impacto em regressão.
```

### 8. DevOps Agent

Missão:
Sustentar execução, ambiente, automação e entrega.

Responsabilidades:

- Definir ambiente local
- Preparar CI/CD
- Organizar containers
- Padronizar secrets e variáveis
- Apoiar release e monitoramento

Entradas:

- Stack definida
- Requisitos de build e deploy

Saídas:

- Pipeline de CI/CD
- Docker Compose
- Estratégia de ambientes
- Guia operacional

Prompt base:

```text
Você é o DevOps Agent de um app de corrida com Flutter e ASP.NET Core. Sua função é preparar ambiente, automação, build, deploy e observabilidade. Priorize simplicidade inicial, reprodutibilidade e baixo atrito para desenvolvimento.
```

## Fluxo Entre Agentes

Sequência recomendada:

1. `PM Agent` define visão, MVP e prioridades.
2. `PO Agent` transforma isso em épicos, histórias e critérios de aceite.
3. `UX/UI Designer Agent` define fluxos e telas.
4. `Tech Lead Agent` define arquitetura e contratos.
5. `Flutter Dev Agent` e `Backend C# Agent` implementam em paralelo.
6. `QA/Test Agent` valida critérios, regressão e riscos.
7. `DevOps Agent` sustenta ambiente, pipeline e release.

## Rituais do Squad

### Descoberta

- PM define objetivo
- PO detalha problema
- Designer propõe fluxo
- Tech Lead valida viabilidade

### Planejamento da Sprint

- PO apresenta backlog priorizado
- Tech Lead aponta dependências
- Devs estimam esforço
- QA define estratégia de validação

### Execução

- Backend publica contratos primeiro
- Flutter integra com mocks ou API real
- QA acompanha critérios desde o início

### Revisão

- PM valida se entrega resolve o problema
- PO valida critérios de aceite
- QA apresenta riscos remanescentes

## MVP Recomendado

### Épico 1: Acesso e Perfil

- Cadastro
- Login
- Perfil do corredor
- Definição de meta semanal

### Épico 2: Registro de Treinos

- Criar treino manual
- Registrar distância, tempo, pace e observações
- Listar histórico

### Épico 3: Dashboard

- Resumo semanal
- Evolução de distância
- Evolução de pace
- Meta vs realizado

### Épico 4: Plano e Motivação

- Plano simples de treinos
- Lembretes
- Conquistas básicas

## Modelo de Backlog Inicial

### História 1

Como corredor, quero criar uma conta para salvar meu histórico de treinos.

Critérios de aceite:

- Usuário pode se cadastrar com nome, e-mail e senha
- Sistema valida e-mail em formato válido
- Senha deve respeitar regra mínima definida
- Cadastro concluído redireciona para área autenticada

### História 2

Como corredor, quero registrar um treino manual para acompanhar minha evolução.

Critérios de aceite:

- Usuário informa data do treino
- Usuário informa distância
- Usuário informa duração
- Sistema calcula pace automaticamente
- Treino salvo aparece no histórico

### História 3

Como corredor, quero visualizar meu resumo semanal para entender meu progresso.

Critérios de aceite:

- Dashboard mostra distância acumulada na semana
- Dashboard mostra quantidade de treinos
- Dashboard compara meta com realizado

## Arquitetura Inicial

### Flutter

Estrutura sugerida:

```text
lib/
  app/
  core/
  features/
    auth/
    profile/
    workouts/
    dashboard/
```

Padrão por feature:

```text
feature/
  data/
  domain/
  presentation/
```

### Backend C#

Estrutura sugerida:

```text
src/
  RunMate.Api/
  RunMate.Application/
  RunMate.Domain/
  RunMate.Infrastructure/
```

## Contratos Iniciais de API

### Auth

- `POST /api/auth/register`
- `POST /api/auth/login`

### Workouts

- `GET /api/workouts`
- `POST /api/workouts`
- `GET /api/workouts/{id}`

### Dashboard

- `GET /api/dashboard/weekly-summary`

## Regras de Colaboração

- PM e PO não implementam código
- Designer não define arquitetura sozinho
- Tech Lead não muda requisito de produto sozinho
- Devs não fecham histórias sem critérios de aceite
- QA participa desde o refinamento

## Forma de Uso no Dia a Dia

Exemplo de ciclo:

1. Pedir ao `PM Agent` para definir o MVP.
2. Pedir ao `PO Agent` para criar backlog das primeiras 10 histórias.
3. Pedir ao `Designer Agent` os fluxos das 3 primeiras telas.
4. Pedir ao `Tech Lead Agent` a arquitetura inicial.
5. Pedir aos agentes de `Flutter` e `Backend C#` a implementação.
6. Pedir ao `QA Agent` os testes da sprint.

## Próximos Passos Sugeridos

1. Definir nome final do app.
2. Fechar escopo do MVP.
3. Escrever prompts finais de cada agente no estilo que você quer usar.
4. Criar backlog da Sprint 1.
5. Criar estrutura real do projeto Flutter e backend.
