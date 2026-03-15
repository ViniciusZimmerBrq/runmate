#!/usr/bin/env bash
# =============================================================================
# RunMate – Preparar projeto para a Sprint
# Organiza branches, commita pendências e empurra tudo ao GitHub.
#
# Execute este script do seu terminal (fora do Cowork):
#   cd ~/Desktop/CODE/Run
#   bash scripts/prepare-sprint.sh
# =============================================================================

set -euo pipefail

log()  { echo "  $*"; }
ok()   { echo "  ✓ $*"; }
sep()  { echo; echo "──────────────────────────────────────────────"; }

echo
echo "╭──────────────────────────────────────────────╮"
echo "│  🏃 RunMate – Preparar Sprint                │"
echo "╰──────────────────────────────────────────────╯"

ROOT="$(git rev-parse --show-toplevel)"
cd "$ROOT"

# ── 1. Limpar worktrees mortos ───────────────────────────────────────────────
sep
log "Limpando worktrees..."
git worktree prune
ok "Worktrees limpos"

# ── 2. Remover lock files órfãos (se existirem) ──────────────────────────────
for lock in .git/index.lock .git/HEAD.lock; do
  if [ -f "$lock" ]; then
    rm -f "$lock"
    ok "Removido: $lock"
  fi
done

# ── 3. Commitar arquivos novos (GitFlow + scripts) ───────────────────────────
sep
log "Verificando arquivos pendentes..."

git add \
  .github/workflows/gitflow.yml \
  .github/workflows/pr_quality.yml \
  scripts/setup-github.sh \
  scripts/release.sh \
  scripts/prepare-sprint.sh \
  Makefile 2>/dev/null || true

STAGED=$(git diff --cached --name-only | wc -l)
if [ "$STAGED" -gt 0 ]; then
  git commit -m "feat(gitflow): add GitFlow automation, branch protection and release workflow

- Add .github/workflows/gitflow.yml (branch naming, target validation, auto-tag, release PR)
- Update pr_quality.yml (add description check, release type)
- Add scripts/setup-github.sh (branch protection via gh api)
- Add scripts/release.sh (version bump + release branch + PR)
- Add make setup-github and make release targets

Co-Authored-By: Claude Sonnet 4.6 <noreply@anthropic.com>"
  ok "Commit criado"
else
  ok "Nada pendente para commitar"
fi

# ── 4. Sincronizar develop ────────────────────────────────────────────────────
sep
log "Sincronizando develop com feature/refactor-clean-repo..."

CURRENT=$(git branch --show-current)
git checkout develop
git merge feature/refactor-clean-repo --ff-only 2>/dev/null \
  || git merge feature/refactor-clean-repo --no-edit
ok "develop atualizado"

# ── 5. Sincronizar main com develop ──────────────────────────────────────────
sep
log "Sincronizando main com develop..."

git checkout main
git merge develop --ff-only 2>/dev/null \
  || {
    log "(main e develop divergiram – criando merge commit)"
    git merge develop --no-edit -m "chore: sync main with develop for sprint preparation"
  }
ok "main atualizado"

# ── 6. Deletar branches stale locais ─────────────────────────────────────────
sep
log "Removendo branches locais obsoletas..."

for branch in codex/github-project-agent-ops codex/multi-agent-squad-setup feature/refactor-clean-repo; do
  if git show-ref --verify --quiet "refs/heads/${branch}"; then
    git branch -d "$branch" 2>/dev/null || git branch -D "$branch"
    ok "Deletada: ${branch}"
  fi
done

# ── 7. Push de tudo ──────────────────────────────────────────────────────────
sep
log "Empurrando branches para o GitHub..."

git push origin main
ok "main publicado"

git push origin develop
ok "develop publicado"

# ── 8. Resetar estado local do workflow ──────────────────────────────────────
sep
log "Zerando estado local do workflow de agentes..."
mkdir -p .runmate
echo '{"issues": {}}' > .runmate/ops-state.json
ok "Estado resetado (.runmate/ops-state.json)"

# ── 9. Configurar GitHub (proteção de branches, etc.) ────────────────────────
sep
echo
echo "  Agora rode o setup do GitHub para proteger as branches:"
echo
echo "    make setup-github"
echo
echo "  E verifique as issues prontas para rodar:"
echo
echo "    make issues"
echo

# ── Resumo ───────────────────────────────────────────────────────────────────
sep
echo
echo "  ✅ Projeto preparado para a Sprint!"
echo
echo "  Branches:"
echo "    main    → $(git rev-parse --short main)"
echo "    develop → $(git rev-parse --short develop)"
echo
echo "  Para rodar o workflow de agentes em uma issue:"
echo "    make workflow ISSUE=2"
echo
