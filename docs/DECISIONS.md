# Syrla - Registro de Decisões Arquiteturais (ADR)

## Objetivo

Registrar as principais decisões arquiteturais tomadas durante a evolução da plataforma Syrla.

---

# ADR-001

## Clean Architecture

### Decisão

Adotar Clean Architecture como padrão estrutural da aplicação.

### Motivo

Separar responsabilidades e reduzir acoplamento entre as camadas.

### Benefícios

* Escalabilidade
* Testabilidade
* Organização
* Facilidade de manutenção

### Status

Aprovado ✅

---

# ADR-002

## Repository Pattern

### Decisão

Utilizar Repository Pattern para abstração do acesso a dados.

### Motivo

Evitar dependência direta do Entity Framework nas camadas superiores.

### Benefícios

* Facilidade para testes
* Menor acoplamento
* Evolução da persistência

### Status

Aprovado ✅

---

# ADR-003

## DTO Pattern

### Decisão

Nunca expor entidades diretamente pela API.

### Motivo

Separar domínio dos contratos externos.

### Benefícios

* Segurança
* Controle dos dados expostos
* Versionamento facilitado

### Status

Aprovado ✅

---

# ADR-004

## BCrypt

### Decisão

Utilizar BCrypt para armazenamento de senhas.

### Motivo

Nunca armazenar senhas em texto puro.

### Benefícios

* Segurança
* Proteção contra vazamento de credenciais

### Status

Aprovado ✅

---

# ADR-005

## JWT Authentication

### Decisão

Utilizar JWT para autenticação.

### Motivo

Arquitetura stateless compatível com APIs modernas.

### Benefícios

* Escalabilidade
* Integração com aplicações externas
* Baixa dependência de sessão

### Status

Aprovado ✅

---

# ADR-006

## Docker

### Decisão

Containerizar a aplicação utilizando Docker.

### Motivo

Padronizar ambientes de desenvolvimento e produção.

### Benefícios

* Deploy simplificado
* Reprodutibilidade
* Escalabilidade
* Facilidade de manutenção

### Status

Implementado ✅

---

# ADR-007

## GitHub como Repositório Principal

### Decisão

Centralizar o código-fonte no GitHub.

### Motivo

Garantir versionamento e integração contínua.

### Benefícios

* Histórico de alterações
* Colaboração futura
* Integração com Render

### Status

Implementado ✅

---

# ADR-008

## Render para Hospedagem da API

### Decisão

Utilizar Render como plataforma principal de hospedagem.

### Motivo

A tentativa inicial utilizando Oracle Cloud encontrou limitações de capacidade na região disponível.

### Benefícios

* Deploy automatizado
* Integração nativa com GitHub
* Facilidade de configuração
* Ambiente gratuito para validação do projeto

### Status

Implementado ✅

---

# ADR-009

## Railway para Banco de Dados

### Decisão

Utilizar Railway para hospedagem do banco MySQL.

### Motivo

Eliminar dependência de banco local e permitir persistência em produção.

### Benefícios

* Banco em nuvem
* Persistência de dados
* Integração simples com Entity Framework
* Gerenciamento simplificado

### Status

Implementado ✅

---

# ADR-010

## Entity Framework Migrations

### Decisão

Controlar a evolução do banco através de migrations.

### Motivo

Garantir versionamento do esquema de dados.

### Benefícios

* Rastreabilidade
* Padronização
* Facilidade de implantação

### Status

Implementado ✅

---

# ADR-011

## Variáveis de Ambiente

### Decisão

Centralizar configurações sensíveis em variáveis de ambiente.

### Motivo

Evitar exposição de credenciais no código-fonte.

### Benefícios

* Segurança
* Facilidade de manutenção
* Adequação para produção

### Status

Implementado ✅

---

# ADR-012

## Redis

### Decisão

Adicionar Redis para cache e otimização de desempenho.

### Motivo

Reduzir carga no banco de dados e melhorar tempo de resposta.

### Benefícios

* Cache distribuído
* Melhor performance
* Escalabilidade

### Status

Planejado 🚀

---

# ADR-013

## RabbitMQ

### Decisão

Utilizar RabbitMQ para comunicação assíncrona.

### Motivo

Preparar a plataforma para processamento distribuído.

### Benefícios

* Escalabilidade
* Resiliência
* Processamento desacoplado

### Status

Planejado 🚀

---

# ADR-014

## Roles e Autorização

### Decisão

Implementar perfis de acesso e autorização baseada em roles.

### Motivo

Permitir controle granular de permissões.

### Benefícios

* Segurança
* Governança
* Escalabilidade organizacional

### Status

Planejado 🚀

---

# ADR-015

## Agentes Inteligentes

### Decisão

Transformar a Syrla em uma plataforma de agentes especializados.

### Motivo

Centralizar automação, conhecimento e tomada de decisão.

### Benefícios

* Produtividade
* Escalabilidade operacional
* Inteligência organizacional

### Status

Planejado 🚀

---

# Histórico de Infraestrutura

## Oracle Cloud

Foi realizada tentativa inicial de implantação utilizando:

* Ubuntu 24.04
* VM.Standard.A1.Flex
* 4 OCPU
* 24 GB RAM

Resultado:

```txt id="y5wwgs"
Capacidade insuficiente na região selecionada.
```

Decisão final:

```txt id="k9qj8w"
Render + Railway
```

Essa arquitetura tornou-se a base oficial da infraestrutura da Syrla.

---

# Status Atual

```txt id="2ymr93"
Fase 1 ✅
Fase 2 ✅
Fase 3 ✅
Fase 4 🚀
```
