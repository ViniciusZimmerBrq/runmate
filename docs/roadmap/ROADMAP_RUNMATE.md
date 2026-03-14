# Roadmap - RunMate

## Objetivo

Organizar a evolucao do RunMate em uma sequencia clara, segura e fluida, mantendo foco em arquitetura boa, autenticacao confiavel e entregas pequenas.

## Direcao geral

Ordem recomendada:

1. fechar a fundacao tecnica
2. implementar autenticacao real de ponta a ponta
3. conectar sessao autenticada no app
4. construir o primeiro fluxo real de negocio
5. evoluir qualidade, observabilidade e release

## Prioridade atual

Depois do merge da branch de auth/env, o passo mais importante e:

`implementar autenticacao real no backend e conectar isso ao Flutter`

Motivo:

- ja existe base de secrets e governanca
- ja existe estrutura da feature `auth`
- isso destrava o resto do produto
- evita construir dashboard e treinos em cima de autenticacao fake

## Roadmap por fase

### Fase 1 - Fundacao de Auth

Status:

- em andamento

Objetivo:

ter login e cadastro reais, seguros e testaveis

Entregas:

- gerar JWT real no backend com `JWT_SECRET`
- validar credenciais no backend
- definir erros padronizados de auth
- criar telas reais de login e cadastro no Flutter
- tratar loading, erro e sucesso
- armazenar sessao local com storage seguro

Definition of done:

- usuario consegue se cadastrar
- usuario consegue fazer login
- app persiste sessao local
- logout funciona
- backend nao depende de token fake

### Fase 2 - Sessao e Navegacao Protegida

Objetivo:

fazer o app se comportar como produto autenticado

Entregas:

- splash/check de sessao
- guard de rota autenticada
- redirecionamento login -> home
- redirecionamento sem sessao -> auth
- expiracao de sessao tratada de forma previsivel

Definition of done:

- app abre e decide corretamente para onde ir
- usuario autenticado nao volta para login sem motivo
- sessao invalida leva para login com tratamento claro

### Fase 3 - Primeiro Fluxo de Negocio

Objetivo:

entregar a primeira funcionalidade central do app de corrida

Recomendacao:

comecar por `cadastro manual de treino`

Entregas:

- criar treino manual
- listar historico de treinos
- salvar distancia, duracao, data e observacoes
- calcular e exibir pace

Definition of done:

- usuario autenticado consegue registrar treino
- treino aparece no historico
- regras basicas de validacao funcionam

### Fase 4 - Dashboard Inicial Real

Objetivo:

substituir dados estaticos por dados reais do usuario

Entregas:

- resumo semanal
- total de distancia
- quantidade de treinos
- pace medio
- meta semanal vs realizado

Definition of done:

- dashboard consome backend real
- estados vazio/loading/erro estao corretos

### Fase 5 - Qualidade e Release Basica

Objetivo:

deixar o projeto pronto para crescer sem perder controle

Entregas:

- testes de widget para auth
- testes backend para login/cadastro
- padronizacao de logs
- ambiente local com banco
- artifacts de release mais consistentes

Definition of done:

- auth possui cobertura basica
- ambiente local reproduzivel
- pipeline confiavel para PR e release

## Sprint sugerida agora

## Sprint 3 - Auth real ponta a ponta

Objetivo:

transformar a fundacao atual em autenticacao funcional

Historias principais:

### US-301 - Gerar JWT real no backend

- configurar emissao de token
- usar `JWT_SECRET`
- retornar payload de sessao consistente

### US-302 - Implementar cadastro real

- validar nome, e-mail e senha
- impedir e-mail duplicado
- persistir usuario

### US-303 - Implementar login real

- validar credenciais
- retornar token e dados do usuario
- tratar `401` e `409`

### US-304 - Criar telas reais de auth no Flutter

- login page
- register page
- validacoes locais
- componentes reutilizaveis

### US-305 - Persistir sessao autenticada no app

- storage seguro
- controller de auth
- logout local

### US-306 - Proteger navegacao

- decidir fluxo de entrada
- guardar acesso a telas autenticadas

## Backlog recomendado apos isso

1. cadastro manual de treino
2. historico de treinos
3. dashboard real
4. metas semanais
5. evolucao e graficos

## O que eu atacaria agora

Se a meta e ganhar tracao sem desorganizar o projeto, eu seguiria nessa ordem:

1. backend auth real
2. telas reais de login e cadastro
3. sessao autenticada no Flutter
4. navegacao protegida

## Riscos de sair dessa ordem

- construir dashboard antes de auth real gera retrabalho
- ligar frontend sem contrato fechado cria acoplamento ruim
- deixar sessao para depois gera navegacao confusa

## Regra de priorizacao

Sempre priorizar o que:

- reduz risco estrutural
- destrava o fluxo principal do usuario
- evita retrabalho nas proximas features
