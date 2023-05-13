using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.DTOs.Ornaments;
using trailblazers_api.Services.Ornaments;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrnamentController : ControllerBase
    {
        private readonly ILogger<OrnamentController> _logger;
        private readonly IOrnamentService _service;

        public OrnamentController(ILogger<OrnamentController> logger, IOrnamentService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Ornament in the database.
        /// </summary>
        /// <param name="ornament">The Ornament object to be created.</param>
        /// <returns>An integer that represents the Id of the newly created Ornament.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Ornaments
        /// {
        /// "name": "Space Station 13",
        /// "description": "Ningguang Ghanglian",
        /// "image": "https://example.com/hss.png"
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Ornament was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateOrnament")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrnamentDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateOrnament([FromForm] OrnamentCreationDto ornament)
        {
            try
            {
                var newOrnamentId = await _service.CreateOrnament(ornament);
                var newOrnament = await _service.GetOrnamentById(newOrnamentId);

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
        /// <returns>An IEnumerable collection of Ornament objects.</returns>
        /// <response code="200">The Paths were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet(Name = "GetAllOrnaments")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<OrnamentDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllOrnaments()
        {
            try
            {
                var ornaments = await _service.GetAllOrnaments();

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
        /// <returns>A nullable Ornament object.</returns>
        /// <response code="200">The Ornament was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Ornament details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetOrnamentById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrnamentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrnamentById(int id)
        {
            try
            {
                var ornament = await _service.GetOrnamentById(id);

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
        /// Retrieves an Ornament object from the database by its Name.
        /// </summary>
        /// <param name="name">The Name of the Ornament to be retrieved.</param>
        /// <returns>A nullable Ornament object.</returns>
        /// <response code="200">The Ornament was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Ornament details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetOrnamentByName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(OrnamentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetOrnamentByName(string name)
        {
            try
            {
                var ornament = await _service.GetOrnamentByName(name);

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
        /// <param name="updateOrnament">The updated Ornament object.</param>
        /// <returns>A boolean value indicating whether the operation was successful.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/Ornaments
        /// {
        /// "id": 13,
        /// "name": "Space Station 13",
        /// "description": "Ningguang Ghanglian",
        /// "image": "https://example.com/hss.png"
        /// }
        /// }
        /// </remarks>
        /// <response code="200">The Ornament was successfully updated.</response>
        /// <response code="404">The Ornament was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdateOrnament")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateOrnament([FromForm] OrnamentUpdateDto updateOrnament)
        {
            try
            {
                int id = updateOrnament.Id;
                var ornament = await _service.GetOrnamentById(id);
                if (ornament == null)
                {
                    return NotFound($"Ornament with ID = {id} does not exist.");
                }

                var updatedOrnament = await _service.UpdateOrnament(updateOrnament);
                return Ok(updatedOrnament);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Ornament.");
            }
        }

        /// <summary>
        /// Deletes an Ornament object from the database.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be deleted.</param>
        /// <returns>A boolean value indicating whether the operation was successful.</returns>
        /// <response code="200">The Ornament was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Ornament was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
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
                var ornament = await _service.GetOrnamentById(id);
                if (ornament == null)
                {
                    return NotFound($"Ornament with ID = {id} not found.");
                }

                var isDeleted = await _service.DeleteOrnament(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Ornament with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Ornament.");
            }
        }
    }
}
