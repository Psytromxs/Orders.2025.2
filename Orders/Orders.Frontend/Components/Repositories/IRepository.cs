namespace Orders.Frontend.Components.Repositories
{
    public interface IRepository
    {
        Task<httpResponseWrapper<T>> GetAsync<T>(string url);
        Task<httpResponseWrapper<object>> PostAsync<T>(string url, T value);
        Task<httpResponseWrapper<object>> PostAsync<T, TActionResponse>(string url, T value);
    }
}
