namespace IMS.Core.Caching
{
    public interface IRedisCacheService
    {
        Task SetAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task HashSetAsync<T>(string key, string productId, T value, TimeSpan? expire = null);
        Task<T?> GetAsync<T>(string key);
        Task<T?> HashGetAllAsync<T>(string key);
        Task RemoveAsync(string key);
        Task RemoveItemAsync(string key, string productId);
    }
}
