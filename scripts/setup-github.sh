#!/usr/bin/env bash
# =============================================================================
# RunMate – GitHub Setup Script
# Configura branch protection, rulesets e settings do repositório.
#
# Uso:
#   ./scripts/setup-github.sh
#
# Pré-requisitos:
#   - gh CLI autenticado (gh auth login)
#   - Ser owner ou admin do repositório
# =============================================================================

set -euo pipefail

OWNER="${RUNMATE_OWNER:-ViniciusZimmerBrq}"
REPO="${RUNMATE_REPO:-runmate}"
FULL_REPO="${OWNER}/${REPO}"

# CI check names (devem bater com os job names nos workflows)
CI_CHECKS=(
  "Flutter CI / flutter"
  "Backend CI / backend"
  "PR Quality / PR Title"
  "PR Quality / PR Size"
  "GitFlow / Branch Naming"
  "GitFlow / PR Target Branch"
)

log()  { echo "  $*"; }
ok()   { echo "  ✓ $*"; }
warn() { echo "  ⚠ $*"; }
sep()  { echo; echo "──────────────────────────────────────────────"; }

echo
echo "╭──────────────────────────────────────────────╮"
echo "│      🔧 RunMate – GitHub Setup               │"
echo "│      Repo: ${FULL_REPO}                      │"
echo "╰──────────────────────────────────────────────╯"
echo

# ── Verifica gh CLI ─────────────────────────────────────────────────────────
if ! command -v gh &>/dev/null; then
  echo "❌ gh CLI não encontrado. Instale: https://cli.github.com"
  exit 1
fi

if ! gh auth status &>/dev/null; then
  echo "❌ Não autenticado no gh CLI. Execute: gh auth login"
  exit 1
fi

ok "gh CLI autenticado"

# ── Configura o repositório ──────────────────────────────────────────────────
sep
log "Configurando repositório..."

gh api "repos/${FULL_REPO}" \
  --method PATCH \
  --field has_issues=true \
  --field has_projects=true \
  --field has_wiki=false \
  --field allow_squash_merge=true \
  --field allow_merge_commit=false \
  --field allow_rebase_merge=false \
  --field delete_branch_on_merge=true \
  --field allow_auto_merge=false \
  > /dev/null

ok "Repositório configurado (squash merge, auto-delete branch)"

# ── Proteção do branch main ──────────────────────────────────────────────────
sep
log "Protegendo branch main..."

gh api "repos/${FULL_REPO}/branches/main/protection" \
  --method PUT \
  --header "Accept: application/vnd.github+json" \
  --input - <<EOF
{
  "required_status_checks": {
    "strict": true,
    "contexts": [
      "Flutter CI / flutter",
      "Backend CI / backend",
      "PR Quality / PR Title",
      "GitFlow / Branch Naming",
      "GitFlow / PR Target Branch"
    ]
  },
  "enforce_admins": false,
  "required_pull_request_reviews": {
    "required_approving_review_count": 1,
    "dismiss_stale_reviews": true,
    "require_code_owner_reviews": true
  },
  "restrictions": null,
  "required_linear_history": true,
  "allow_force_pushes": false,
  "allow_deletions": false
}
EOF

ok "main: protegida (PR obrigatório + CI + 1 review + histórico linear)"

# ── Proteção do branch develop ───────────────────────────────────────────────
sep
log "Protegendo branch develop..."

gh api "repos/${FULL_REPO}/branches/develop/protection" \
  --method PUT \
  --header "Accept: application/vnd.github+json" \
  --input - <<EOF
{
  "required_status_checks": {
    "strict": false,
    "contexts": [
      "Flutter CI / flutter",
      "Backend CI / backend",
      "PR Quality / PR Title",
      "GitFlow / Branch Naming"
    ]
  },
  "enforce_admins": false,
  "required_pull_request_reviews": {
    "required_approving_review_count": 1,
    "dismiss_stale_reviews": false,
    "require_code_owner_reviews": false
  },
  "restrictions": null,
  "required_linear_history": false,
  "allow_force_pushes": false,
  "allow_deletions": false
}
EOF

ok "develop: protegida (PR obrigatório + CI)"

# ── Limpar branches stale ────────────────────────────────────────────────────
sep
log "Branches remotas a limpar (stale):"

STALE=(
  "codex/github-project-agent-ops"
  "codex/multi-agent-squad-setup"
)

for branch in "${STALE[@]}"; do
  if gh api "repos/${FULL_REPO}/branches/${branch}" &>/dev/null 2>&1; then
    gh api "repos/${FULL_REPO}/git/refs/heads/${branch}" --method DELETE
    ok "Deletada: ${branch}"
  else
    warn "Já não existe: ${branch}"
  fi
done

# ── Configurar secrets necessários ───────────────────────────────────────────
sep
log "Secrets necessários para os workflows:"
echo
echo "    gh secret set PROJECT_AUTOMATION_TOKEN"
echo "    → Token com permissões: repo, project"
echo "    → Necessário para: agent_orchestrator (mover cards no board)"
echo
echo "    gh secret set BOT_APPROVER_TOKEN   (opcional)"
echo "    → Token de conta bot para auto-approve de docs"

# ── Resumo final ─────────────────────────────────────────────────────────────
sep
echo
echo "  ✅ Setup concluído!"
echo
echo "  Próximos passos:"
echo "  1. Configure os secrets acima se ainda não fez"
echo "  2. Verifique as proteções em:"
echo "     https://github.com/${FULL_REPO}/settings/branches"
echo "  3. Rode o primeiro workflow:"
echo "     make workflow ISSUE=2"
echo
