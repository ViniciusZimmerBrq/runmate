# Sprint 3 - Implementacao de Autenticacao Real

## Objetivo da sprint

Entregar autenticacao real de ponta a ponta no RunMate, com backend seguro, telas reais no Flutter, sessao persistida e navegacao protegida.

## Resultado esperado

Ao final da sprint, o usuario deve conseguir:

- se cadastrar com validacoes reais
- fazer login com credenciais validas
- receber sessao autenticada real
- manter a sessao no app
- fazer logout
- entrar no fluxo certo ao abrir o app

## Foco da sprint

Esta sprint nao busca volume de funcionalidades. Ela busca:

- autenticacao correta
- estrutura limpa
- contratos claros
- seguranca minima bem implementada

## Historias da sprint

### US-301 - Implementar emissao de JWT real no backend

User story:

Como sistema, quero emitir um token JWT real para autenticar usuarios com seguranca.

Contexto:

A API hoje retorna token fake. Precisamos trocar isso por emissao real baseada em configuracao segura.

Criterios de aceite:

- backend gera JWT real assinado com `JWT__Secret`
- token possui `issuer` e `audience`
- token possui expiracao definida
- payload retornado contem dados minimos da sessao
- API falha ao subir em ambiente nao-dev sem secret configurado

Regras de negocio:

- o segredo do JWT nao pode vir do codigo-fonte
- o token nao deve carregar informacoes sensiveis desnecessarias
- expiracao inicial deve ser curta e previsivel

Dependencias:

- `JWT_SECRET` configurado no repositório
- classe de configuracao JWT pronta

Duvidas abertas:

- definir duracao final do token no MVP

### US-302 - Implementar cadastro real de usuario no backend

User story:

Como corredor, quero criar uma conta para acessar o app com meus dados.

Contexto:

O endpoint existe apenas como mock. Precisamos validar dados, garantir unicidade e persistir o usuario.

Criterios de aceite:

- endpoint de cadastro valida nome, e-mail e senha
- e-mail duplicado retorna `409 Conflict`
- senha fora da politica minima retorna `400 Bad Request`
- cadastro persiste usuario de forma segura
- senha e armazenada apenas como hash

Regras de negocio:

- e-mail deve ser normalizado
- senha deve respeitar a politica definida na arquitetura
- resposta nao deve retornar senha nem hash

Dependencias:

- servico de hash
- mecanismo minimo de persistencia

Duvidas abertas:

- persistencia inicial sera memoria temporaria ou banco local

### US-303 - Implementar login real no backend

User story:

Como corredor, quero fazer login para acessar minha area autenticada.

Contexto:

O login deve validar credenciais reais e retornar sessao consistente para o app.

Criterios de aceite:

- login recebe e-mail e senha
- credenciais validas retornam token e dados do usuario
- credenciais invalidas retornam `401 Unauthorized`
- mensagem de erro e generica
- login nao vaza se o e-mail existe ou nao alem do necessario

Regras de negocio:

- verificacao deve usar o hash armazenado
- logs nao podem expor senha

Dependencias:

- cadastro real ou base de usuario valida
- emissao de JWT

Duvidas abertas:

- nenhuma critica para MVP

### US-304 - Criar telas reais de login e cadastro no Flutter

User story:

Como usuario, quero telas reais de login e cadastro para acessar o app com clareza e seguranca.

Contexto:

Hoje as telas de auth sao placeholders. Precisamos construir a experiencia real.

Criterios de aceite:

- existe tela real de login
- existe tela real de cadastro
- formularios validam campos localmente
- loading, erro e sucesso estao tratados
- mensagens de erro sao claras e nao tecnicas

Regras de negocio:

- campos obrigatorios devem ser destacados
- senha deve ter comportamento de ocultar/mostrar
- e-mail deve ser validado antes do submit

Dependencias:

- contrato da API definido
- componentes base de auth disponiveis

Duvidas abertas:

- manter design inicial minimalista ou ampliar identidade visual

### US-305 - Integrar Flutter com API de auth real

User story:

Como app, quero consumir a API de autenticacao real para deixar de depender de mocks.

