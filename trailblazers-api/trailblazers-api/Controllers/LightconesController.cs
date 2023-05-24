using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Services.Lightcones;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightconesController : ControllerBase
    {
        private readonly ILogger<LightconesController> _logger;
        private readonly ILightconeService _lightconeService;

        public LightconesController(ILogger<LightconesController> logger, ILightconeService service)
        {
            _logger = logger;
            _lightconeService = service;
        }

        /// <summary>
        /// Creates a new Lightcone.
        /// </summary>
        /// <param name="lightcone">The Lightcone creation data.</param>
        /// <returns>The created Lightcone.</returns>
        [HttpPost(Name = "CreateLightcone")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(LightconeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLightcone(LightconeCreationDto lightcone)
        {
            try
            {
                var newLightcone = await _lightconeService.CreateLightcone(lightcone);

                if (newLightcone == null)
                {
                    return BadRequest("Lightcone cannot be created.");
                }

                return CreatedAtRoute("GetLightconeById", new { id = newLightcone.Id }, newLightcone);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Lightcone.");
            }
        }

        /// <summary>
        /// Gets all Lightcones.
        /// </summary>
        /// <param name="name">Optional name filter.</param>
        /// <returns>A collection of Lightcones.</returns>
        [HttpGet(Name = "GetAllLightcones")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<LightconeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLightcones([FromQuery] string? name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    var lightcones = await _lightconeService.GetAllLightcones();

                    if (!lightcones.IsNullOrEmpty())
                    {
                        return Ok(lightcones);
                    }
                }
                else
                {
                    var lightcone = await _lightconeService.GetLightconeByName(name);

                    if (lightcone != null)
                    {
                        return Ok(lightcone);
                    }
                }

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Lightcones.");
            }
        }

        /// <summary>
        /// Gets a Lightcone by ID.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to retrieve.</param>
        /// <returns>The Lightcone with the specified ID.</returns>
        [HttpGet("{id}", Name = "GetLightconeById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LightconeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLightconeById(int id)
        {
            try
            {
                var lightcone = await _lightconeService.GetLightconeById(id);

                if (lightcone == null)
                {
                    return NoContent();
                }
                return Ok(lightcone);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Lightcone.");
            }
        }

        /// <summary>
        /// Updates a Lightcone.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to update.</param>
        /// <param name="newLightcone">The updated Lightcone data.</param>
        /// <returns>True if the update was successful, otherwise false.</returns>
        [HttpPut(Name = "UpdateLightcone")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLightcone(int id, [FromBody] LightconeUpdateDto newLightcone)
        {
            try
            {
                var lightcone = await _lightconeService.GetLightconeById(id);

                if (lightcone == null)
                {
                    return NotFound($"Lightcone with ID = {id} does not exist.");
                }

                newLightcone.Title ??= lightcone.Title;
                newLightcone.Name ??= lightcone.Name;
                newLightcone.Description ??= lightcone.Description;
                newLightcone.Image ??= lightcone.Image;
                newLightcone.Rarity ??= lightcone.Rarity;
                newLightcone.BaseHp ??= lightcone.BaseHp;
                newLightcone.BaseAtk ??= lightcone.BaseAtk;
                newLightcone.BaseDef ??= lightcone.BaseDef;

                if (await _lightconeService.UpdateLightcone(id, newLightcone))
                {
                    var updatedLightcone = await _lightconeService.GetLightconeById(id);

                    return Ok(updatedLightcone);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Lightcone.");
            }
        }

        /// <summary>
        /// Deletes a Lightcone by ID.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to delete.</param>
        /// <returns>True if the deletion was successful, otherwise false.</returns>
        [HttpDelete("{id}", Name = "DeleteLightcone")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteLightcone(int id)
        {
            try
            {
                if (await _lightconeService.DeleteLightcone(id))
                {
                    return Ok($"Successfully deleted lightcone with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Lightcone.");
            }
        }
    }
}
