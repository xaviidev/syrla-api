# 🚀 Syrla

Plataforma de Inteligência Artificial, Automação e Gestão de Conhecimento construída com ASP.NET Core.

---

## 📖 Sobre o Projeto

A Syrla nasceu com o objetivo de ser uma plataforma capaz de centralizar conhecimento, automação de processos, autenticação, gestão de usuários e futuramente agentes inteligentes especializados.

O projeto está sendo desenvolvido seguindo princípios de:

* Clean Architecture
* SOLID
* Repository Pattern
* Dependency Injection
* Domain Driven Design (DDD)
* Segurança por padrão

---

## 🏗️ Arquitetura

Estrutura atual:

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

## 🔐 Segurança

Atualmente a plataforma utiliza:

* JWT Authentication
* BCrypt Password Hashing
* Middleware Global de Exceções
* DTOs para proteção de contratos

---

## 🧪 Qualidade

Ferramentas implementadas:

* xUnit
* Moq
* FluentAssertions

Testes implementados:

* CreateUserAsync_DeveCriarUsuario
* GetUsersAsync_DeveRetornarUsuarios

---

## 🗂️ Estrutura do Projeto

```txt
Syrla.Api
│
├── API
│   ├── Controllers
│   └── Middlewares
│
├── Application
│   ├── Common
│   ├── DTOs
│   ├── Interfaces
│   └── Services
│
├── Domain
│   ├── Entities
│   └── Interfaces
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

## 📚 Documentação

### Arquitetura

```txt
docs/ARCHITECTURE.md
```

### Histórico

```txt
docs/PHASE_01.md
docs/PHASE_02.md
```

### Troubleshooting

```txt
docs/TROUBLESHOOTING.md
```

### Decisões Arquiteturais

```txt
docs/DECISIONS.md
```

### Roadmap

```txt
docs/ROADMAP.md
```

---

## 🚀 Status do Projeto

### Fase 1

✅ Concluída

* API ASP.NET Core
* Entity Framework Core
* MySQL
* JWT
* BCrypt

---

### Fase 2

✅ Concluída

* Clean Architecture
* Repository Pattern
* DTOs
* ApiResponse
* Middleware Global
* Testes Unitários

---

### Fase 3

🔄 Planejada

* Oracle Cloud
* Docker Compose
* Nginx
* SSL
* Deploy

---

## 🛣️ Roadmap

Próximas evoluções:

* Redis
* RabbitMQ
* Observabilidade
* Auditoria
* Roles e Policies
* Refresh Tokens
* Agentes Inteligentes

---

## 👨‍💻 Equipe

Projeto idealizado e desenvolvido por Xavii.

---

## 📄 Licença

Em definição.
