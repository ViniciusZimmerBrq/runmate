# Sprint 3 - Cards Para GitHub Projects

Crie uma issue por card abaixo e aplique os campos sugeridos no GitHub Projects.

## US-301 - Implementar emissao de JWT real no backend

**Title**  
US-301 - Implementar emissao de JWT real no backend

**Suggested fields**  
- Status: Ready
- Priority: P1 High
- Sprint: Sprint 3
- Area: Backend
- Primary Agent: Backend Dev
- Secondary Agent: Security
- Risk: Security

**Body**

```md
## Objetivo
Como sistema, quero emitir um token JWT real para autenticar usuarios com seguranca.

## Problema
Hoje a API retorna token fake e isso impede autenticacao real e segura.

## Escopo
### Dentro
- gerar JWT real
- usar issuer, audience e expiracao
- retornar payload minimo da sessao

### Fora
- refresh token
- social login
- MFA

## Criterios de aceite
- [ ] JWT real e gerado com JWT__Secret
- [ ] token possui expiracao definida
- [ ] token possui issuer e audience
- [ ] resposta nao expone dados sensiveis
- [ ] API falha em ambiente nao-dev sem secret configurado

## Regras de negocio
- segredo nao pode estar no codigo
- token deve conter apenas claims necessarios

## Casos de borda
- secret ausente
- config invalida de JWT

## Riscos
- token sem expiracao
- secret mal configurado
```

## US-302 - Implementar cadastro real de usuario no backend

**Title**  
US-302 - Implementar cadastro real de usuario no backend

**Suggested fields**  
- Status: Ready
- Priority: P1 High
- Sprint: Sprint 3
- Area: Backend
- Primary Agent: Backend Dev
- Secondary Agent: QA
- Risk: Security

**Body**

```md
## Objetivo
Como corredor, quero criar uma conta para acessar o app com meus dados.

## Problema
O endpoint atual e apenas mock e nao persiste usuario real.

## Escopo
### Dentro
- validar nome, e-mail e senha
- impedir e-mail duplicado
- persistir usuario
- armazenar hash da senha

### Fora
- confirmacao por e-mail
- recuperacao de senha

## Criterios de aceite
- [ ] cadastro valida campos obrigatorios
- [ ] e-mail duplicado retorna 409
- [ ] senha invalida retorna 400
- [ ] senha nunca e salva em texto puro
- [ ] resposta nao retorna senha nem hash

## Regras de negocio
- e-mail deve ser normalizado
- senha deve seguir a politica definida

## Casos de borda
- e-mail com caixa alta
- senha fraca
- nome vazio
```

## US-303 - Implementar login real no backend

**Title**  
US-303 - Implementar login real no backend

**Suggested fields**  
- Status: Ready
- Priority: P1 High
- Sprint: Sprint 3
- Area: Backend
- Primary Agent: Backend Dev
- Secondary Agent: Security
- Risk: Security

**Body**

```md
## Objetivo
Como corredor, quero fazer login para acessar minha area autenticada.

## Problema
Hoje o login nao valida credenciais reais.

## Escopo
### Dentro
- validar e-mail e senha
- comparar hash da senha
- emitir token real
- retornar sessao

### Fora
- refresh token
- remember me

## Criterios de aceite
- [ ] credenciais validas retornam token e usuario
- [ ] credenciais invalidas retornam 401
- [ ] mensagem de erro e generica
- [ ] senha nao aparece em logs

## Regras de negocio
- nao vazar existencia do e-mail
- usar verificacao baseada em hash
```

## US-304 - Criar telas reais de login e cadastro no Flutter

**Title**  
US-304 - Criar telas reais de login e cadastro no Flutter

**Suggested fields**  
- Status: Ready
- Priority: P1 High
- Sprint: Sprint 3
- Area: Flutter
- Primary Agent: Flutter Dev
- Secondary Agent: UX/UI
- Risk: Security

**Body**

```md
## Objetivo
Como usuario, quero telas reais de login e cadastro para acessar o app com clareza.

## Problema
As telas atuais sao placeholders e nao permitem fluxo real.

## Escopo
### Dentro
- login page
- register page
- validacao local
- loading e erro

### Fora
- biometria
- onboarding complexo

## Criterios de aceite
- [ ] formulario de login existe
- [ ] formulario de cadastro existe
- [ ] validacao local funciona
- [ ] loading e erro estao tratados
- [ ] senha pode ser ocultada e mostrada
```

## US-305 - Integrar Flutter com API real de auth

**Title**  
US-305 - Integrar Flutter com API real de auth

**Suggested fields**  
- Status: Ready
- Priority: P1 High
- Sprint: Sprint 3
- Area: Flutter
- Primary Agent: Flutter Dev
- Secondary Agent: Backend Dev
- Risk: Dependency

**Body**

```md
## Objetivo
Como app, quero usar a API real de autenticacao para funcionar sem mocks.

## Problema
Sem integracao real, a auth continua apenas estrutural.

## Escopo
### Dentro
- consumir login real
- consumir cadastro real
- mapear DTOs
- tratar erros 400, 401 e 409

### Fora
- refresh token
- retry sofisticado

## Criterios de aceite
- [ ] login chama endpoint real
- [ ] cadastro chama endpoint real
- [ ] erros comuns sao tratados
- [ ] entity de sessao e preenchida corretamente
```

## US-306 - Persistir sessao autenticada no app

**Title**  
US-306 - Persistir sessao autenticada no app

**Suggested fields**  
- Status: Ready
- Priority: P1 High
- Sprint: Sprint 3
- Area: Flutter
- Primary Agent: Flutter Dev
- Secondary Agent: Security
- Risk: Security

**Body**

```md
## Objetivo
Como usuario, quero continuar autenticado sem precisar logar toda vez.

## Problema
Sem persistencia local, a experiencia fica quebrada.

## Escopo
### Dentro
- salvar token
- salvar dados minimos da sessao
- recuperar sessao
- limpar sessao no logout

### Fora
- refresh token automatico

## Criterios de aceite
- [ ] token e salvo em storage seguro
- [ ] dados minimos da sessao sao persistidos
- [ ] logout remove sessao
- [ ] sessao pode ser recuperada ao abrir o app
```

## US-307 - Proteger navegacao por estado de sessao

**Title**  
US-307 - Proteger navegacao por estado de sessao

**Suggested fields**  
- Status: Ready
- Priority: P2 Medium
- Sprint: Sprint 3
- Area: Flutter
- Primary Agent: Flutter Dev
- Secondary Agent: QA
- Risk: Dependency

**Body**

```md
## Objetivo
Como usuario, quero entrar no fluxo certo do app dependendo da minha sessao.

## Problema
Sem decisao de navegacao baseada em sessao, o app fica inconsistente.

## Escopo
### Dentro
- bootstrap da sessao
- redirecionamento para auth
- redirecionamento para home
- logout redireciona corretamente

### Fora
- deep links complexos

## Criterios de aceite
- [ ] usuario autenticado entra no fluxo protegido
- [ ] usuario sem sessao vai para auth
- [ ] logout redireciona corretamente
- [ ] sessao invalida cai em auth com seguranca
```
