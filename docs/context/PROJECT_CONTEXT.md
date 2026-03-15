# Project Context - RunMate

## Visao do produto

RunMate e um app mobile para corredores acompanharem treinos, evolucao, metas e consistencia semanal.

## Objetivo atual

Construir um MVP com arquitetura limpa, fluxo de desenvolvimento previsivel e base segura para autenticacao.

## Fase atual

Sprint 2 — Auth end-to-end (backend JWT + telas Flutter + integração + sessão + navegação).

## Stories da Sprint 2

| Issue | Story | Status |
|-------|-------|--------|
| [#2](https://github.com/ViniciusZimmerBrq/runmate/issues/2) | US-301 - Emissão de JWT real | Ready |
| [#3](https://github.com/ViniciusZimmerBrq/runmate/issues/3) | US-302 - Cadastro de usuário no backend | Ready |
| [#4](https://github.com/ViniciusZimmerBrq/runmate/issues/4) | US-303 - Login real no backend | Ready |
| [#5](https://github.com/ViniciusZimmerBrq/runmate/issues/5) | US-304 - Telas de login e cadastro Flutter | Ready |
| [#6](https://github.com/ViniciusZimmerBrq/runmate/issues/6) | US-305 - Integrar Flutter com API de auth | Ready |
| [#7](https://github.com/ViniciusZimmerBrq/runmate/issues/7) | US-306 - Persistir sessão autenticada | Ready |
| [#8](https://github.com/ViniciusZimmerBrq/runmate/issues/8) | US-307 - Proteger navegação por sessão | Ready |

Processo de execução: [`docs/process/SPRINT_EXECUTION.md`](../process/SPRINT_EXECUTION.md)

## Objetivos da Sprint 2

- auth segura de ponta a ponta (JWT real, cadastro, login)
- telas Flutter conectadas à API real
- sessão persistida e navegação protegida

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
