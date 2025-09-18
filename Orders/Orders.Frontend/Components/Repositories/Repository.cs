
using System.Text.Json;

namespace Orders.Frontend.Components.Repositories
{
    public class Repository : IRepository
    {
        // Atributos privados //
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonDefaultOptions;

        public Repository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<httpResponseWrapper<T>> GetAsync<T>(string url)
        {
            var responseHttp = await _httpClient.GetAsync(url);
            if (responseHttp.IsSuccessStatusCode)
            {
                var response = await UnserializerAnswer<T>(responseHttp);
                return new httpResponseWrapper<T>(response, false, responseHttp);
            }
            else
            {
                return new httpResponseWrapper<T>(default, true, responseHttp);
            }
        }

        public async Task<httpResponseWrapper<object>> PostAsync<T>(string url, T value)
        {
            throw new NotImplementedException();
        }

        public async Task<httpResponseWrapper<object>> PostAsync<T, TActionResponse>(string url, T value)
        {
            throw new NotImplementedException();
        }

        private async Task<T?> UnserializerAnswer<T>(HttpResponseMessage responseHttp)
        {
            throw new NotImplementedException();
        }
    }
}
