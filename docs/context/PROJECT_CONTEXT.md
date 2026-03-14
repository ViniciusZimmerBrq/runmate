# Project Context - RunMate

## Visao do produto

RunMate e um app mobile para corredores acompanharem treinos, evolucao, metas e consistencia semanal.

## Objetivo atual

Construir um MVP com arquitetura limpa, fluxo de desenvolvimento previsivel e base segura para autenticacao.

## Fase atual

Sprint 2 - foco total em `Login` e `Cadastro`.

## Objetivos da Sprint 2

- desenhar autenticacao segura de ponta a ponta
- alinhar arquitetura entre Flutter e ASP.NET Core
- padronizar pastas, contextos e responsabilidades dos agentes
- reduzir ambiguidade antes da implementacao

## Usuario principal

Corredor amador que quer registrar treinos e acompanhar sua evolucao de forma simples.

## Funcionalidades que importam agora

- cadastro com validacao forte
- login seguro
- sessao autenticada
- logout
- tratamento claro de erros de autenticacao

## Fora de escopo nesta sprint

- login social
- recuperacao de senha por e-mail
- MFA
- refresh token com rotacao completa
- biometria

## Regras gerais de arquitetura

- frontend em Flutter organizado por feature
- backend em C# organizado por camadas
- contratos claros entre app e API
- nenhuma regra de negocio importante na camada de UI
- seguranca e validacao como parte da arquitetura, nao como detalhe tardio

## Padroes de qualidade

- nomes consistentes
- separacao clara de responsabilidades
- testabilidade desde o desenho
- documentacao curta e objetiva
- evolucao incremental sem sobreengenharia
