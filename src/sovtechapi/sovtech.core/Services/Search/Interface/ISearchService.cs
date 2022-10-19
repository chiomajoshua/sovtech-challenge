using sovtech.core.Helpers.Autofac;
using Sovtech.Data.Models.Chuck;
using Sovtech.Data.Models.Swapi;

namespace Sovtech.Core.Services.Search.Interface
{
    public interface ISearchService : IAutoDependencyCore
    {
        Task<Tuple<ChuckQuerySearchResponse, PeopleResponse>> Search(string phrase);
    }
}