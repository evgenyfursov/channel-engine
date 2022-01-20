using System.Net.Http.Headers;
using System.Text;
using ChannelEngineApi.BusinessLogic.Interfaces;
using ChannelEngineApi.BusinessLogic.Models;
using ChannelEngineApi.BusinessLogic.Models.Exceptions;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace ChannelEngineApi.BusinessLogic.Implementations
{
    public class OrderWrapper : IOrderWrapper
    {
        private readonly HttpClient _client;
        private readonly string _url;
        private readonly string _apiKey;
        private readonly string _updateStockUrl;

        public OrderWrapper(IOptions<Settings> options)
        {
            _client = new HttpClient();
            _url = options.Value.Url;
            _apiKey = options.Value.ApiKey;
            _updateStockUrl = options.Value.UpdateStockUrl;
        }

        public async Task<List<OrderDto>> GetByStatusAsync(string status)
        {
            var response = await _client.GetAsync($"{_url}?statuses={status}&apikey={_apiKey}");
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = responseBody
                };
            }

            return JsonSerializer.Deserialize<OrderContent>(responseBody)?.Content;
        }

        public async Task UpdateStockAsync(int stock, string merchantProductNo)
        {
            var model = new
            {
                MerchantProductNo = $"{merchantProductNo}",
                Stock = $"{stock}"
            };
            var json = $"[{JsonConvert.SerializeObject(model)}]";
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            _client.DefaultRequestHeaders.TryAddWithoutValidation("X-CE-KEY", _apiKey);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
            var response = await _client.PutAsync($"{_updateStockUrl}", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new ApiException
                {
                    StatusCode = (int)response.StatusCode,
                    Content = responseBody
                };
            }
        }
    }
}