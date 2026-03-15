# Squad Daily Ritual - RunMate

## Objetivo

Definir um ritual diario simples para o squad operar a sprint com visibilidade, ownership e baixo ruido.

## Formato recomendado

O ritual deve ser async e curto.

Cada atualizacao precisa responder:

- o que mudou
- o que vem agora
- o que trava

## Janela recomendada

- inicio do dia: atualizar `Status` no board
- daily async: registrar contexto do dia
- fim do dia: deixar proximo passo claro

## Atualizacao oficial do squad

Use este template:

```text
Sprint:
Objetivo da sprint:

Avanco desde ontem:

Foco de hoje:

Bloqueios:

Itens que precisam de decisao:
```

## Atualizacao por papel

### PM

```text
Contexto:

Decisao:

Risco de escopo:

Proximo handoff:
```

### PO

```text
Historias prontas:

Historias com ambiguidade:

Dependencias abertas:

Proximo handoff:
```

### Tech Lead

```text
Decisoes tecnicas do dia:

Riscos tecnicos:

Itens que podem ser puxados:

Proximo handoff:
```

### Flutter Dev

```text
Item em andamento:

O que foi implementado:

O que falta:

Bloqueio:

Proximo handoff:
```

### Backend Dev

```text
Item em andamento:

O que foi implementado:

O que falta:

Bloqueio:

Proximo handoff:
```

### QA

```text
Itens em validacao:

Resultado:

Bugs ou riscos:

Proximo handoff:
```

### Security

```text
Itens revisados:

Riscos:

Mitigacoes:

Proximo handoff:
```

## Regras do ritual

- atualizar o board antes da mensagem
- nao esconder bloqueio
- nao usar texto longo se o board ja responde parte do contexto
- toda mensagem deve deixar um dono claro para o proximo passo

## Sinais de squad saudavel

- poucos itens em `In Progress`
- bloqueios aparecem cedo
- `Ready` esta realmente pronto
- QA nao recebe entrega sem contexto
- PR nao chega sem descricao clara
