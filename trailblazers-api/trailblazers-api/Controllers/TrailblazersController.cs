using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// Creates a new Trailblazer.
        /// </summary>
        /// <param name="trailblazer">The Trailblazer data.</param>
        /// <returns>The created Trailblazer.</returns>
        [HttpPost(Name = "CreateTrailblazer")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(TrailblazerDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTrailblazer(TrailblazerCreationDto trailblazer)
        {
            try
            {
                var newTrailblazer = await _trailblazerService.CreateTrailblazer(trailblazer);

                if (newTrailblazer == null)
                {
                    return BadRequest("Trailblazer cannot be created.");
                }

                return CreatedAtRoute("GetTrailblazerById", new { id = newTrailblazer.Id }, newTrailblazer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Trailblazer.");
            }
        }

        /// <summary>
        /// Gets all Trailblazers.
        /// </summary>
        /// <returns>The list of Trailblazers.</returns>
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
                return StatusCode(500, "An error occurred while retrieving Trailblazers.");
            }
        }

        /// <summary>
        /// Gets a Trailblazer by its Id.
        /// </summary>
        /// <param name="id">The Id of the Trailblazer to retrieve.</param>
        /// <returns>The Trailblazer with the specified Id.</returns>
        [HttpGet("{id}", Name = "GetTrailblazerById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TrailblazerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTrailblazerByid(int id)
        {
            try
            {
                var trailblazer = await _trailblazerService.GetTrailblazerById(id);

                if (trailblazer == null)
                {
                    return NoContent();
                }

                return Ok(trailblazer);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Trailblazer.");
            }
        }

        /// <summary>
        /// Updates a Trailblazer.
        /// </summary>
        /// <param name="id">The Id of the Trailblazer to update.</param>
        /// <param name="newTrailblazer">The updated Trailblazer data.</param>
        /// <returns>The updated Trailblazer.</returns>
        [HttpPut(Name = "UpdateTrailblazer")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTrailblazer(int id, [FromBody] TrailblazerUpdateDto newTrailblazer)
        {
            try
            {
                var trailblazer = await _trailblazerService.GetTrailblazerById(id);

                if (trailblazer == null)
                {
                    return NotFound($"Trailblazer with ID = {id} does not exist.");
                }

                newTrailblazer.Name ??= trailblazer.Name;
                newTrailblazer.Image ??= trailblazer.Image;
                newTrailblazer.BaseAtk ??= trailblazer.BaseAtk;
                newTrailblazer.BaseHp ??= trailblazer.BaseHp;
                newTrailblazer.BaseDef ??= trailblazer.BaseDef;
                newTrailblazer.BaseSpeed ??= trailblazer.BaseSpeed;

                if (await _trailblazerService.UpdateTrailblazer(id, newTrailblazer))
                {
                    var updatedTrailblazer = await _trailblazerService.GetTrailblazerById(id);

                    return Ok(updatedTrailblazer);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Trailblazer.");
            }
        }
    }
}
