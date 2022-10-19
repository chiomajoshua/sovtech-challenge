using FluentAssertions;
using Newtonsoft.Json;
using Sovtech.Core.Services.StarWars.Implementation;
using Sovtech.Data.Models.Swapi;
using System.Net;

namespace Sovtech.Core.Tests.Unit
{
    public class StarWarsServiceTests
    {
        private readonly StarWarsService _sut;
        private readonly IHttpClientService _httpClientService = Substitute.For<IHttpClientService>();
        private readonly IConfiguration _config = Substitute.For<IConfiguration>();
        public StarWarsServiceTests()
        {
            _sut = new StarWarsService(_httpClientService, _config);
        }


        [Theory]
		[InlineData(1)]
        public async Task GetPeople_ShouldReturnPeople(int page)
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
            HttpResponseMessage httpResponseMessage = new() { Content = new StringContent(JsonConvert.SerializeObject(peopleResponse)), StatusCode = HttpStatusCode.OK };
            _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:SwapiBaseUrl")}{_config.GetValue<string>("Endpoints:SwapiPeople")}{page}").Returns(httpResponseMessage);

            //Act
            var result = await _sut.GetPeople(page);

            //Assert
            result.Count.Should().Be(1);
            result.Should().BeEquivalentTo(peopleResponse);
        }
    }
}