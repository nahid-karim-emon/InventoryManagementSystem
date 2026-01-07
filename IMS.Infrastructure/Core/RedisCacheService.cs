using IMS.Core.Caching;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace IMS.Infrastructure.Core
{
    public class RedisCacheService : IRedisCacheService
    {
        private readonly IDistributedCache _cache;

        public RedisCacheService(IDistributedCache cache)
        {   
            _cache = cache;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var jsonData = await _cache.GetStringAsync(key);

            if (jsonData is null)
            {
                return default;
            }

            return JsonSerializer.Deserialize<T>(jsonData);
        }

        public async Task<T?> HashGetAllAsync<T>(string key)
        {
            return await GetAsync<T>(key);
        }

        public async Task HashSetAsync<T>(string key, string productId, T value, TimeSpan? expire = null)
        {
            var jsonData = await _cache.GetStringAsync(key);
            Dictionary<string, T>? items = null;

            if (jsonData is not null)
            {
                items = JsonSerializer.Deserialize<Dictionary<string, T>>(jsonData);
            }

            items ??= new Dictionary<string, T>();

            items[productId] = value;

            await SetAsync(key, items, expire);
        }

        public async Task RemoveItemAsync(string key, string productId)
        {
            var jsonData = await _cache.GetStringAsync(key);

            if (jsonData is null)
            {
                return;
            }

            var items = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonData);

            if (items is not null && items.Remove(productId))
            {
                await SetAsync(key, items);
            }
        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var options = new DistributedCacheEntryOptions();
            if (expiry.HasValue)
            {
                options.AbsoluteExpirationRelativeToNow = expiry;
            }
            else
            {
                options.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            }

            var jsonData = JsonSerializer.Serialize(value);
            await _cache.SetStringAsync(key, jsonData, options);
        }
    }
}
