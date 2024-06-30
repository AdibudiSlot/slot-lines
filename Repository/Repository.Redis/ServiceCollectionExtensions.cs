using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.Newtonsoft;
using StackExchange.Redis.Extensions.Core.Abstractions;
using Microsoft.Extensions.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis.Extensions.Core.Implementations;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis;

namespace Repository.Redis
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ISerializer, NewtonsoftSerializer>();



            services.AddSingleton<IRedisDatabase>(sp =>
            {
                var redisConfiguration = configuration.GetSection("Redis").Get<RedisConfiguration>();
                var config = sp.GetRequiredService<RedisConfiguration>();
                var serializer = sp.GetRequiredService<ISerializer>();
                var serverEnumerationStrategy = redisConfiguration?.ServerEnumerationStrategy ?? new ServerEnumerationStrategy
                {
                    Mode = ServerEnumerationStrategy.ModeOptions.All,
                    TargetRole = ServerEnumerationStrategy.TargetRoleOptions.Any,
                    UnreachableServerAction = ServerEnumerationStrategy.UnreachableServerActionOptions.Throw
                };
                return new RedisDatabase(new RedisConnectionPoolManager(redisConfiguration),
                    serializer, serverEnumerationStrategy, redisConfiguration.Database, 2048);
            });

            // Register the Redis repository
            services.AddScoped(typeof(IRedisRepository), typeof(RedisRepository));

            return services;
        }
    }
}
