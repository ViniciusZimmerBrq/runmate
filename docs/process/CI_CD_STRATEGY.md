# CI/CD Strategy - RunMate

## Objetivo

Criar uma pipeline confiavel para validar codigo, padronizar qualidade e preparar releases.

## CI obrigatoria por Pull Request

### Flutter

- `flutter pub get`
- `flutter analyze`
- `flutter test`

### Backend

- `dotnet restore`
- `dotnet build`
- `dotnet test`

## Checks complementares

- validar titulo do PR
- validar mudancas em arquivos criticos com code review
- publicar artifacts em tags de release

## CD recomendado

### Backend

- gerar artifact publicado em release
- proximo passo futuro: deploy em ambiente de homologacao

### Flutter

- gerar artifact Android em tag de release
- proximo passo futuro: integrar Fastlane e distribuicao interna

## Gates de qualidade

- nenhuma release sai sem CI verde
- toda release sai de `release/*` ou tag
- `main` deve refletir apenas estado estavel

## Segredos e variaveis

Segredos no GitHub:

- `JWT_SECRET`
- `BACKEND_PUBLISH_PROFILE` no futuro
- `ANDROID_KEYSTORE_BASE64` no futuro
- `ANDROID_KEYSTORE_PASSWORD` no futuro

Regras:

- nunca commitar secrets
- usar GitHub Secrets e Environments
- separar `dev`, `staging` e `prod` futuramente

## Ordem de maturidade

### Agora

- CI em PR
- artifacts em release
- templates de PR e issue

### Depois

- deploy automatico de homologacao
- validacao de cobertura minima
- scan de seguranca
- semantic release
