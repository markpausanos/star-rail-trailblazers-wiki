using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using trailblazers_api.DTOs.Paths;
using trailblazers_api.DTOs.Relics;
using trailblazers_api.Services.Relics;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelicController : ControllerBase
    {
        private readonly ILogger<RelicController> _logger;
        private readonly IRelicService _service;

        public RelicController(ILogger<RelicController> logger, IRelicService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Relic in the database.
        /// </summary>
        /// <param name="relic">The new Relic to be created.</param>
        /// <returns>The ID of the newly created Relic as an integer.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Relics
        /// {
        /// "name": "Relic name",
        /// "descriptionone": "relic desc 1",
        /// "descriptiontwo": "relic desc 2",
        /// "image": "https://example.com/relic1.png"
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Relic was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateRelic")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateRelic(RelicCreationDto relic)
        {
            try
            {
                var newRelicId = await _service.CreateRelic(relic);
                var newRelic = await _service.GetRelicById(newRelicId);

                return CreatedAtRoute("GetRelicById", new { id = newRelic.Id }, newRelic);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Relic.");
            }
        }

        /// <summary>
        /// Gets all Relics in the database.
        /// </summary>
        /// <returns>An IEnumerable of Relic objects.</returns>
        /// <response code="200">The Relics were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet(Name = "GetAllRelics")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<RelicDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllRelics()
        {
            try
            {
                var relics = await _service.GetAllRelics();

                if (relics.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(relics);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Relic.");
            }
        }

        /// <summary>
        /// Gets a Relic from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the Relic to get.</param>
        /// <returns>A nullable Relic object.</returns>
        /// <response code="200">The Relic was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Relic details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetRelicById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RelicDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRelicById(int id)
        {
            try
            {
                var relic = await _service.GetRelicById(id);

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
        /// Gets a Relic from the database by name.
        /// </summary>
        /// <param name="name">The name of the Relic to get.</param>
        /// <returns>A nullable Relic object.</returns>
        /// <response code="200">The Relic was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Relic details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{name}", Name = "GetRelicByName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(RelicDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetRelicByName(string name)
        {
            try
            {
                var relic = await _service.GetRelicByName(name);

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
        /// Updates a Relic in the database.
        /// </summary>
        /// <param name="relic">The updated Relic object.</param>
        /// <returns>
        ///     true: If the update was successful.
        ///     false: If the update was unsuccessful.
        /// </returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/Relics
        /// {
        /// "id": 2
        /// "name": "Relic name",
        /// "descriptionone": "relic desc 1",
        /// "descriptiontwo": "relic desc 2",
        /// "image": "https://example.com/relic1.png"
        /// }
        /// </remarks>
        /// <response code="200">The Relic was successfully updated.</response>
        /// <response code="404">The Relic was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdateRelic")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRelic(RelicUpdateDto updateRelic)
        {
            try
            {
                int id = updateRelic.Id;
                var relic = await _service.GetRelicById(id);
                if (relic == null)
                {
                    return NotFound($"Relic with ID = {id} does not exist.");
                }

                var updatedRelic = await _service.UpdateRelic(updateRelic);
                return Ok(updatedRelic);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Relic.");
            }
        }

        /// <summary>
        /// Soft deletes a Relic in the database.
        /// </summary>
        /// <param name="id">The ID of the Relic to be deleted.</param>
        /// <returns>
        ///     true: If the soft delete was successful.
        ///     false: If the soft delete was unsuccessful.
        /// </returns>
        /// <response code="200">The Relic was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Relic was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
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
                var relic = await _service.GetRelicById(id);
                if (relic == null)
                {
                    return NotFound($"Relic with ID = {id} not found.");
                }

                var isDeleted = await _service.DeleteRelic(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Relic with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Relic.");
            }
        }
    }
}
