# Estado do projeto Syrla API

## Identificação

- Repositório: `xaviidev/syrla-api`
- Branch principal: `main`
- Framework alvo declarado: `net8.0`
- Linguagem: C#
- Projeto web: ASP.NET Core
- Arquivo de entrada: `Program.cs`

## Base de evidência desta referência

A auditoria documental desta Skill foi inicialmente baseada no commit da `main`:

`80b4e0f5804cea30a34f00784a32d754656d2501`

A branch `docs/claude-syrla-api-skill-v1` foi criada a partir dessa base e, no momento da revisão, contém mudanças documentais e tooling da Skill, sem alteração do código da API. Revalidar o HEAD da branch antes de usar este retrato em uma decisão técnica.

Arquivos de código consultados na base:
- `Program.cs`
- `Syrla.Api.csproj`
- `Dockerfile`
- Controllers, serviços, entidades, DbContext, cache e migrations descritos abaixo, conforme a auditoria inicial.

## Implementações observadas na auditoria inicial

- Controllers de autenticação e usuários.
- Login por e-mail e senha.
- Hash e verificação de senha com BCrypt.
- Emissão de JWT com claims de identificador, nome, e-mail e role.
- Endpoint autenticado `GET /api/Auth/me`.
- Endpoint `GET /api/Auth/admin` protegido pela policy `CanManageUsers`, que exige role `Admin`.
- Listagem de usuários protegida com `[Authorize]`.
- Criação de usuários no endpoint `POST /api/User`.
- Entidade `AuditLog` e persistência de eventos de login e criação de usuário.
- Serilog com saída Console e File.
- Health checks para API e MySQL.
- Redis com StackExchange.Redis, TLS e senha.
- Cache da listagem de usuários com chave `users:all`, TTL de cinco minutos e invalidação após criação de usuário.
- Swagger com definição de segurança Bearer.
- Middleware global de exceções.

Esses itens são evidências da auditoria de código/documentação, não prova de deploy ou funcionamento atual em produção.

## Configuração observada no Program.cs

- JWT: lê `JwtSettings:SecretKey`; valida lifetime e signing key; issuer e audience estão configurados como não validados.
- Redis: lê `REDIS_HOST` e `REDIS_PASSWORD`; ambas são obrigatórias na inicialização; usa TLS e porta 6379.
- Health checks: registra API e MySQL; Redis não aparece no trecho consultado.
- Serilog: escreve em Console e em arquivos diários sob `logs/syrla-.txt`.
- Swagger: registra esquema Bearer.
- EF Core: usa `AppDbContext` e MySQL.

Não copiar valores reais de credenciais para esta referência.

## Dependências observadas no Syrla.Api.csproj

O projeto declara `net8.0`. Entre as versões consultadas:
- `Microsoft.AspNetCore.Authentication.JwtBearer` 8.0.0
- `Microsoft.AspNetCore.OpenApi` 8.0.27
- `Microsoft.EntityFrameworkCore` 9.0.0
- `Microsoft.EntityFrameworkCore.Design` 9.0.0
- `Pomelo.EntityFrameworkCore.MySql` 9.0.0
- `AspNetCore.HealthChecks.MySql` 9.0.0
- `Serilog.AspNetCore` 10.0.0
- `StackExchange.Redis` 3.2.0

A presença de versões principais diferentes do target framework é um ponto de verificação de compatibilidade, não prova isolada de incompatibilidade. Confirmar frameworks-alvo dos pacotes, restore e build com o SDK adequado antes de atualizar ou rebaixar dependências.

## Divergências e riscos documentais identificados

Os documentos `docs/ARCHITECTURE.md`, `docs/DECISIONS.md`, `docs/ROADMAP.md` e `docs/DEPLOYMENT.md` continham status antigos ou incompletos em relação aos arquivos de código consultados. Exemplos: Redis aparecia como planejado, Fase 4 aparecia em planejamento em alguns documentos, e Serilog/observabilidade estavam posicionados em fases anteriores ao estado implementado.

A documentação antiga de deploy listava tabelas incompletas. O histórico de desenvolvimento relatou também a tabela `AuditLogs`; confirmar migrations e banco antes de tratar o inventário como definitivo.

## Observações técnicas que exigem revisão

1. `POST /api/User` não possui atributo `[Authorize]` no controller consultado. Confirmar se cadastro público é intencional e quais controles antiabuso existem.
2. O JWT valida lifetime e signing key, mas issuer e audience não são validados. Não alterar sem revisar a estratégia de tokens.
3. O health check registra API e MySQL, mas não Redis.
4. Redis é conectado de forma síncrona durante a inicialização e exige variáveis de ambiente mesmo em ambiente local.
5. O projeto declara `net8.0` enquanto algumas dependências consultadas têm versões principais 9 ou 10. Verificar compatibilidade com restore/build; não presumir incompatibilidade apenas pelo número da versão.
6. Não foi confirmado, na auditoria inicial, um projeto de testes automatizados na árvore. Verificar a árvore atual e não presumir que xUnit/Moq/FluentAssertions estejam efetivamente configurados.
7. O Dockerfile consultado usa imagens ASP.NET e SDK 8.0. Revalidar workflows, configuração de hospedagem e deploy antes de descrever como estado atual.

## Como usar esta referência

Esta página é um retrato com base de evidência identificada, não um substituto da inspeção do código. Atualizá-la quando as evidências mudarem. Marcar qualquer informação não verificada como pendente de confirmação.
