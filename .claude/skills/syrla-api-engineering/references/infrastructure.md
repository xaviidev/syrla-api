# Infraestrutura e deploy

## Infraestrutura documentada

- GitHub: repositório e versionamento.
- Render: hospedagem da API.
- Docker: imagem da aplicação.
- Railway: MySQL.
- Upstash: Redis.

Os serviços acima constam na documentação/histórico do projeto. Confirmar estado, plano, URLs e recursos ativos antes de qualquer operação; não presumir que a configuração continua vigente.

## Dockerfile observado

O Dockerfile utiliza:
- imagem runtime ASP.NET 8.0;
- imagem SDK .NET 8.0 para build;
- publicação Release em `/app/publish`;
- entrypoint `dotnet Syrla.Api.dll`;
- porta exposta 8080.

Sempre ler o Dockerfile atual antes de propor alterações.

## Configuração sensível

Não armazenar valores reais no repositório. Exemplos de nomes observados:
- `JwtSettings__SecretKey`
- `ConnectionStrings__DefaultConnection`
- `REDIS_HOST`
- `REDIS_PASSWORD`
- `ASPNETCORE_URLS`

A configuração local de Redis foi historicamente exportada na sessão do terminal. A persistência segura via `dotnet user-secrets` ainda precisa ser confirmada. Não presumir que as credenciais persistem entre sessões.

## Verificações de deploy

Antes de qualquer deploy:
1. Verificar branch, diff e commit.
2. Executar build e testes disponíveis.
3. Revisar mudanças de configuração e migrations.
4. Confirmar secrets configurados no ambiente alvo sem imprimir valores.
5. Confirmar health check e logs após deploy.
6. Não executar deploy ou rollback sem autorização explícita.

## Segurança operacional

- Nunca apagar volumes ou recursos persistentes para resolver erros sem autorização explícita.
- Não usar comandos destrutivos como primeira tentativa.
- Preferir consultas somente leitura para diagnóstico.
- Diferenciar ambiente local, staging e produção em todos os comandos e exemplos.
- Não assumir que URLs e serviços documentados continuam ativos; confirmar antes de usar.
