using Sovtech.Core.Services.ChuckNorris.Interface;
using Sovtech.Core.Services.Search.Interface;
using Sovtech.Core.Services.StarWars.Implementation;
using Sovtech.Core.Services.StarWars.Interface;
using Sovtech.Data.Models.Chuck;
using Sovtech.Data.Models.Swapi;

namespace Sovtech.Core.Services.Search.Implementation
{
    public class SearchService : ISearchService
    {
        private readonly IStarWarsService _starWarsService;
        private readonly IChuckService _chuckService;
        public SearchService(IStarWarsService starWarsService, IChuckService chuckService)
        {
            _starWarsService = starWarsService;
            _chuckService = chuckService;
        }

        public async Task<Tuple<ChuckQuerySearchResponse, PeopleResponse>> Search(string phrase)
            => Tuple.Create(await _chuckService.SearchAsync(phrase), await _starWarsService.Search(phrase));
    }
}