using Repository.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Repository.Http
{
    public abstract class HttpRepositoryBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _clientName;
        protected HttpClient Client { get; private set; }

        protected HttpRepositoryBase(IHttpClientFactory httpClientFactory, string clientName)
        {
            Client = httpClientFactory.CreateClient(clientName);
        }

        protected async Task<HttpResponseWrapper<T>> GetAsync<T>(string requestUri)
        {
            try
            {
                var response = await Client.GetAsync(requestUri);
                var responseData = await response.Content.ReadFromJsonAsync<T>();

                return new HttpResponseWrapper<T>(responseData, response.IsSuccessStatusCode, null, response.StatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<T>(default, false, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        protected async Task<HttpResponseWrapper<TResponse>> PostAsync<TRequest, TResponse>(string requestUri, TRequest content)
        {
            try
            {
                var response = await Client.PostAsJsonAsync(requestUri, content);
                var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
                return new HttpResponseWrapper<TResponse>(responseData, response.IsSuccessStatusCode, null, response.StatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<TResponse>(default, false, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        protected async Task<HttpResponseWrapper<TResponse>> PutAsync<TRequest, TResponse>(string requestUri, TRequest content)
        {
            try
            {
                var response = await Client.PutAsJsonAsync(requestUri, content);
                var responseData = await response.Content.ReadFromJsonAsync<TResponse>();
                return new HttpResponseWrapper<TResponse>(responseData, response.IsSuccessStatusCode, null, response.StatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<TResponse>(default, false, ex.Message, HttpStatusCode.InternalServerError);
            }
        }

        protected async Task<HttpResponseWrapper<bool>> DeleteAsync(string requestUri)
        {
            try
            {
                var response = await Client.DeleteAsync(requestUri);
                return new HttpResponseWrapper<bool>(response.IsSuccessStatusCode, response.IsSuccessStatusCode, null, response.StatusCode);
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<bool>(false, false, ex.Message, HttpStatusCode.InternalServerError);
            }
        }
    }
}