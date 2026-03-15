# GitHub Setup Checklist - RunMate

## O que ja esta pronto no repositorio

- templates de issue
- template de Pull Request
- CODEOWNERS
- workflows de CI para Flutter e backend
- workflow de qualidade de PR
- workflow de artifacts para release
- documentacao de Git Flow e CI/CD

## O que falta configurar no GitHub

### 1. Criar o repositorio remoto

- criar repo no GitHub
- adicionar `origin`
- subir `main`

### 2. Criar branch base

- criar `develop`
- subir `develop`
- definir `main` como default branch no inicio ou manter `develop` como branch de integracao, conforme sua preferencia

### 3. Ajustar CODEOWNERS

Trocar `@OWNER` em [CODEOWNERS](/Users/user/Desktop/CODE/Run/.github/CODEOWNERS) pelo seu usuario ou time real do GitHub.

### 4. Configurar branch protection

Em `main` e `develop`, ativar:

- require pull request before merging
- require approvals
- require status checks
- require conversation resolution
- block force pushes

### 5. Habilitar GitHub Actions

Confirmar que Actions esta habilitado e que os workflows aparecem:

- `Flutter CI`
- `Backend CI`
- `PR Quality`
- `Release Artifacts`

### 6. Configurar secrets futuros

Quando entrar deploy real:

- `JWT_SECRET`
- credenciais de ambiente
- secrets de assinatura Android

## Comandos iniciais sugeridos

```bash
git checkout -b main
git add .
git commit -m "chore: bootstrap runmate project structure"
git remote add origin <URL_DO_REPOSITORIO>
git push -u origin main
git checkout -b develop
git push -u origin develop
```
