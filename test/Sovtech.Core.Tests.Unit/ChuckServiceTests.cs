using FluentAssertions;
using Newtonsoft.Json;
using Sovtech.Data.Models.Chuck;
using System.Net;

namespace Sovtech.Core.Tests.Unit
{
    public class ChuckServiceTests : IDisposable
    {
        private readonly ChuckService _sut;
        private readonly IHttpClientService _httpClientService = Substitute.For<IHttpClientService>();
        private readonly IConfiguration _config = Substitute.For<IConfiguration>();
        private bool disposedValue;

        public ChuckServiceTests()
        {
            _sut = new ChuckService(_httpClientService, _config);
        }

        [Fact]
        public async Task GetAllJokeCategoriesAsync_ShouldReturnNull_WhenNoCategoriesAreFetched()
        {
            //Arrange
            CategoriesResponse categoryResult = null;
            HttpResponseMessage httpResponseMessage = new() { Content = null, StatusCode = HttpStatusCode.NotFound };
            _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckCategories")}").Returns(httpResponseMessage);

            //Act
            var result = await _sut.GetAllJokeCategoriesAsync();

            //Assert
            result.Should().BeEquivalentTo(categoryResult);
        }

        [Fact]
        public async Task GetAllJokeCategoriesAsync_ShouldReturnList_WhenCategoriesAreFetched()
        {
            //Arrange
            var arrayResponse = new string[] { "money", "love" };
            CategoriesResponse categoryResult = new CategoriesResponse(arrayResponse);
            HttpResponseMessage httpResponseMessage = new() { Content = new StringContent(JsonConvert.SerializeObject(arrayResponse)), StatusCode = HttpStatusCode.OK  };
            _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckCategories")}").Returns(httpResponseMessage);

            //Act
            var result = await _sut.GetAllJokeCategoriesAsync();

            //Assert
            result.Should().BeEquivalentTo(categoryResult);
        }

        [Theory]
        [InlineData("money")]
        public async Task GetRandomCategoryJokeAsync_ShouldReturnRandomJoke_WhenValidCategoryIsPassed(string category)
        {
            //Arrange
            var randomJokeResponse = new CategoryResult(new List<string>() { category }, "2020-01-05 13:42:20.841843", "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
                "ZaNUDPlKTROi6DL1Ii8LOQ", "2020-05-22 06:16:41.133769", "https://api.chucknorris.io/jokes/ZaNUDPlKTROi6DL1Ii8LOQ",
                "Chuck Norris knows how to shut down Skynet. Warner Bros beged him not to so they can make some money out of it.");
            HttpResponseMessage httpResponseMessage = new() { Content = new StringContent(JsonConvert.SerializeObject(randomJokeResponse)), StatusCode = HttpStatusCode.OK };
            _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckRandomCategoryJoke")}{category}").Returns(httpResponseMessage);

            //Act
            var result = await _sut.GetRandomCategoryJokeAsync(category);

            //Assert
            result.Should().BeEquivalentTo(randomJokeResponse);
        }

        [Theory]
        [InlineData("human")]
        public async Task GetRandomCategoryJokeAsync_ShouldReturnNull_WhenInValidCategoryIsPassed(string category)
        {
            //Arrange
            CategoryResult randomJokeResponse = null;
            HttpResponseMessage httpResponseMessage = new() { Content = null, StatusCode = HttpStatusCode.NotFound };
            _httpClientService.MakeHttpCall(HttpMethod.Get, $"{_config.GetValue<string>("Endpoints:ChuckBaseUrl")}{_config.GetValue<string>("Endpoints:ChuckRandomCategoryJoke")}{category}").Returns(httpResponseMessage);

            //Act
            var result = await _sut.GetRandomCategoryJokeAsync(category);

            //Assert
            result.Should().BeEquivalentTo(randomJokeResponse);
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
        // ~ChuckServiceTests()
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