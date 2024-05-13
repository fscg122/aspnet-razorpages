namespace RazorPagesContact
{
    public interface IApiClient
    {
        Task<HttpResponseMessage> GetAsync(string requestUri);
        Task<HttpResponseMessage> PostAsync(string requestUri, StringContent payload);
        Task<HttpResponseMessage> PutAsync(string requestUri, StringContent payload);
        Task<HttpResponseMessage> DeleteAsync(string requestUri);
    }
}
