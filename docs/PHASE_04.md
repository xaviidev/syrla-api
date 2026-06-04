# FASE 04 - AUTORIZAÇÃO E SEGURANÇA

## Status

Em Planejamento 🚀

---

# Objetivo

Fortalecer os mecanismos de autenticação, autorização e segurança da plataforma Syrla.

Após a conclusão desta fase, a aplicação deverá ser capaz de identificar usuários autenticados, controlar permissões de acesso e preparar a base para ambientes corporativos.

---

# Visão Geral

Atualmente a Syrla já possui:

* Cadastro de usuários
* Login
* JWT Authentication
* BCrypt Password Hashing
* Banco de dados em nuvem
* API em produção

O próximo passo é evoluir do conceito de autenticação para autorização.

---

# Etapa 1 - Usuário Autenticado

## Objetivo

Permitir que a API identifique o usuário que realizou o login.

---

## Endpoint

```http
GET /api/Auth/me
```

---

## Resultado Esperado

Retornar:

* Id
* Nome
* Email

Baseado nas informações contidas no JWT.

---

# Etapa 2 - Rotas Protegidas

## Objetivo

Impedir acesso não autorizado a recursos privados.

---

## Implementação

Utilização do atributo:

```csharp
[Authorize]
```

---

## Aplicações

* Listagem de usuários
* Perfil do usuário
* Recursos administrativos

---

# Etapa 3 - Claims

## Objetivo

Armazenar informações relevantes dentro do token JWT.

---

## Claims Planejadas

* User Id
* Name
* Email
* Role

---

## Benefícios

* Menos consultas ao banco
* Identificação rápida do usuário
* Controle de acesso

---

# Etapa 4 - Roles

## Objetivo

Criar perfis de acesso.

---

## Perfis Iniciais

### User

Permissões básicas.

---

### Admin

Acesso administrativo.

---

## Futuro

### Manager

Gerenciamento operacional.

---

# Etapa 5 - Segurança

## Objetivo

Aprimorar a proteção da aplicação.

---

## Melhorias Planejadas

* Secrets via Variáveis de Ambiente
* Rotação de Chaves JWT
* Políticas de Autorização
* Validações adicionais

---

# Etapa 6 - Auditoria

## Objetivo

Registrar eventos relevantes da aplicação.

---

## Eventos

* Login
* Logout
* Criação de usuários
* Alterações críticas

---

# Entregas Esperadas

## Funcionalidades

* Endpoint /me
* Rotas protegidas
* Claims
* Roles
* Auditoria básica

---

## Segurança

* Controle de acesso
* Melhor gerenciamento de segredos
* Base preparada para ambientes corporativos

---

# Critério de Conclusão

A Fase 04 será considerada concluída quando:

* Usuário autenticado puder ser identificado
* Rotas protegidas estiverem funcionando
* Roles estiverem implementadas
* Claims estiverem presentes no JWT
* Auditoria básica estiver operacional

---

# Próxima Fase

## Fase 05 - Escalabilidade

Objetivos futuros:

* Redis
* RabbitMQ
* Background Services
* Cache
* Health Checks Avançados

---

# Versão

Planejada para:

```txt
v0.2.0
```
