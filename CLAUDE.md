# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project overview

RunMate is a running app with:
- `runmate_app/` — Flutter mobile app (Dart, SDK ^3.7.2)
- `runmate_backend/` — ASP.NET Core C# backend
- `.claude/agents/` — Claude Code subagents (operative, loaded automatically)
- `docs/` — Architecture, context, process, and roadmap documentation

## Commands

### Flutter (runmate_app/)

```bash
# Install dependencies
flutter pub get

# Run app with env vars
flutter run --dart-define=API_BASE_URL=http://localhost:5000 --dart-define=APP_ENV=dev

# Run all tests
flutter test

# Run a single test file
flutter test test/path/to/test_file.dart

# Lint
flutter analyze
```

### Backend (runmate_backend/)

```bash
# Run the API
cd runmate_backend
dotnet run --project src/RunMate.Api

# Run tests
dotnet test

# Build
dotnet build RunMate.sln
```

The backend requires a local `appsettings.Development.json` (not in git) based on the `.example` file at `src/RunMate.Api/appsettings.Development.json.example`. Required env vars: `JWT__Secret`, `JWT__Issuer`, `JWT__Audience`, `ConnectionStrings__DefaultConnection`.

## Rodar em paralelo (dev local)

Use o Makefile para subir backend e Flutter simultaneamente:

```bash
make dev          # backend .NET na :5000 (background) + Flutter app (foreground)
make backend      # só o backend
make flutter      # só o Flutter app
make test         # backend-test + flutter-test em sequência
make backend-test # só testes .NET
make flutter-test # só testes Flutter
```

`make dev` inicia o `dotnet run` em background e em seguida `flutter run` no foreground. Para encerrar tudo, `Ctrl+C` mata o Flutter e o backend encerra junto ao fechar o terminal.

## Agentes em paralelo (worktrees)

Para trabalhar em múltiplas issues simultaneamente sem conflito de arquivos, use Claude Code com worktrees — um por issue:

```bash
# Sessão A: issue #5 (Flutter login screen)
cd /path/to/Run && claude  # dentro do Claude: /worktree feature/issue-5

# Sessão B: issue #6 (Backend JWT endpoint)
cd /path/to/Run && claude  # dentro do Claude: /worktree feature/issue-6
```

Cada worktree = branch isolada = agente especializado sem sobrescrever o trabalho dos outros.

Para ver os agentes disponíveis dentro de qualquer sessão Claude Code, use `/agents`.

Agentes disponíveis: `pm`, `po`, `tech-lead`, `flutter-dev`, `backend-dev`, `security`, `qa`, `code-review`, `ux-ui`, `pr-creator`.

## Architecture

### Flutter app structure

`lib/` follows a feature-first clean architecture:

```
lib/
  app/          # App entry, theme, navigation
  core/         # Shared code: networking, storage, error, widgets
  features/
    auth/
      data/         # DTOs, remote datasources, repository implementations
      domain/       # Entities, repository interfaces, use cases
      presentation/ # Controllers, pages, widgets
    dashboard/
    workouts/
```

Rules: `presentation` does not know HTTP details; `data` translates contracts; `domain` holds business rules and interfaces. No business logic in the UI layer.

### Backend layers (RunMate.sln)

```
src/
  RunMate.Api/          # HTTP endpoints, middleware, contracts, configuration
  RunMate.Application/  # Use cases orchestration (Auth/Commands, Validators, Dtos)
  RunMate.Infrastructure/ # Persistence, Security (JWT, password hashing)
  RunMate.Domain/       # Core entities, value objects, domain services
```

Domain does not depend on any other layer. Infrastructure implements interfaces defined in Application.

### Auth API contracts

`POST /api/auth/register` → 201 with `{userId, name, email}` or 400/409
`POST /api/auth/login` → 200 with `{accessToken, expiresInSeconds, user}` or 401

Password policy: 8+ chars, uppercase, lowercase, number, special character.

## Git flow

- `main` → stable, release-ready
- `develop` → integration branch (current active branch)
- `feature/*` → branches off `develop`, PRs back to `develop`
- `hotfix/*` → branches off `main`

Branch naming: `feature/auth-login-screen`, `hotfix/jwt-expiration-fix`
Commit style: Conventional Commits (`feat:`, `fix:`, `docs:`, `refactor:`, `test:`, `ci:`)
Merge strategy: squash merge for feature branches.

PRs target `develop`. Both `main` and `develop` are protected — no direct push.

## Multi-agent squad

The project uses Claude Code native subagents defined in `.claude/agents/`. Claude automatically delegates tasks to the right agent based on context.

Story workflow: `Backlog → Refinement → Ready → In Progress → Review → QA → Done`. GitHub Projects is the source of truth for execution.

Handoff sequence (typical): `pm → po → ux-ui (if screen) → tech-lead → flutter-dev / backend-dev → security (if auth) → pr-creator → code-review → qa`

Key context files:
- `docs/context/PROJECT_CONTEXT.md` — current sprint scope and product goals
- `docs/process/AGENT_HANDOFF_CONTRACT.md` — handoff format between roles

## Env and secrets

Never commit real secrets. Use:
- `appsettings.Development.json.example` as template for backend
- `--dart-define` for Flutter (only non-sensitive values like `API_BASE_URL`)
- `.env` files locally (not versioned)

`JWT__Secret` must never appear in logs or be hardcoded anywhere.
