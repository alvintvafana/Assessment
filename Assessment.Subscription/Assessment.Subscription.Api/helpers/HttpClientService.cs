using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Assessment.Subscription.Api.helpers
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _clientFactory;

        public HttpClientService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<T> GetRequest<T>(T contectResult, string getUrl) where T : class
        {
            var client = _clientFactory.CreateClient();

            var response = await client.GetAsync(getUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                contectResult = JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
            return contectResult;
        }
    }
}
