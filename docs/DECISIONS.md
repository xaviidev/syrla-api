# Syrla - Architectural Decision Records (ADR)

## Objetivo

Registrar decisões arquiteturais tomadas durante a evolução da plataforma Syrla.

---

# ADR-001

## Clean Architecture

### Decisão

Adotar Clean Architecture como padrão estrutural.

### Motivo

Separar responsabilidades e reduzir acoplamento.

### Benefícios

* Escalabilidade
* Testabilidade
* Organização
* Facilidade de manutenção

### Status

Aprovado

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

Aprovado

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

Aprovado

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

Aprovado

---

# ADR-005

## JWT

### Decisão

Utilizar JWT para autenticação.

### Motivo

Arquitetura stateless e compatível com APIs modernas.

### Benefícios

* Escalabilidade
* Integração com aplicações externas
* Baixa dependência de sessão

### Status

Aprovado

---

# ADR-006

## Oracle Cloud

### Decisão

Utilizar Oracle Cloud Free Tier como infraestrutura inicial.

### Motivo

Excelente relação custo-benefício para fase inicial do projeto.

### Benefícios

* VPS gratuita
* Recursos robustos
* Ambiente Linux completo

### Status

Planejado

---

# ADR-007

## Docker

### Decisão

Containerizar toda a plataforma.

### Motivo

Padronizar ambientes.

### Benefícios

* Deploy simplificado
* Reprodutibilidade
* Escalabilidade

### Status

Planejado

---

# ADR-008

## Redis

### Decisão

Adicionar Redis na Fase 4.

### Motivo

Melhorar performance e cache.

### Benefícios

* Redução de consultas
* Menor carga no banco

### Status

Planejado

---

# ADR-009

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

Planejado

---

# ADR-010

## Agentes IA

### Decisão

Transformar a Syrla em uma plataforma de agentes especializados.

### Motivo

Centralizar automação, conhecimento e tomada de decisão.

### Benefícios

* Produtividade
* Escalabilidade operacional
* Inteligência organizacional

### Status

Planejado
