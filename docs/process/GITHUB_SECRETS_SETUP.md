# GitHub Secrets Setup - RunMate

## Objetivo

Registrar quais secrets reais existem no repositório e como eles devem ser usados.

## Secrets configurados agora

### `JWT_SECRET`

Uso:

- segredo de assinatura do JWT no backend
- deve ser lido como `JWT__Secret` em runtime

Regras:

- nunca copiar para `appsettings.json`
- nunca expor em logs
- trocar o valor se houver suspeita de vazamento

## Secrets recomendados para a proxima fase

### `BACKEND_CONNECTION_STRING`

Uso:

- conexao do banco do backend

### `JWT_ISSUER`

Uso:

- opcional, caso voce queira mover issuer para secret ou variable

### `JWT_AUDIENCE`

Uso:

- opcional, caso voce queira mover audience para secret ou variable

## Estrategia recomendada

- segredos sensiveis em `GitHub Secrets`
- valores nao sensiveis e mais estaveis podem ficar em `appsettings.json` ou GitHub Variables
- no deploy real, mapear `JWT_SECRET` para `JWT__Secret`

## Checklist

- `JWT_SECRET` configurado no repositório
- backend preparado para ler `JWT__Secret`
- exemplos locais criados sem segredo real
