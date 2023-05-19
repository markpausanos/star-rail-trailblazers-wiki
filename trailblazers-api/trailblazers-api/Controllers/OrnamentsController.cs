using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Ornaments;
using trailblazers_api.Services.Ornaments;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrnamentsController : ControllerBase
    {
        private readonly ILogger<OrnamentsController> _logger;
        private readonly IOrnamentService _ornamentService;

        public OrnamentsController(ILogger<OrnamentsController> logger, IOrnamentService service)
        {
            _logger = logger;
            _ornamentService = service;
        }

        /// <summary>
        /// Creates a new Ornament in the database.
        /// </summary>
        /// <param name="ornament">The Ornament object to be created.</param>
        /// <returns>The created Ornament object.</returns>
        [HttpPost(Name = "CreateOrnament")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(OrnamentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrnament(OrnamentCreationDto ornament)
        {
            try
            {
                var newOrnament = await _ornamentService.CreateOrnament(ornament);

                if (newOrnament == null)
                {
                    return BadRequest("Ornament cannot be created.");
                }

                return CreatedAtRoute("GetOrnamentById", new { id = newOrnament.Id }, newOrnament);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Ornament.");
            }
        }

        /// <summary>
        /// Retrieves all Ornament objects from the database.
        /// </summary>
        /// <param name="name">Optional. Filters the ornaments by name.</param>
        /// <returns>An IEnumerable collection of Ornament objects.</returns>
        [HttpGet(Name = "GetAllOrnaments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<OrnamentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrnaments([FromQuery] string? name)
        {
            try
            {
                var ornaments = string.IsNullOrEmpty(name) ? await _ornamentService.GetAllOrnaments() :
                    new List<OrnamentDto> {  await _ornamentService.GetOrnamentByName(name) };

                if (ornaments.IsNullOrEmpty())
                {
                    return NoContent();
                }
                
                return Ok(ornaments);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Ornaments.");
            }
        }

        /// <summary>
        /// Retrieves an Ornament object from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be retrieved.</param>
        /// <returns>The Ornament object.</returns>
        [HttpGet("{id}", Name = "GetOrnamentById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrnamentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrnamentById(int id)
        {
            try
            {
                var ornament = await _ornamentService.GetOrnamentById(id);

                if (ornament == null)
                {
                    return NoContent();
                }

                return Ok(ornament);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Ornament.");
            }
        }

        /// <summary>
        /// Updates an Ornament object in the database.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be updated.</param>
        /// <param name="newOrnament">The updated Ornament object.</param>
        /// <returns>The updated Ornament object.</returns>
        [HttpPut(Name = "UpdateOrnament")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrnament(int id, [FromBody] OrnamentUpdateDto newOrnament)
        {
            try
            {
                var ornament = await _ornamentService.GetOrnamentById(id);

                if (ornament == null)
                {
                    return NotFound($"Ornament with ID = {id} does not exist.");
                }

                newOrnament.Name ??= ornament.Name;
                newOrnament.Description ??= ornament.Description;
                newOrnament.Image ??= ornament.Image;

                if (await _ornamentService.UpdateOrnament(id, newOrnament))
                {
                    var updatedOrnament = await _ornamentService.GetOrnamentById(id);

                    return Ok(updatedOrnament);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Ornament.");
            }
        }

        // <summary>
        /// Deletes an Ornament object from the database.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be deleted.</param>
        /// <returns>A boolean value indicating whether the operation was successful.</returns>
        [HttpDelete("{id}", Name = "DeleteOrnament")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteOrnament(int id)
        {
            try
            {
                if (await _ornamentService.DeleteOrnament(id))
                {
                    return Ok($"Successfully deleted ornament with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Ornament.");
            }
        }
    }
}
