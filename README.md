# 🚀 Syrla

Plataforma de Inteligência Artificial, Automação e Gestão de Conhecimento construída com ASP.NET Core 8.

---

# 📖 Sobre o Projeto

A Syrla nasceu com o objetivo de centralizar conhecimento, automação de processos, autenticação, gestão de usuários e futuramente agentes inteligentes especializados.

O projeto está sendo desenvolvido seguindo princípios de:

* Clean Architecture
* SOLID
* Repository Pattern
* Dependency Injection
* Domain Driven Design (DDD)
* Segurança por padrão

---

# 🌐 Ambiente de Produção

API publicada e disponível em:

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

# 🏗️ Arquitetura

Estrutura atual:

```txt
Cliente
   ↓
Render
   ↓
Docker
   ↓
ASP.NET Core 8
   ↓
Railway MySQL
```

Arquitetura interna:

```txt
API
↓
Application
↓
Domain
↓
Infrastructure
```

Documentação detalhada:

```txt
docs/ARCHITECTURE.md
```

---

# 🔐 Segurança

Atualmente a plataforma utiliza:

* JWT Authentication
* BCrypt Password Hashing
* Middleware Global de Exceções
* DTOs para proteção de contratos
* Variáveis de Ambiente
* Entity Framework Core

---

# 🧪 Qualidade

Ferramentas implementadas:

* xUnit
* Moq
* FluentAssertions

Testes implementados:

* CreateUserAsync_DeveCriarUsuario
* GetUsersAsync_DeveRetornarUsuarios

---

# 🗂️ Estrutura do Projeto

```txt
Syrla.Api
│
├── API
│   ├── Controllers
│   └── Middlewares
│
├── Application
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Domain
│   └── Entities
│
├── Infrastructure
│   ├── Authentication
│   ├── Data
│   └── Repositories
│
├── Migrations
├── docs
└── Tests
```

---

# ☁️ Infraestrutura

## Render

Responsável por:

* Hospedagem da API
* Deploy Automático
* Logs
* Ambiente de Produção

## Railway

Responsável por:

* Banco MySQL
* Persistência de Dados
* Rede Privada
* Variáveis de Ambiente

## GitHub

Responsável por:

* Versionamento
* Controle de Código
* Integração Contínua

---

# 📚 Documentação

## Arquitetura

```txt
docs/ARCHITECTURE.md
```

## Roadmap

```txt
docs/ROADMAP.md
```

## Histórico das Fases

```txt
docs/PHASE_01.md
docs/PHASE_02.md
docs/PHASE_03.md
```

## Deploy

```txt
docs/DEPLOYMENT.md
```

## Decisões Arquiteturais

```txt
docs/DECISIONS.md
```

## Troubleshooting

```txt
docs/TROUBLESHOOTING.md
```

---

# 🚀 Status Atual

## Fase 1

✅ Concluída

Entregas:

* ASP.NET Core 8
* Entity Framework Core
* MySQL
* JWT
* BCrypt

---

## Fase 2

✅ Concluída

Entregas:

* Clean Architecture
* Repository Pattern
* DTOs
* ApiResponse
* Middleware Global
* Testes Unitários

---

## Fase 3

✅ Concluída

Entregas:

* Docker
* GitHub
* Render
* Railway
* Deploy em Produção
* Swagger
* Health Check
* CI/CD

---

## Fase 4

🚀 Em Planejamento

Objetivos:

* Authorization
* Claims
* Roles
* Endpoint /me
* Segurança Avançada

---

# 🛣️ Próximas Evoluções

* Roles
* Policies
* Refresh Tokens
* Redis
* RabbitMQ
* Auditoria
* Observabilidade
* Agentes Inteligentes

---

# 👨‍💻 Desenvolvimento

Projeto idealizado e desenvolvido por Xavii.

---

# 📄 Licença

Em definição.

---

# 📌 Versão Atual

```txt
v0.1.0
```

Status:

```txt
Produção Ativa ✅
```
