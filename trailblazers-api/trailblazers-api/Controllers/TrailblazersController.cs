using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.Services.Trailblazers;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailblazersController : ControllerBase
    {
        private readonly ILogger<TrailblazersController> _logger;
        private readonly ITrailblazerService _trailblazerService;

        public TrailblazersController(ILogger<TrailblazersController> logger, ITrailblazerService trailblazerService)
        {
            _logger = logger;
            _trailblazerService = trailblazerService;
        }

        [HttpGet(Name = "GetAllTrailblazers")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<TrailblazerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTrailblazers()
        {
            try
            {
                var trailblazers = await _trailblazerService.GetAllTrailblazers();

                if (trailblazers.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(trailblazers);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Relics.");
            }
        }
    }
}
