# Sprint 3 - Operational Runbook

## Objetivo

Transformar a Sprint 3 em um fluxo operacional real, dizendo qual agente entra em cada historia, em qual ordem e com qual criterio de handoff.

## Meta da sprint

Entregar autenticacao real ponta a ponta, com backend seguro, telas reais no Flutter, sessao persistida e navegacao protegida.

## Ordem recomendada da sprint

1. `US-301` - JWT real
2. `US-302` - cadastro real
3. `US-303` - login real
4. `US-304` - telas reais de auth
5. `US-305` - integracao Flutter com API real
6. `US-306` - persistencia de sessao
7. `US-307` - navegacao protegida

## Parallelismo recomendado

Pode acontecer em paralelo:

- `US-304` enquanto backend fecha `US-302` e `US-303`
- refinamento de `US-306` e `US-307` enquanto `US-305` esta em andamento

Nao deve acontecer em paralelo sem alinhamento:

- `US-305` antes de contrato real minimamente estabilizado
- `US-307` antes de sessao persistida estar clara

## Workflow operacional por historia

### US-301 - Implementar emissao de JWT real no backend

#### Ordem de agentes

1. `PM`
2. `PO`
3. `Tech Lead`
4. `Security`
5. `Backend Dev`
6. `PR Creator`
7. `Code Review`
8. `QA`

#### Entrega esperada por etapa

- `PM`: confirma que auth real e prioridade da sprint
- `PO`: fecha criterio de aceite e fora de escopo
- `Tech Lead`: define contrato e configuracao JWT
- `Security`: revisa emissao, claims, expiracao e secret
- `Backend Dev`: implementa emissao e validacao
- `PR Creator`: abre PR com risco e validacao
- `Code Review`: revisa bug, seguranca e contrato
- `QA`: valida token, erro e comportamento de ambiente

### US-302 - Implementar cadastro real de usuario no backend

#### Ordem de agentes

1. `PO`
2. `Tech Lead`
3. `Security`
4. `Backend Dev`
5. `PR Creator`
6. `Code Review`
7. `QA`

#### Ponto de atencao

- validar normalizacao de e-mail
- validar politica de senha
- validar hash e retorno seguro

### US-303 - Implementar login real no backend

#### Ordem de agentes

1. `PO`
2. `Tech Lead`
3. `Security`
4. `Backend Dev`
5. `PR Creator`
6. `Code Review`
7. `QA`

#### Ponto de atencao

- erro generico
- nao vazar existencia de e-mail
- sessao coerente com contrato do app

### US-304 - Criar telas reais de login e cadastro no Flutter

#### Ordem de agentes

1. `PO`
2. `UX/UI`
3. `Tech Lead`
4. `Flutter Dev`
5. `PR Creator`
6. `Code Review`
7. `QA`

#### Ponto de atencao

- loading, erro e sucesso
- microcopy clara
- validacao local sem conflito com backend

### US-305 - Integrar Flutter com API real de auth

#### Ordem de agentes

1. `Tech Lead`
2. `Flutter Dev`
3. `Backend Dev`
4. `PR Creator`
5. `Code Review`
6. `QA`

#### Ponto de atencao

- nao acoplar UI ao HTTP
- mapear corretamente 400, 401 e 409
- alinhar DTOs e entidades

### US-306 - Persistir sessao autenticada no app

#### Ordem de agentes

1. `Tech Lead`
2. `Security`
3. `Flutter Dev`
4. `PR Creator`
5. `Code Review`
6. `QA`

#### Ponto de atencao

- usar storage apropriado
- nao salvar senha
- limpar sessao corretamente

### US-307 - Proteger navegacao por estado de sessao

#### Ordem de agentes

1. `PO`
2. `Tech Lead`
3. `Flutter Dev`
4. `QA`
5. `PR Creator`
6. `Code Review`
7. `QA` final

#### Ponto de atencao

- regra de bootstrap centralizada
- logout consistente
- sessao invalida cai em auth com seguranca

## Definicao pratica de pronto por historia

Uma historia da Sprint 3 so deve sair de `Ready` para `In Progress` se:

- criterio de aceite estiver claro
- `Primary Agent` estiver definido
- `Risk` estiver preenchido
- dependencia principal estiver clara

Uma historia da Sprint 3 so deve ir para `Done` se:

- passou por review
- passou por QA
- o board reflete o estado real
- o handoff final para `PO` estiver claro

## Runbook diario

### Inicio do dia

- revisar `Ready`
- limitar itens em `In Progress`
- explicitar `Blocked`

### Meio do dia

- checar se algum item precisa de `Security`
- checar se algum item pode seguir para `Review`

### Fim do dia

- atualizar board
- registrar proximo handoff
- deixar risco ou bloqueio explicito

## Responsabilidade por camada na Sprint 3

### Produto

- `PM`
- `PO`

### Arquitetura e seguranca

- `Tech Lead`
- `Security`

### Implementacao

- `Backend Dev`
- `Flutter Dev`

### Governanca

- `PR Creator`
- `Code Review`
- `QA`
