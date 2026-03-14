# Sprint 2 - Login e Cadastro

## Objetivo da sprint

Entregar a base completa de autenticacao do RunMate com foco em organizacao, arquitetura e seguranca.

## Meta da sprint

Ao final da sprint, o projeto deve ter:

- contexto do produto organizado
- agentes separados por papel
- arquitetura de autenticacao documentada
- estrutura de pastas refinada
- backlog de login e cadastro pronto para execucao

## Historias priorizadas

### US-201 - Organizar contexto e documentacao do projeto

Como time, queremos um contexto centralizado para que os agentes e o desenvolvimento trabalhem com menos ambiguidade.

Criterios de aceite:

- existe um documento central de contexto
- existe um documento de estrutura do projeto
- existe um documento da arquitetura de autenticacao
- sprint 2 esta documentada separadamente

### US-202 - Separar agentes por responsabilidade

Como time, queremos agentes separados por funcao para reduzir confusao na operacao do squad.

Criterios de aceite:

- cada agente tem um arquivo proprio
- os agentes recebem contexto consistente
- existe um agente de seguranca para apoiar autenticacao

### US-203 - Definir contrato seguro de cadastro

Como backend e frontend, queremos um contrato claro de cadastro para implementar sem inconsistencias.

Criterios de aceite:

- request e response estao definidos
- regras de validacao estao documentadas
- erros de negocio estao padronizados

### US-204 - Definir contrato seguro de login

Como backend e frontend, queremos um contrato claro de login para implementar autenticacao de forma segura.

Criterios de aceite:

- request e response estao definidos
- politica do token esta documentada
- erros de credenciais invalidas estao padronizados

### US-205 - Refinar estrutura tecnica do Flutter

Como time mobile, queremos uma estrutura organizada por feature para implementar autenticacao com baixo acoplamento.

Criterios de aceite:

- `features/auth` esta planejada
- camadas `data`, `domain` e `presentation` estao definidas
- storage seguro e tratamento de sessao estao previstos

### US-206 - Refinar estrutura tecnica do backend

Como time backend, queremos uma estrutura organizada por responsabilidade para implementar autenticacao com seguranca.

Criterios de aceite:

- camadas do backend estao refinadas
- hashing e JWT tem local proprio na arquitetura
- validacoes e contratos estao separados da API

## Tarefas por papel

### PM

- confirmar escopo fechado da sprint
- impedir entrada de features fora do foco

### PO

- detalhar historias de auth
- consolidar criterios de aceite
- mapear dependencias entre frontend e backend

### Tech Lead

- aprovar a estrategia de autenticacao
- aprovar estrutura final de pastas
- alinhar convencoes de naming e limites entre camadas

### Security Agent

- revisar politica de senha
- revisar uso de JWT
- revisar armazenamento seguro no mobile
- apontar riscos de exposicao de secrets e credenciais

### Flutter Dev

- definir esqueleto da feature auth
- alinhar navegacao de login e cadastro
- planejar storage seguro e sessao local

### Backend C# Dev

- definir comandos e DTOs de auth
- planejar hashing de senha
- planejar emissao do JWT
- alinhar erros padronizados

### QA

- criar cenarios para login e cadastro
- validar erros, estados vazios e respostas de seguranca

## Criterios de aceite gerais da sprint

- arquitetura de auth esta clara para todo o time
- nao ha duvidas abertas bloqueando implementacao
- seguranca minima esta documentada
- organizacao do projeto esta padronizada

## Definicao de pronto

- documentos principais criados
- agentes separados
- sprint 2 detalhada
- arquitetura segura definida
- backlog de implementacao pronto

## Fora do escopo

- login social
- redefinicao de senha
- confirmacao por e-mail
- refresh token completo
- painel administrativo
