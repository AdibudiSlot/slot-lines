using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Redis
{
    public class RedisRepository : IRedisRepository
    {
        private readonly IRedisDatabase _redisDatabase;

        public RedisRepository(IRedisDatabase redisDatabase)
        {
            _redisDatabase = redisDatabase ?? throw new ArgumentNullException(nameof(redisDatabase));
        }

        public async Task<T> GetAsync<T>(string key)
        {
            return await _redisDatabase.GetAsync<T>(key);
        }

        public async Task SetAsync<T>(string key, T value, DateTimeOffset expiry)
        {
            await _redisDatabase.AddAsync(key, value, expiry);
        }

        public async Task SetAsync<T>(string key, T value)
        {
            await _redisDatabase.AddAsync(key, value);
        }

        public async Task<bool> DeleteAsync(string key)
        {
            return await _redisDatabase.RemoveAsync(key);
        }
    }
}
