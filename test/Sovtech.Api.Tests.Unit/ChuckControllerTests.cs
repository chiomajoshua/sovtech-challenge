using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Sovtech.API.Controllers;
using Sovtech.Data.Models.Chuck;

namespace Sovtech.Api.Tests.Unit
{
    public class ChuckControllerTests : IDisposable
    {
        private readonly IChuckService _chuckService = Substitute.For<IChuckService>();
        private readonly ChuckController _sut;
        private bool disposedValue;

        //Setup goes here
        public ChuckControllerTests()
        {
            _sut = new ChuckController(_chuckService);
        }

        [Fact]
        public async Task GetChuckCategories_Should_Return_Categories()
        {
            //Arrange
            var categoryResponse = new CategoriesResponse(new string[] { "Money", "Romance", "Police" });
            _chuckService.GetAllJokeCategoriesAsync().Returns(categoryResponse);

            //Act
            var result = (OkObjectResult)await _sut.GetChuckCategories();

            //Assert
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeEquivalentTo(categoryResponse);
        }

        [Fact]
        public async Task GetChuckCategories_Should_Return_NoCategories()
        {
            //Arrange
            CategoriesResponse categoryResponse = null;
            _chuckService.GetAllJokeCategoriesAsync().Returns(categoryResponse);

            //Act
            var result = (NotFoundResult)await _sut.GetChuckCategories();

            //Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task RandomJoke_ShouldReturnBadRequest_When_Category_IsNotPassed()
        {//Arrange
            CategoryResult randomJokeResponse = null;

            _chuckService.GetRandomCategoryJokeAsync(null).Returns(randomJokeResponse);

            //Act
            var result = (BadRequestObjectResult)await _sut.RandomJoke(null);

            //Assert
            result.StatusCode.Should().Be(400);
            result.Value.Should().Be("category is missing");

        }

        [Fact]
        public async Task RandomJoke_ShouldReturnJoke_When_Category_IsPassed()
        {
            //Arrange
            var randomJokeResponse = new CategoryResult(new List<string>() { "Money" }, "2020-01-05 13:42:20.841843", "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
                "ZaNUDPlKTROi6DL1Ii8LOQ", "2020-05-22 06:16:41.133769", "https://api.chucknorris.io/jokes/ZaNUDPlKTROi6DL1Ii8LOQ",
                "Chuck Norris knows how to shut down Skynet. Warner Bros beged him not to so they can make some money out of it.");

            _chuckService.GetRandomCategoryJokeAsync("Money").Returns(randomJokeResponse);

            //Act
            var result = (OkObjectResult)await _sut.RandomJoke("Money");

            //Assert
            result.StatusCode.Should().Be(200);
            result.Value.Should().BeEquivalentTo(randomJokeResponse);
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
        // ~ChuckControllerTests()
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