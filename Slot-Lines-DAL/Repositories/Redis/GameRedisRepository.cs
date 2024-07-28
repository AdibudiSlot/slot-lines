using Repository.Redis;
using StackExchange.Redis.Extensions.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Lines_DAL.Repositories.Redis
{
    public class GameRedisRepository : RedisRepository
    {
        public GameRedisRepository(IRedisDatabase redisDatabase) : base(redisDatabase)
        {
        }
    }
}
