# Estado do projeto Syrla API

## Identificação

- Repositório: `xaviidev/syrla-api`
- Branch principal esperada: `main`
- Framework alvo declarado no projeto: `net8.0`
- Linguagem: C#
- Projeto web: ASP.NET Core
- Arquivo de entrada: `Program.cs`

## Evidências consultadas na auditoria inicial

A primeira versão desta referência foi elaborada a partir dos arquivos da branch `main` consultados durante a criação da Skill. Revalidar estes dados contra a branch ativa antes de usá-los em uma decisão técnica.

Arquivos inspecionados:
- `Program.cs`
- `Syrla.Api.csproj`
- `API/Controllers/AuthController.cs`
- `API/Controllers/UserController.cs`
- `Application/Services/AuthService.cs`
- `Application/Services/UserService.cs`
- `Application/Interfaces/IAuthService.cs`
- `Application/Interfaces/IUserService.cs`
- `Domain/Entities/User.cs`
- `Domain/Entities/AuditLog.cs`
- `Infrastructure/Data/AppDbContext.cs`
- `Infrastructure/Cache/ICacheService.cs`
- `Infrastructure/Cache/RedisCacheService.cs`
- documentos em `docs/` relacionados a arquitetura, decisões, deploy, Fase 3, Fase 4, roadmap e troubleshooting.

## Implementações observadas no código

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

## Configuração de Redis observada

O `Program.cs` lê as chaves de configuração `REDIS_HOST` e `REDIS_PASSWORD`. Ambas são obrigatórias na inicialização atual; a aplicação lança `InvalidOperationException` se qualquer uma estiver ausente. A conexão usa TLS e porta 6379.

Não copiar valores reais de credenciais para esta referência.

## Divergências e riscos documentais identificados

Os documentos `docs/ARCHITECTURE.md`, `docs/DECISIONS.md`, `docs/ROADMAP.md` e `docs/DEPLOYMENT.md` continham status antigos ou incompletos em relação aos arquivos de código consultados. Exemplos: Redis aparecia como planejado, Fase 4 aparecia em planejamento em alguns documentos, e Serilog/observabilidade estavam posicionados em fases anteriores ao estado implementado.

A documentação antiga de deploy listava tabelas incompletas. O histórico de desenvolvimento relatou também a tabela `AuditLogs`; confirmar migrations e banco antes de tratar o inventário como definitivo.

## Observações técnicas que exigem revisão

1. `POST /api/User` não possui atributo `[Authorize]` no controller consultado. Confirmar se cadastro público é intencional e quais controles antiabuso existem.
2. O JWT é configurado com validação de lifetime e signing key; issuer e audience não são validados no trecho atual. Não alterar sem revisar a estratégia de tokens.
3. O health check registra API e MySQL, mas não Redis.
4. Redis é conectado de forma síncrona durante a inicialização e exige variáveis de ambiente mesmo em ambiente local.
5. O projeto declara `net8.0`, enquanto algumas referências NuGet consultadas estão na linha 9 ou 10. Verificar compatibilidade e matriz suportada antes de atualizar ou rebaixar pacotes.
6. Não foi confirmado, na auditoria inicial, um projeto de testes automatizados na árvore. Verificar a árvore atual e não presumir que xUnit/Moq/FluentAssertions estejam efetivamente configurados.
7. Os documentos existentes mencionam CI/CD e deploy automático; revalidar workflows e configuração de hospedagem antes de descrever como estado atual.

## Como usar esta referência

Esta página é um retrato inicial, não um substituto da inspeção do código. Atualizá-la quando as evidências mudarem. Marcar qualquer informação não verificada como pendente de confirmação.