#!/usr/bin/env bash
# =============================================================================
# RunMate – Release Script (GitFlow)
# Cria uma release branch a partir de develop, bump de versão e abre PR.
#
# Uso:
#   ./scripts/release.sh <versao>
#   ./scripts/release.sh 1.1.0
# =============================================================================

set -euo pipefail

VERSION="${1:-}"

if [ -z "$VERSION" ]; then
  echo "Uso: ./scripts/release.sh <versao>"
  echo "  Ex: ./scripts/release.sh 1.1.0"
  exit 1
fi

BRANCH="release/${VERSION}"
PUBSPEC="runmate_app/pubspec.yaml"

echo
echo "╭──────────────────────────────────────────────╮"
echo "│  🚀 RunMate Release – v${VERSION}            │"
echo "╰──────────────────────────────────────────────╯"
echo

# Garante que estamos em develop e up to date
git checkout develop
git pull origin develop

# Cria a release branch
git checkout -b "${BRANCH}"
echo "  ✓ Branch criada: ${BRANCH}"

# Bump de versão no pubspec.yaml
BUILD=$(grep '^version:' "$PUBSPEC" | cut -d'+' -f2)
NEW_BUILD=$((BUILD + 1))
sed -i '' "s/^version:.*/version: ${VERSION}+${NEW_BUILD}/" "$PUBSPEC"
echo "  ✓ pubspec.yaml atualizado: ${VERSION}+${NEW_BUILD}"

# Commit do bump
git add "$PUBSPEC"
git commit -m "chore(release): bump version to ${VERSION}+${NEW_BUILD}"
echo "  ✓ Commit de versão criado"

# Push da branch
git push -u origin "${BRANCH}"
echo "  ✓ Branch publicada no remote"

# Abre PR para main
gh pr create \
  --base main \
  --head "${BRANCH}" \
  --title "release: v${VERSION}" \
  --body "$(cat <<EOF
## Release v${VERSION}

### Checklist
- [ ] CI passa em develop
- [ ] Testes manuais realizados
- [ ] \`pubspec.yaml\` atualizado para \`${VERSION}+${NEW_BUILD}\`
- [ ] CHANGELOG atualizado

### Após merge
- Tag \`v${VERSION}\` será criada automaticamente
- Fazer merge também em develop: \`git checkout develop && git merge ${BRANCH}\`
EOF
)"

echo
echo "  ✅ Release PR criado!"
echo "  Após aprovação e merge em main:"
echo "  1. A tag v${VERSION} é criada automaticamente"
echo "  2. Rode: git checkout develop && git merge ${BRANCH}"
echo "  3. Rode: git push origin develop"
echo "  4. Delete a release branch: git branch -d ${BRANCH}"
echo
