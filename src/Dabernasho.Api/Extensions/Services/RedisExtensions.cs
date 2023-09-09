using StackExchange.Redis;

namespace Dabernasho.Api.Extensions.Services;

public static class RedisExtensions
{
    private const string RedisUrlKey = "REDIS_ENDPOINT_URL";
    private const string RedisPasswordKey = "REDIS_PASSWORD";

    public static IServiceCollection AddRedis(this IServiceCollection services, IConfiguration configuration)
    {
        var redisEndpointUrl = configuration.GetValue<string>(RedisUrlKey).Split(':');
        if (redisEndpointUrl is null)
            throw new ArgumentException($"{nameof(RedisUrlKey)} isn't set in configuration.");
        var redisHost = redisEndpointUrl[0];
        var redisPort = redisEndpointUrl[1];

        var redisPassword = configuration.GetValue<string>(RedisPasswordKey);
        var redisConnectionUrl = redisPassword != null
            ? $"{redisPassword}@{redisHost}:{redisPort}"
            : $"{redisHost}:{redisPort}";

        var redis = ConnectionMultiplexer.Connect(redisConnectionUrl);
        return services.AddSingleton<IConnectionMultiplexer>(redis);
    }
}