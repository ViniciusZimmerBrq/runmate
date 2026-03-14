# Secrets and Env Setup - RunMate

## Objetivo

Definir como o projeto vai tratar configuracoes sensiveis e variaveis de ambiente, com foco especial em autenticacao.

## Principios

- nenhum secret entra no Git
- Flutter nao deve embutir segredo sensivel
- backend le secrets por environment variables ou secret manager
- exemplos de configuracao podem ser versionados, valores reais nao

## Flutter

No app Flutter, apenas configuracoes publicas ou semi-publicas devem entrar via `--dart-define`.

Exemplos aceitaveis:

- `API_BASE_URL`
- `APP_ENV`

Exemplos que nao devem entrar no app:

- `JWT_SECRET`
- connection strings
- credenciais de servicos

Sugestao de execucao local:

```bash
flutter run --dart-define=API_BASE_URL=http://localhost:8080 --dart-define=APP_ENV=dev
```

## Backend

No backend ASP.NET Core, usar:

- `appsettings.json` para defaults nao sensiveis
- `.env` local nao versionado ou secrets do sistema para desenvolvimento
- GitHub Secrets para CI/CD
- secret manager da nuvem em producao

## Variaveis iniciais recomendadas

### Backend

- `JWT__Secret`
- `JWT__Issuer`
- `JWT__Audience`
- `ConnectionStrings__DefaultConnection`
- `ASPNETCORE_ENVIRONMENT`

### Flutter

- `API_BASE_URL`
- `APP_ENV`

## GitHub Secrets recomendados

- `JWT_SECRET`
- `BACKEND_CONNECTION_STRING`
- `ANDROID_KEYSTORE_BASE64`
- `ANDROID_KEYSTORE_PASSWORD`
- `ANDROID_KEY_ALIAS`
- `ANDROID_KEY_PASSWORD`

## Regras para autenticacao

- o `JWT__Secret` nunca deve aparecer em log
- `JWT__Secret` deve ser forte e longo
- access tokens devem expirar rapidamente
- refresh token, quando existir, deve ter politica separada
- senhas nunca sao armazenadas fora do backend

## Convencao de arquivos

Arquivos que podem existir no repo:

- `.env.example`
- `appsettings.Development.json.example`

Arquivos que nao devem entrar no repo:

- `.env`
- `appsettings.Development.json` com segredo real
- qualquer arquivo com credencial operacional
