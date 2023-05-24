using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Relics;
using trailblazers_api.Services.Relics;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelicsController : ControllerBase
    {
        private readonly ILogger<RelicsController> _logger;
        private readonly IRelicService _relicService;

        public RelicsController(ILogger<RelicsController> logger, IRelicService relicService)
        {
            _logger = logger;
            _relicService = relicService;
        }

        /// <summary>
        /// Creates a new relic.
        /// </summary>
        /// <param name="relic">The relic creation DTO.</param>
        /// <returns>The created relic.</returns>
        [HttpPost(Name = "CreateRelic")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(RelicDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRelic(RelicCreationDto relic)
        {
            try
            {
                var newRelic = await _relicService.CreateRelic(relic);

                if (newRelic == null)
                {
                    return BadRequest("Relic cannot be created.");
                }

                return CreatedAtRoute("GetRelicById", new { id = newRelic.Id }, newRelic);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Relic.");
            }
        }

        /// <summary>
        /// Gets all relics.
        /// </summary>
        /// <param name="name">Optional. The name of the relic to filter.</param>
        /// <returns>The list of relics.</returns>
        [HttpGet(Name = "GetAllRelics")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<RelicDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RelicDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRelics([FromQuery] string? name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    var relics = await _relicService.GetAllRelics();

                    if (!relics.IsNullOrEmpty())
                    {
                        return Ok(relics);
                    }
                }
                else
                {
                    var relic = await _relicService.GetRelicByName(name);

                    if (relic != null)
                    {
                        return Ok(relic);
                    }
                }
               
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Relics.");
            }
        }

        /// <summary>
        /// Gets a relic by ID.
        /// </summary>
        /// <param name="id">The ID of the relic.</param>
        /// <returns>The retrieved relic.</returns
        [HttpGet("{id}", Name = "GetRelicById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RelicDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRelicById(int id)
        {
            try
            {
                var relic = await _relicService.GetRelicById(id);

                if (relic == null)
                {
                    return NoContent();
                }

                return Ok(relic);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Relic.");
            }
        }

        /// <summary>
        /// Updates a relic.
        /// </summary>
        /// <param name="id">The ID of the relic.</param>
        /// <param name="newRelic">The updated relic DTO.</param>
        /// <returns>True if the relic was updated successfully, otherwise false.</returns>
        [HttpPut(Name = "UpdateRelic")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRelic(int id, [FromBody] RelicUpdateDto newRelic)
        {
            try
            {
                var relic = await _relicService.GetRelicById(id);

                if (relic == null)
                {
                    return NotFound($"Relic with ID = {id} does not exist.");
                }

                newRelic.Name ??= relic.Name;
                newRelic.DescriptionOne ??= relic.DescriptionOne;
                newRelic.DescriptionTwo ??= relic.DescriptionTwo;
                newRelic.Image ??= relic.Image;

                if (await _relicService.UpdateRelic(id, newRelic))
                {
                    var updatedRelic = await _relicService.GetRelicById(id);

                    return Ok(updatedRelic);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Relic.");
            }
        }

        /// <summary>
        /// Deletes a relic by ID.
        /// </summary>
        /// <param name="id">The ID of the relic to delete.</param>
        /// <returns>True if the relic was deleted successfully, otherwise false.</returns>
        [HttpDelete("{id}", Name = "DeleteRelic")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteRelic(int id)
        {
            try
            {
                if (await _relicService.DeleteRelic(id))
                {
                    return Ok($"Successfully deleted relic with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Relic.");
            }
        }
    }
}
