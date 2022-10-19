using sovtech.core.Helpers.Autofac;
using Sovtech.Data.Models.Swapi;

namespace Sovtech.Core.Services.StarWars.Interface
{
    public interface IStarWarsService : IAutoDependencyCore
    {
        Task<PeopleResponse> GetPeople(int page);
        Task<PeopleResponse> Search(string name);
    }
}