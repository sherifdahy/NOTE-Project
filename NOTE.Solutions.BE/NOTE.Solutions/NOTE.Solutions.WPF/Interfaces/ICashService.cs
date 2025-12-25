using System;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.Interfaces;

public interface ICacheService
{
    Task<T> GetAsync<T>(string cacheKey) where T : class;
    Task RemoveAsync<T>(string cacheKey) where T : class;
    Task SetAsync<T>(string cacheKey,T value, TimeSpan? absExpire = null) where T : class;
}