Contexto:

Com backend real, a feature auth do app deve trocar o mock pela integracao de verdade.

Criterios de aceite:

- datasource remoto chama endpoints reais
- DTOs mapeiam respostas corretamente
- erros `400`, `401` e `409` sao tratados
- repository devolve entidades de dominio coerentes

Regras de negocio:

- camada de UI nao conhece detalhes do HTTP
- tratamento de erro deve ser centralizado o suficiente para evoluir

Dependencias:

- endpoints reais disponiveis

Duvidas abertas:

- definir biblioteca HTTP na implementacao final

### US-306 - Persistir sessao autenticada no app

User story:

Como usuario, quero continuar autenticado para nao precisar fazer login toda vez.

Contexto:

Depois do login, o app precisa armazenar sessao local de forma segura.

Criterios de aceite:

- token e salvo em storage seguro
- dados minimos da sessao sao persistidos
- logout limpa sessao local
- app consegue recuperar sessao ao iniciar

Regras de negocio:

- senha nao pode ser salva localmente
- storage usado deve ser apropriado para dado sensivel

Dependencias:

- login real funcionando

Duvidas abertas:

- escolher storage seguro final do Flutter

### US-307 - Proteger navegacao por estado de sessao

User story:

Como usuario, quero entrar direto na area correta do app dependendo do meu estado de autenticacao.

Contexto:

Com sessao persistida, o app precisa decidir corretamente entre fluxo autenticado e fluxo publico.

Criterios de aceite:

- app verifica sessao ao iniciar
- usuario autenticado entra no fluxo protegido
- usuario sem sessao vai para login
- sessao invalida e tratada com redirecionamento seguro

Regras de negocio:

- a decisao de navegacao nao deve ficar espalhada em varias telas

Dependencias:

- persistencia de sessao
- estrutura basica de navegacao

Duvidas abertas:

- splash dedicada ou bootstrap simples

## Tarefas por papel

### PM

- proteger o foco da sprint em autenticacao
- impedir entrada de dashboard e treino nesta sprint

### PO

- quebrar historias em tarefas pequenas
- alinhar criterios entre Flutter, backend e QA

### Tech Lead

- fechar contrato final dos endpoints
- aprovar estrategia de persistencia inicial
- aprovar formato da sessao autenticada

### Security Agent

- revisar hashing de senha
- revisar duracao e claims do JWT
- revisar armazenamento local no app

### Backend C# Agent

- implementar gerador de JWT
- implementar hash de senha
- implementar cadastro e login reais
- organizar validacoes e erros

### Flutter Dev Agent

- implementar telas reais
- integrar datasource remoto
- persistir sessao local
- proteger navegacao

### UX/UI Agent

- revisar fluxo de auth
- revisar estados de formulario, erro e sucesso

### QA Agent

- criar cenarios de cadastro
- criar cenarios de login
- validar estados de sessao e logout

## Ordem recomendada de execucao

1. fechar contrato final de auth
2. implementar backend auth real
3. validar erros e respostas
4. implementar telas reais no Flutter
5. integrar Flutter com backend
6. persistir sessao
7. proteger navegacao
8. validar fim a fim

## Definition of done

- backend gera JWT real
- cadastro real funciona
- login real funciona
- Flutter usa API real
- sessao e persistida
- logout funciona
- navegacao decide corretamente
- CI continua verde

## Fora do escopo

- social login
- refresh token completo
- redefinicao de senha
- confirmacao por e-mail
- MFA
- dashboard real
- cadastro de treino

## Riscos principais

- tentar introduzir banco definitivo cedo demais
- acoplar UI a detalhes de erro HTTP
- armazenar sessao de forma insegura
- deixar regras de senha inconsistentes entre app e backend

## Recomendacao tecnica

Para reduzir risco nesta sprint:

- usar persistencia inicial simples no backend se necessario
- manter JWT simples e correto
- priorizar integracao funcionando antes de sofisticar arquitetura

## Entregas candidatas para Sprint 4

- cadastro manual de treino
- historico real de treinos
- dashboard com dados reais
