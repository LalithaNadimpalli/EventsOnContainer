using System.Threading.Tasks;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebMvc.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        private readonly HttpClient _client;
        public CustomHttpClient()
        {
             _client = new HttpClient();
        }

        public async Task<string> GetStringAsync(string uri,
            string authorizationToken = null,
            string authorizationMethod = "Bearer")
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            var response = await _client.SendAsync(requestMessage);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
