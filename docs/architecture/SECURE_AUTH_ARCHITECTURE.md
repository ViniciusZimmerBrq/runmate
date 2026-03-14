# Arquitetura de Autenticacao Segura - Sprint 2

## Objetivo

Definir a arquitetura de login e cadastro do RunMate com foco em seguranca, clareza e evolucao futura.

## Decisoes principais

### 1. Estrategia de autenticacao

Para a Sprint 2:

- cadastro com e-mail e senha
- login com e-mail e senha
- access token JWT de curta duracao
- refresh token ainda fora do escopo de implementacao final

## Principios de seguranca

- nunca armazenar senha em texto puro
- usar hashing forte de senha com salt
- validar entrada no backend mesmo que o frontend tambem valide
- nao vazar se o e-mail existe ou nao alem do necessario
- respostas de erro devem ser controladas e consistentes
- secrets nunca devem ficar hardcoded no app Flutter
- JWT deve conter apenas claims necessarios

## Recomendacoes para o backend

### Cadastro

Fluxo:

1. receber nome, e-mail e senha
2. validar formato e regras
3. verificar unicidade do e-mail
4. gerar password hash com algoritmo seguro
5. persistir usuario
6. retornar resposta sanitizada

Boas praticas:

- usar `ASP.NET Core Identity` ou `PasswordHasher<TUser>`
- e-mail deve ser salvo normalizado
- senha deve ter politica minima clara
- nao retornar detalhes internos em falhas

### Login

Fluxo:

1. receber e-mail e senha
2. buscar usuario pelo e-mail normalizado
3. validar hash da senha
4. gerar JWT assinado
5. retornar token e dados minimos da sessao

Boas praticas:

- mensagem de erro generica para credenciais invalidas
- limitar tentativas em etapa futura
- logar falhas sem expor dados sensiveis
- configurar expiracao curta do token

## Recomendacoes para o Flutter

- armazenar access token em storage seguro
- nao salvar senha localmente
- isolar autenticacao em `features/auth`
- centralizar tratamento de erros de autenticacao
- proteger rotas autenticadas por estado de sessao

## Estrutura sugerida da feature auth no Flutter

```text
features/auth/
  data/
    datasources/auth_remote_datasource.dart
    dtos/login_request_dto.dart
    dtos/register_request_dto.dart
    dtos/auth_response_dto.dart
    repositories/auth_repository_impl.dart
  domain/
    entities/auth_session.dart
    repositories/auth_repository.dart
    usecases/login_usecase.dart
    usecases/register_usecase.dart
    usecases/logout_usecase.dart
  presentation/
    controllers/auth_controller.dart
    pages/login_page.dart
    pages/register_page.dart
    widgets/auth_text_field.dart
```

## Estrutura sugerida da feature auth no backend

```text
RunMate.Application/
  Auth/
    Dtos/
    Commands/
    Validators/
    Interfaces/

RunMate.Infrastructure/
  Security/
    JwtTokenGenerator.cs
    PasswordHashService.cs

RunMate.Api/
  Endpoints/
    AuthEndpoints.cs
```

## Contratos iniciais

### POST /api/auth/register

Request:

```json
{
  "name": "Vinicius",
  "email": "vinicius@email.com",
  "password": "SenhaForte123!"
}
```

Response 201:

```json
{
  "userId": "uuid",
  "name": "Vinicius",
  "email": "vinicius@email.com"
}
```

### POST /api/auth/login

Request:

```json
{
  "email": "vinicius@email.com",
  "password": "SenhaForte123!"
}
```

Response 200:

```json
{
  "accessToken": "jwt",
  "expiresInSeconds": 3600,
  "user": {
    "id": "uuid",
    "name": "Vinicius",
    "email": "vinicius@email.com"
  }
}
```

## Validacoes minimas da senha

- minimo de 8 caracteres
- ao menos 1 letra maiuscula
- ao menos 1 letra minuscula
- ao menos 1 numero
- ao menos 1 caractere especial

## Erros padronizados

### Cadastro invalido

- `400 Bad Request`
- corpo com erros por campo

### Credenciais invalidas

- `401 Unauthorized`
- mensagem generica

### E-mail ja cadastrado

- `409 Conflict`
- mensagem clara sem exposicao indevida

## Riscos e cuidados

- nao adicionar refresh token mal desenhado por pressa
- nao deixar a validacao de senha apenas no app
- nao criar JWT sem expiracao
- nao compartilhar modelos de dominio diretamente com a API

## Recomendacao para Sprint 2

Implementar bem:

- cadastro
- login
- logout local
- armazenamento seguro do token

Postergar com tranquilidade:

- refresh token
- social login
- MFA
