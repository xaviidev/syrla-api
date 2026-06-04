# GUIA DE DEPLOY

## Visão Geral

Este documento descreve a infraestrutura atual da Syrla, o fluxo de deploy, a integração com GitHub, Render e Railway, além de procedimentos de manutenção e recuperação.

---

# Informações do Projeto

Aplicação:

```txt
Syrla API
```

Tecnologias:

* ASP.NET Core 8
* Entity Framework Core
* MySQL
* JWT Authentication
* BCrypt
* Docker
* Render
* Railway
* GitHub

Repositório:

```txt
https://github.com/xaviidev/syrla-api
```

---

# Arquitetura Atual

```txt
Desenvolvedor
      ↓
   GitHub
      ↓
   Render
      ↓
Container Docker
      ↓
ASP.NET Core 8
      ↓
Railway MySQL
```

---

# Ambiente de Produção

API:

```txt
https://syrla-api.onrender.com
```

Swagger:

```txt
https://syrla-api.onrender.com/swagger
```

Health Check:

```txt
https://syrla-api.onrender.com/health
```

---

# Fluxo de Deploy

## Desenvolvimento Local

Compilar:

```bash
dotnet build
```

Executar:

```bash
dotnet run
```

Executar testes:

```bash
dotnet test
```

---

## Versionamento

Verificar alterações:

```bash
git status
```

Adicionar alterações:

```bash
git add .
```

Criar commit:

```bash
git commit -m "descrição"
```

Enviar para o GitHub:

```bash
git push
```

---

## Deploy Automático

Todo push para a branch principal dispara automaticamente um novo deploy.

Fluxo:

```txt
Git Push
    ↓
GitHub
    ↓
Render
    ↓
Build Docker
    ↓
Deploy
    ↓
Produção
```

---

# Docker

Dockerfile atual:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Syrla.Api.dll"]
```

---

# Banco de Dados

## Plataforma

Railway

Banco:

```txt
railway
```

Engine:

```txt
MySQL
```

---

## Entity Framework

Migrações aplicadas:

```txt
InitialCreate
AddPasswordHash
```

Tabelas atuais:

```txt
Users
__EFMigrationsHistory
```

---

# Variáveis de Ambiente

## Render

Variáveis obrigatórias:

```env
ASPNETCORE_URLS=http://+:8080

JwtSettings__SecretKey=CHAVE_JWT

ConnectionStrings__DefaultConnection=STRING_CONEXAO
```

---

## Connection String

Formato utilizado:

```txt
server=HOST;
port=PORTA;
database=railway;
user=root;
password=SENHA
```

---

# Endpoints de Produção

## Root

```http
GET /
```

Retorna informações básicas da aplicação.

---

## Health Check

```http
GET /health
```

Utilizado para monitoramento e validação da infraestrutura.

---

## Swagger

```http
GET /swagger
```

Documentação da API.

---

## Weather Forecast

```http
GET /weatherforecast
```

Endpoint de teste.

---

# Checklist de Verificação

Verificar:

* API online
* Banco online
* Swagger disponível
* Health Check disponível
* Deploy concluído
* Logs sem erros críticos

---

# Recuperação de Falhas

## Rollback

Identificar o último commit estável:

```bash
git log
```

Reverter:

```bash
git revert COMMIT_ID
git push
```

O Render iniciará automaticamente um novo deploy.

---

# Troubleshooting

## Erro de Conexão com Banco

Verificar:

* Variáveis de ambiente
* Host
* Porta
* Usuário
* Senha

---

## Erro 500

Verificar:

* Logs do Render
* Logs do Entity Framework
* Banco de dados
* Migrations

---

## Swagger Indisponível

Verificar:

```csharp
app.UseSwagger();
app.UseSwaggerUI();
```

---

## Deploy Falhou

Verificar:

* Dockerfile
* Build do .NET
* Variáveis de ambiente
* Logs do Render

---

# Lições Aprendidas

Durante a Fase 03 foram adquiridos conhecimentos práticos sobre:

* Docker
* Deploy em nuvem
* GitHub Actions de CI/CD via Render
* Railway MySQL
* Entity Framework Migrations
* Variáveis de ambiente
* Diagnóstico de erros em produção

---

# Status Atual

Versão:

```txt
v0.1.0
```

Ambiente:

```txt
Produção
```

Plataforma:

```txt
Render + Railway
```

Status:

```txt
Operacional ✅
```
