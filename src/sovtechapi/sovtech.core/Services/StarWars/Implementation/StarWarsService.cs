using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Sovtech.Core.Helpers.InternetClient;
using Sovtech.Core.Services.StarWars.Interface;
using Sovtech.Data.Models.Swapi;

namespace Sovtech.Core.Services.StarWars.Implementation
{
    public class StarWarsService : IStarWarsService
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IConfiguration _config;
        public StarWarsService(IHttpClientService httpClientService, IConfiguration config)
        {
            _httpClientService = httpClientService;
            _config = config;
        }

        public async Task<PeopleResponse> GetPeople(int page)
        {
            var response = await _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:SwapiBaseUrl")}{_config.GetValue<string>("Endpoints:SwapiPeople")}{page}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<PeopleResponse>(await response.Content.ReadAsStringAsync());
            return null;
        }

        public async Task<PeopleResponse> Search(string name)
        {
            var response = await _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:SwapiBaseUrl")}{_config.GetValue<string>("Endpoints:SwapiPeopleSearch")}{name}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<PeopleResponse>(await response.Content.ReadAsStringAsync());
            return null;
        }
    }
}