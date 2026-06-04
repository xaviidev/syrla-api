# Syrla - Arquitetura do Sistema

## Visão Geral

A Syrla é uma plataforma de Inteligência Artificial, automação e gestão de conhecimento construída utilizando ASP.NET Core 8, seguindo princípios de Clean Architecture, SOLID, Dependency Injection e Separation of Concerns.

O objetivo da arquitetura é garantir:

* Escalabilidade
* Baixo acoplamento
* Alta manutenibilidade
* Facilidade de testes
* Segurança
* Evolução contínua

---

# Arquitetura Geral da Plataforma

```txt
Cliente
↓
Render
↓
Docker
↓
API
↓
Application
↓
Domain
↓
Infrastructure
↓
Railway MySQL
```

Cada camada possui responsabilidades específicas e não deve assumir responsabilidades de outras camadas.

---

# Camada API

Localização:

```txt
API/
```

Responsável por:

* Controllers
* Middlewares
* Endpoints HTTP
* Comunicação externa

A camada API não contém regras de negócio.

Ela apenas recebe requisições, encaminha para os serviços adequados e devolve respostas.

---

## Controllers

Localização:

```txt
API/Controllers
```

Responsáveis por:

* Receber requisições HTTP
* Validar entrada
* Invocar serviços
* Retornar respostas

Controllers devem permanecer enxutos.

Toda regra de negócio deve ser executada na camada Application.

---

## Middlewares

Localização:

```txt
API/Middlewares
```

Responsáveis por:

* Interceptar requisições
* Interceptar respostas
* Tratamento global de exceções

Middleware atual:

```txt
ExceptionMiddleware
```

Objetivo:

Padronizar erros da aplicação.

---

# Camada Application

Localização:

```txt
Application/
```

Responsável por:

* Casos de uso
* Serviços
* DTOs
* Contratos

Esta é a camada onde reside a lógica da aplicação.

---

## DTOs

Localização:

```txt
Application/DTOs
```

DTO significa:

```txt
Data Transfer Object
```

Objetivo:

Separar os contratos da API das entidades de domínio.

Exemplo:

```txt
UserResponseDto
```

Evita exposição indevida de:

```txt
PasswordHash
```

---

## Services

Localização:

```txt
Application/Services
```

Responsáveis por:

* Casos de uso
* Regras de aplicação
* Orquestração

Exemplos:

```txt
AuthService
UserService
```

---

## Interfaces

Localização:

```txt
Application/Interfaces
```

Responsáveis por:

* Contratos
* Abstrações

Permitem inversão de dependência.

---

## Common

Localização:

```txt
Application/Common
```

Contém componentes compartilhados.

Exemplo:

```txt
ApiResponse<T>
```

Utilizado para padronizar respostas.

---

# Camada Domain

Localização:

```txt
Domain/
```

Representa o núcleo do negócio.

É a camada mais importante da aplicação.

---

## Entities

Localização:

```txt
Domain/Entities
```

Representam os objetos principais do domínio.

Exemplo:

```txt
User
```

As entidades não devem conhecer infraestrutura.

---

## Interfaces

Localização:

```txt
Domain/Interfaces
```

Reservada para contratos relacionados ao domínio.

---

# Camada Infrastructure

Localização:

```txt
Infrastructure/
```

Responsável por tudo que é externo ao domínio.

---

## Data

Localização:

```txt
Infrastructure/Data
```

Contém:

* AppDbContext
* Configuração EF Core
* Banco de dados

---

## Repositories

Localização:

```txt
Infrastructure/Repositories
```

Implementação dos contratos de persistência.

Padrão utilizado:

```txt
Repository Pattern
```

---

## Authentication

Localização:

```txt
Infrastructure/Authentication
```

Responsável por:

* JWT
* Configurações de autenticação
* JwtSettings

---

# Padrões Arquiteturais Utilizados

## Clean Architecture

Objetivo:

Separar responsabilidades.

Benefícios:

* Testabilidade
* Escalabilidade
* Organização

---

## Dependency Injection

Utilizada para:

* Serviços
* Repositórios
* Configurações

Benefícios:

* Baixo acoplamento
* Facilidade de testes

---

## Repository Pattern

Utilizado para abstrair acesso a dados.

Benefícios:

* Menor dependência do banco
* Facilidade de substituição da persistência

---

## DTO Pattern

Utilizado para:

* Entrada de dados
* Saída de dados

Benefícios:

* Segurança
* Controle dos contratos da API

---

# Segurança

Tecnologias implementadas:

## JWT

Responsável por:

* Autenticação
* Controle de acesso

---

## BCrypt

Responsável por:

* Hash de senhas

Motivo:

Nunca armazenar senhas em texto puro.

---

## Middleware Global

Responsável por:

* Tratamento de erros
* Evitar vazamento de informações internas

---

# Testes

Ferramentas:

```txt
xUnit
Moq
FluentAssertions
```

Objetivo:

Garantir estabilidade da aplicação.

---

# Estrutura Atual

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
│
├── Infrastructure
│   ├── Authentication
│   ├── Data
│   └── Repositories
│
├── Migrations
├── Properties
├── docs
├── Program.cs
└── appsettings.json
```

---

# Próximas Evoluções

## Fase 4 - Autorização e Segurança

* Endpoint GET /api/Auth/me
* Claims JWT
* Roles (User e Admin)
* Rotas protegidas
* Auditoria básica

---

## Fase 5 - Escalabilidade

* Redis
* RabbitMQ
* Background Services
* Cache
* Health Checks Avançados

---

## Fase 6 - Segurança Corporativa

* Refresh Tokens
* Logs Estruturados
* Observabilidade
* Monitoramento

---

## Fase 7 - Ecossistema de IA

* Agentes Inteligentes
* Memória Persistente
* Integração com LLMs
* Base de Conhecimento

---

## Fase 8 - Plataforma Syrla

* Painel Administrativo
* Dashboard
* Gestão de Usuários
* Multiempresa

---

# Status Atual

```txt
Fase 1 ✅
Fase 2 ✅
Fase 3 ✅
Fase 4 🚀
```
