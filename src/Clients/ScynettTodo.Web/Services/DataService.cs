using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace ScynettTodo.Web.Services
{
    public class DataService
    {
        private readonly ILogger<DataService> _logger;
        private readonly HttpClient _httpClient;

        public DataService(ILogger<DataService> logger, HttpClient httpClient) =>
            (_logger, _httpClient) = (logger, httpClient);

        public Task<TResponse> GetAsync<TResponse>(string path)
        {
            _logger.LogInformation($"GET: Retrieving resource of type {typeof(TResponse).Name}");
            return _httpClient.GetFromJsonAsync<TResponse>(path);
        }

        public Task<HttpResponseMessage> PostAsync<TBody>(string path, TBody body)
        {
            _logger.LogInformation($"POST: Creating resource of type {typeof(TBody).Name}");
            return _httpClient.PostAsJsonAsync(path, body);
        }

        public Task<HttpResponseMessage> PutAsync<TBody>(string path, TBody body)
        {
            _logger.LogInformation($"PUT: Updating resource of type {typeof(TBody).Name}");
            return _httpClient.PutAsJsonAsync(path, body);
        }

        public Task<HttpResponseMessage> DeleteAsync(string path)
        {
            _logger.LogInformation("DELETE: Removing resource");
            return _httpClient.DeleteAsync(path);
        }
    }
}