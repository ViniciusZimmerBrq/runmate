# Git e GitHub Flow - RunMate

## Objetivo

Definir um fluxo de Git claro, seguro e fluido para um projeto com app Flutter, backend ASP.NET Core e time multi-agentes.

## Estrategia recomendada

Usaremos uma adaptacao de `Git Flow` com pouca burocracia:

- `main`: codigo estavel e pronto para release
- `develop`: integracao continua do proximo ciclo
- `feature/*`: novas funcionalidades
- `release/*`: preparacao de release
- `hotfix/*`: correcoes urgentes em producao

## Convencoes de branches

Exemplos:

- `feature/auth-login-screen`
- `feature/auth-register-endpoint`
- `release/v0.1.0`
- `hotfix/jwt-expiration-fix`

## Regras por branch

### main

- branch protegida
- merge apenas por Pull Request
- exige CI verde
- exige ao menos 1 aprovacao
- sem push direto

### develop

- branch protegida
- merge apenas por Pull Request
- exige CI verde
- exige ao menos 1 aprovacao

### feature/*

- sai de `develop`
- volta para `develop`
- deve ser pequena e focada

### release/*

- sai de `develop`
- recebe ajustes finais de release
- merge para `main`
- depois merge de volta para `develop`

### hotfix/*

- sai de `main`
- merge para `main`
- merge de volta para `develop`

## Fluxo padrao de trabalho

1. criar branch a partir de `develop`
2. implementar uma feature pequena
3. abrir PR para `develop`
4. passar CI
5. receber code review
6. fazer squash merge

## Estrategia de merge

Padrao recomendado:

- `Squash and merge` em feature branches
- `Merge commit` opcional para `release/*` e `hotfix/*` se quiser preservar historico de release

## Convencao de commits

Usar `Conventional Commits`:

- `feat: add login form validation`
- `fix: handle expired jwt token`
- `docs: document secure auth architecture`
- `refactor: simplify auth repository`
- `test: add auth response dto tests`
- `ci: add backend github action`

## Regras de Pull Request

- um PR deve tratar um unico problema principal
- todo PR deve explicar contexto e impacto
- PRs grandes devem ser evitados
- toda mudanca relevante deve vir com criterio de teste

## Definition of Ready para abrir PR

- escopo pequeno e claro
- branch atualizada
- sem codigo experimental perdido
- testes relevantes rodando
- documentacao ajustada quando necessario

## Definition of Done para merge

- CI verde
- checklist do PR preenchido
- code review aprovado
- sem comentarios criticos pendentes
- riscos remanescentes explicitados

## Protecoes recomendadas no GitHub

- branch protection em `main` e `develop`
- exigir status checks
- exigir branch atualizada antes do merge
- bloquear force push
- bloquear deletion acidental
- exigir conversa resolvida antes do merge

## Sequencia inicial recomendada no GitHub

1. criar repo no GitHub
2. subir branch `main`
3. criar branch `develop`
4. configurar branch protection
5. ativar GitHub Actions
6. definir CODEOWNERS
7. testar primeiro PR pequeno
