using Microsoft.AspNetCore.Mvc;
using Sovtech.Core.Services.ChuckNorris.Interface;

namespace Sovtech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private readonly IChuckService _chuckService;        
        public ChuckController(IChuckService chuckService)
        {
            _chuckService = chuckService;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("/chuck/categories")]
        public async Task<IActionResult> GetChuckCategories()
        {
            var response = await _chuckService.GetAllJokeCategoriesAsync();
            if(response == null) 
                   return NotFound();
            return Ok(response);
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("/chuck/randomjoke")]
        public async Task<IActionResult> RandomJoke(string category)
        {
            if (string.IsNullOrEmpty(category) || string.IsNullOrWhiteSpace(category))
                return BadRequest("category is missing");
            return Ok(await _chuckService.GetRandomCategoryJokeAsync(category));
        }        
    }
}