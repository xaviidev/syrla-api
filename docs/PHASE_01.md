# Syrla - Fase 1

## Objetivo da Fase

Construir a primeira versão funcional da API da Syrla utilizando ASP.NET Core, Entity Framework Core, MySQL e autenticação JWT.

---

# Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- MySQL
- JWT
- BCrypt
- Swagger

---

# Entregas da Fase

## Entrega 1

Criação da API ASP.NET Core.

### Objetivos

- Estruturar projeto
- Configurar ambiente
- Criar primeira execução

### Resultado

Projeto inicial criado com sucesso.

---

## Entrega 2

Configuração do banco de dados.

### Objetivos

- Configurar MySQL
- Configurar Entity Framework
- Criar DbContext

### Resultado

Banco integrado à aplicação.

---

## Entrega 3

Criação da entidade User.

### Campos

- Id
- Name
- Email
- PasswordHash

### Resultado

Primeira entidade persistida no banco.

---

## Entrega 4

Autenticação JWT.

### Objetivos

- Login
- Geração de Token
- Proteção de rotas

### Resultado

Autenticação funcional.

---

## Entrega 5

Criptografia de senhas.

### Tecnologia

BCrypt

### Resultado

Senhas não são armazenadas em texto puro.

---

# Problemas Encontrados

## Problema 1

Inconsistências de namespace.

### Causa

Movimentação de arquivos durante a evolução da arquitetura.

### Solução

Padronização dos namespaces.

---

## Problema 2

Erros de compilação durante refatorações.

### Solução

Validação contínua utilizando:

```bash
dotnet build
```

---

# Lições Aprendidas

- Validar build a cada alteração.
- Não realizar múltiplas refatorações simultaneamente.
- Priorizar arquitetura antes de deploy.
- Manter documentação atualizada.

---

# Resultado da Fase 1

## Status

Concluída com sucesso.

### Entregas

- API funcional
- Banco integrado
- JWT
- BCrypt
- Swagger
- Persistência de usuários
