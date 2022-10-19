using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sovtech.Core.Helpers.InternetClient;
using Sovtech.Core.Services.ChuckNorris.Interface;
using Sovtech.Data.Models.Chuck;

namespace Sovtech.Core.Services.ChuckNorris.Implementation
{
    public class ChuckService : IChuckService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _config;
        public ChuckService(IHttpClientService httpClientService, IConfiguration config)
        {
            _httpClientService = httpClientService;
            _config = config;
        }

        public async Task<CategoriesResponse> GetAllJokeCategoriesAsync()
        {
            var response = await _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckCategories")}");

            if (response.IsSuccessStatusCode)
                return new CategoriesResponse(JsonConvert.DeserializeObject<string[]>(await response.Content.ReadAsStringAsync()));
            return null;
        }

        public async Task<CategoryResult> GetRandomCategoryJokeAsync(string category)
        {
            var response = await _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckRandomCategoryJoke")}{category}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<CategoryResult>(await response.Content.ReadAsStringAsync()); ;
            return null;
        }

        public async Task<ChuckQuerySearchResponse> SearchAsync(string query)
        {
            var response = await _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckJokeSearch")}{query}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ChuckQuerySearchResponse>(await response.Content.ReadAsStringAsync()); ;
            return null;
        }
    }
}