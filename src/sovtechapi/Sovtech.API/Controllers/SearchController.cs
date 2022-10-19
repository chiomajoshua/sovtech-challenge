using Microsoft.AspNetCore.Mvc;
using Sovtech.Core.Services.Search.Interface;

namespace Sovtech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("/search")]
        public async Task<IActionResult> Get(string phrase)
        {
            if (string.IsNullOrEmpty(phrase) || string.IsNullOrWhiteSpace(phrase))
                return BadRequest("search query is missing");

            var response = await _searchService.Search(phrase);
            
            if(response is null)
                return NotFound($"{phrase} does not exist");
            
            return Ok(new { chuck = response.Item1, swapi = response.Item2 });
        }
    }
}