# Arquitetura da Syrla API

## Visão observada

O projeto adota separação em diretórios/camadas:
- `API`: Controllers, middlewares e entrada HTTP.
- `Application`: serviços, interfaces de aplicação e DTOs.
- `Domain`: entidades de domínio.
- `Infrastructure`: persistência, cache e integrações técnicas.

O projeto também contém namespaces e caminhos legados com `Syrla.Api` e `Syrla.API`. Não padronizar namespaces de forma ampla sem mapear referências e impacto.

## Direção de dependências

Preservar a separação de responsabilidades existente:
- Controllers devem cuidar da fronteira HTTP e delegar operações.
- Serviços da Application coordenam os casos de uso.
- Repositórios abstraem acesso a dados conforme os contratos existentes.
- Infrastructure implementa integrações externas.
- Entidades de Domain não devem depender de detalhes de infraestrutura.

Antes de introduzir uma abstração nova, verificar se já existe contrato equivalente.

## Padrões observados

- DTOs para entrada e saída da API.
- Repository Pattern.
- Dependency Injection registrada no `Program.cs`.
- Entity Framework Core com `AppDbContext`.
- Middleware global de exceções.
- `ApiResponse<T>` para respostas padronizadas em controllers consultados.

## Registro de serviços observado

No `Program.cs` consultado:
- `IUserService` → `UserService` (Scoped)
- `IUserRepository` → `UserRepository` (Scoped)
- `IAuditLogRepository` → `AuditLogRepository` (Scoped)
- `IAuthService` → `AuthService` (Scoped)
- `IConnectionMultiplexer` → singleton
- `ICacheService` → `RedisCacheService` (Singleton)

Sempre confirmar os registros atuais antes de adicionar ou mudar DI.

## Regras de evolução

1. Não mover camadas ou renomear namespaces como efeito colateral de uma feature.
2. Evitar dependência de Controller para DbContext diretamente.
3. Não retornar entidades diretamente em endpoints.
4. Não expor PasswordHash em DTOs, logs ou respostas.
5. Avaliar transações quando uma operação grava entidade e auditoria em etapas distintas.
6. Avaliar consistência de cache quando houver atualização ou exclusão de dados.
7. Documentar mudanças de dependência entre camadas e justificar qualquer exceção.

## Atenção

A documentação antiga do repositório pode apresentar uma estrutura mais idealizada do que a árvore real. A árvore e os arquivos compilados da branch atual prevalecem.