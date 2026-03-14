# Sprint Execution — RunMate Auth Sprint

Processo de execução das 7 stories do sprint de autenticação usando Claude Code com worktrees paralelos.

## Stories do sprint

| # | Story | Área | Agentes | Depende de |
|---|-------|------|---------|-----------|
| [#2](https://github.com/ViniciusZimmerBrq/runmate/issues/2) | US-301 - Emissão de JWT real | Backend + Security | `backend-dev`, `security` | — |
| [#3](https://github.com/ViniciusZimmerBrq/runmate/issues/3) | US-302 - Cadastro de usuário | Backend | `backend-dev` | #2 |
| [#4](https://github.com/ViniciusZimmerBrq/runmate/issues/4) | US-303 - Login real | Backend | `backend-dev` | #2 |
| [#5](https://github.com/ViniciusZimmerBrq/runmate/issues/5) | US-304 - Telas de login e cadastro | Flutter + UX | `ux-ui`, `flutter-dev` | — |
| [#6](https://github.com/ViniciusZimmerBrq/runmate/issues/6) | US-305 - Integrar Flutter com API | Flutter | `flutter-dev` | #3, #4, #5 |
| [#7](https://github.com/ViniciusZimmerBrq/runmate/issues/7) | US-306 - Persistir sessão | Flutter | `flutter-dev` | #6 |
| [#8](https://github.com/ViniciusZimmerBrq/runmate/issues/8) | US-307 - Proteger navegação | Flutter | `flutter-dev` | #7 |

---

## Fases de execução

```
FASE 1 (paralelo)
  Sessão A ──── #2 JWT  ──────────────── PR ──┐
  Sessão B ──── #5 Telas Flutter ─────── PR ──┤
                                              │
FASE 2 (paralelo, após #2)                    │
  Sessão C ──── #3 Cadastro backend ──── PR ──┤
  Sessão D ──── #4 Login backend ─────── PR ──┤
                                              │
FASE 3 (após #3 + #4 + #5 mergeados)          │
  Sessão E ──── #6 Integração ──────────── PR ─┤
                                              │
FASE 4 (após #6)                              │
  Sessão F ──── #7 Persistência ─────── PR ───┤
                                              │
FASE 5 (após #7)                              │
  Sessão G ──── #8 Navegação ────────── PR ───┘
                                              │
                                         develop ✓
```

---

## Como executar cada fase

### Fase 1 — abrir 2 terminais simultaneamente

**Terminal A — issue #2 (JWT)**
```bash
cd /path/to/Run
claude
# dentro do Claude:
# /worktree feature/issue-2-jwt
# Trabalhar na issue #2 com backend-dev + security
```

**Terminal B — issue #5 (Telas Flutter)**
```bash
cd /path/to/Run
claude
# dentro do Claude:
# /worktree feature/issue-5-telas
# Trabalhar na issue #5 com ux-ui + flutter-dev
```

### Fase 2 — após PR #2 mergeado em develop

**Terminal C — issue #3 (Cadastro)**
```bash
cd /path/to/Run
claude
# /worktree feature/issue-3-cadastro
# Trabalhar na issue #3 com backend-dev
```

**Terminal D — issue #4 (Login)**
```bash
cd /path/to/Run
claude
# /worktree feature/issue-4-login
# Trabalhar na issue #4 com backend-dev
```

### Fases 3, 4, 5 — sequencial (cada uma espera o merge anterior)

```bash
# Fase 3 — issue #6
claude  →  /worktree feature/issue-6-integracao

# Fase 4 — issue #7
claude  →  /worktree feature/issue-7-persistencia

# Fase 5 — issue #8
claude  →  /worktree feature/issue-8-navegacao
```

---

## Protocolo por issue

Para cada issue, seguir este roteiro dentro da sessão Claude Code:

1. **Contexto** — ler `docs/context/PROJECT_CONTEXT.md` e o body da issue
2. **Planejamento** — agente `tech-lead` valida abordagem técnica
3. **Implementação** — agente especializado (`backend-dev` ou `flutter-dev`) executa
4. **Segurança** — agente `security` revisa se a issue tiver label `security`
5. **Testes** — `make backend-test` ou `make flutter-test`
6. **PR** — agente `pr-creator` cria o PR com `Closes #N`
7. **Review** — agente `code-review` revisa antes do merge

---

## Critério de avanço entre fases

- PR mergeado em `develop` (squash merge)
- CI verde (`flutter_ci` + `backend_ci`)
- Nenhum `TODO` ou código comentado no diff

---

## Dev local durante o sprint

```bash
make dev          # backend :5000 + Flutter conectado
make backend-test # testar backend antes de abrir PR
make flutter-test # testar Flutter antes de abrir PR
```

---

## Automação GitHub Projects

Ao seguir este processo, o board se atualiza automaticamente via `agent_orchestrator.yml`:

| Ação | Resultado no board |
|------|-------------------|
| Issue recebe assignee | → In Progress |
| PR aberto com `Closes #N` | → Review |
| PR mergeado | → QA |
