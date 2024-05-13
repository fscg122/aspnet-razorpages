using System.Net.Http.Headers;
using System.Text;

namespace RazorPagesContact
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string username = Environment.GetEnvironmentVariable("API_Username");
        private readonly string password = Environment.GetEnvironmentVariable("API_Password");
        private readonly string credentials;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"));
        }

        private HttpClient GetHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", credentials);

            return _httpClient;
        }

        public async Task<HttpResponseMessage> GetAsync(string requestUri)
        {
            HttpClient httpClient = GetHttpClient();
            return await httpClient.GetAsync($"{httpClient.BaseAddress}{requestUri}");
        }

        public async Task<HttpResponseMessage> PostAsync(string requestUri, StringContent payload)
        {
            HttpClient httpClient = GetHttpClient();
            return await httpClient.PostAsync($"{httpClient.BaseAddress}{requestUri}", payload);
        }

        public async Task<HttpResponseMessage> PutAsync(string requestUri, StringContent payload)
        {
            HttpClient httpClient = GetHttpClient();
            return await httpClient.PutAsync($"{httpClient.BaseAddress}{requestUri}", payload);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string requestUri)
        {
            HttpClient httpClient = GetHttpClient();
            return await httpClient.DeleteAsync($"{httpClient.BaseAddress}{requestUri}");
        }
    }
}
