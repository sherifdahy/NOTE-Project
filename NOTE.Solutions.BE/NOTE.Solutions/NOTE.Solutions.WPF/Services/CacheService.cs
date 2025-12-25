using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using NOTE.Solutions.WPF.Interfaces;
using System;
using System.Threading.Tasks;

namespace NOTE.Solutions.WPF.Services;

public class CacheService(IDistributedCache distributedCache) : ICacheService
{
    private readonly IDistributedCache _distributedCache = distributedCache;

    public async Task<T> GetAsync<T>(string cacheKey) where T : class
    {
        var result = await _distributedCache.GetStringAsync(cacheKey);

        if (string.IsNullOrEmpty(result))
            return null;

        return JsonConvert.DeserializeObject<T>(result);
    }

    public async Task RemoveAsync<T>(string cacheKey) where T : class
    {
        await _distributedCache.RemoveAsync(cacheKey);
    }

    public async Task SetAsync<T>(string cacheKey, T value, TimeSpan? absExpire = null) where T : class
    {
        var option = new DistributedCacheEntryOptions();

        if(absExpire.HasValue)
            option.AbsoluteExpirationRelativeToNow = absExpire.Value;

        await _distributedCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(value), option);
    }
}
