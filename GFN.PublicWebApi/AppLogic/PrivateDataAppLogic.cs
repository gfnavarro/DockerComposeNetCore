using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GFN.PublicWebApi.AppLogic
{
    public class PrivateDataAppLogic
    {
        IHttpClientFactory httpClientFactory;
        string baseUrl;

        public PrivateDataAppLogic(IHttpClientFactory httpClientFactory, IOptions<Settings> settings)
        {
            this.httpClientFactory = httpClientFactory;
            baseUrl = settings.Value.PrivateDataUrl;
        }

        public async Task<string> GetData()
        {
            var client = this.httpClientFactory.CreateClient();
            return await client.GetStringAsync(baseUrl + "/private");
        }

        public async Task<List<string>> GetData(int count)
        {
            var client = this.httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{baseUrl}/private/{count}");
            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<string>>(jsonString);
            }
            return null;
        }
    }
}
