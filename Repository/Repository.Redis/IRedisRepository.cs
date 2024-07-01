using System;
using System.Threading.Tasks;

namespace Repository.Redis
{
    public interface IRedisRepository
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync<T>(string key, T value, DateTimeOffset expiry);
        Task SetAsync<T>(string key, T value);
        Task<bool> DeleteAsync(string key);
    }
}
