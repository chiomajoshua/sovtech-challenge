using sovtech.core.Helpers.Autofac;
using Sovtech.Data.Models.Chuck;

namespace Sovtech.Core.Services.ChuckNorris.Interface
{
    public interface IChuckService : IAutoDependencyCore
    {
        Task<CategoriesResponse> GetAllJokeCategoriesAsync();
        Task<ChuckQuerySearchResponse> SearchAsync(string query);
        Task<CategoryResult> GetRandomCategoryJokeAsync(string category);
    }
}