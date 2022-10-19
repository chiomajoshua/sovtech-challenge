using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Sovtech.API.Controllers;
using Sovtech.Core.Services.StarWars.Interface;
using Sovtech.Data.Models.Swapi;

namespace Sovtech.Api.Tests.Unit
{
    public class SwapiControllerTests : IDisposable
    {
        private readonly IStarWarsService _starWarsService = Substitute.For<IStarWarsService>();
        private readonly SwapiController _sut;
        private bool disposedValue;

        public SwapiControllerTests()
        {
            _sut = new SwapiController(_starWarsService);
        }


        [Fact]
        public async Task GetChuckCategories_Should_Return_Categories()
        {
            //Arrange
            var films = new List<string> { "https://swapi.dev/api/films/1/", "https://swapi.dev/api/films/2/", "https://swapi.dev/api/films/3/", "https://swapi.dev/api/films/6/" };
            var species = new List<string>();
            var vehicles = new List<string> { "https://swapi.dev/api/vehicles/14/", "https://swapi.dev/api/vehicles/30/" };
            var starships = new List<string> { "https://swapi.dev/api/starships/12/", "https://swapi.dev/api/starships/22/" };
            var peopleResult = new PeopleResult("Luke Skywalker", "172", "77", "blond", "fair", "blue", "19BBY", "male", "https://swapi.dev/api/planets/1/", films, species, vehicles, starships,
                DateTime.Parse("2014-12-09T13:50:51.644000Z"), DateTime.Parse("2014-12-20T21:17:56.891000Z"), "https://swapi.dev/api/people/1/");
            var people = new List<PeopleResult>() { peopleResult };
            var peopleResponse = new PeopleResponse(1, "https://swapi.dev/api/people/?page=2", null, people);
            _starWarsService.GetPeople(1).Returns(peopleResponse);

            //Act
            var result = (OkObjectResult)await _sut.GetSwapiPeople();

            //Assert
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeEquivalentTo(peopleResponse);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~SwapiControllerTests()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
