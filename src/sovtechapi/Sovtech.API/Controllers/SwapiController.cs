using Microsoft.AspNetCore.Mvc;
using Sovtech.Core.Services.StarWars.Interface;

namespace Sovtech.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly IStarWarsService _starWarsService;
        public SwapiController(IStarWarsService starWarsService)
        {
            _starWarsService = starWarsService;
        }

        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet, Route("/swapi/people")]
        public async Task<IActionResult> GetSwapiPeople(int page = 1)
        {
            var response = await _starWarsService.GetPeople(page);
            if (response == null) return NotFound();
            return Ok(response);
        }
    }
}