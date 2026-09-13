using System.Text.Json;
using StackExchange.Redis;

namespace Syrla.Infrastructure.Cache;

public class RedisCacheService : ICacheService
{
    private readonly IConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisCacheService(IConnectionMultiplexer redis)
    {
        _redis = redis;
        _database = _redis.GetDatabase();
    }

    public async Task<T?> GetAsync<T>(string key)
    {
        var value = await _database.StringGetAsync(key);

        if (!value.HasValue)
        {
            return default;
        }

        return JsonSerializer.Deserialize<T>(value!);
    }

    public async Task SetAsync<T>(
        string key,
        T value,
        TimeSpan? expiration = null)
    {
        var serializedValue = JsonSerializer.Serialize(value);

        if (expiration.HasValue)
        {
            await _database.StringSetAsync(
                key,
                serializedValue,
                expiration.Value
            );

            return;
        }

        await _database.StringSetAsync(
            key,
            serializedValue
        );
    }

    public async Task RemoveAsync(string key)
    {
        await _database.KeyDeleteAsync(key);
    }
}