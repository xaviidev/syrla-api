# Redis Cache

## Implementação observada

- Biblioteca: StackExchange.Redis.
- Serviço: `Infrastructure/Cache/RedisCacheService.cs`.
- Contrato: `Infrastructure/Cache/ICacheService.cs`.
- Registro DI: singleton para `IConnectionMultiplexer` e `ICacheService`.
- Provedor usado no projeto: Upstash Redis com TLS.

## Configuração observada

O `Program.cs` lê:
- `REDIS_HOST`
- `REDIS_PASSWORD`

A configuração:
- usa TLS (`Ssl = true`);
- usa porta 6379;
- configura `AbortOnConnectFail = false`;
- define senha;
- conecta via `ConnectionMultiplexer.Connect`.

As duas variáveis são obrigatórias na inicialização atual. Não documentar nem reproduzir valores reais.

## Contrato

`ICacheService` oferece:
- `GetAsync<T>(string key)`
- `SetAsync<T>(string key, T value, TimeSpan? expiration = null)`
- `RemoveAsync(string key)`

O serviço serializa/deserializa valores com `System.Text.Json` e utiliza operações Redis String e KeyDelete.

## Caso de uso implementado

Em `UserService`:
- chave: `users:all`;
- TTL: cinco minutos;
- HIT: retorna lista em cache;
- MISS: consulta repositório, mapeia para DTO e grava cache;
- criação de usuário: invalida a chave após persistência e auditoria.

## Evidência histórica de teste

O desenvolvimento registrou validação funcional de:
- MISS → consulta MySQL → SET com TTL de cinco minutos;
- HIT sem nova consulta MySQL;
- invalidação após criação;
- MISS após invalidação e recarga da lista;
- HIT na chamada seguinte.

Reexecutar os testes quando houver mudança na implementação ou ambiente. Não considerar esse histórico prova de funcionamento atual em produção.

## Cuidados

1. Não armazenar dados sensíveis no cache sem justificativa, minimização e controles adequados.
2. Usar TTL e política de invalidação coerentes com o domínio.
3. Avaliar concorrência, cache stampede, serialização e versionamento de payload.
4. Não transformar indisponibilidade do Redis em indisponibilidade total sem avaliar requisito e fallback.
5. O health check consultado verifica API e MySQL, não Redis.
6. A conexão Redis é inicializada no startup; avaliar conexão assíncrona, readiness e tratamento de indisponibilidade.
7. Não confundir senha Redis TCP com token REST do Upstash.
8. Usar User Secrets localmente e variáveis/secret store em produção.
9. Nunca imprimir segredos ou valores armazenados em cache nos logs.