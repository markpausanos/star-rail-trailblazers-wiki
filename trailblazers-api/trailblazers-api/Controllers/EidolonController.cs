using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.DTOs.Eidolons;
using trailblazers_api.Services.Eidolons;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EidolonController : ControllerBase
    {
        private readonly ILogger<IEidolonService> _logger;
        private readonly IEidolonService _service;

        public EidolonController(ILogger<IEidolonService> logger, IEidolonService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Eidolon.
        /// </summary>
        /// <param name="eidolon">The Eidolon to be created.</param>
        /// <returns>The ID of the newly created Eidolon.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Eidolons
        /// {
        /// "name": "A Tall Figure",
        /// "description": "Using Skill will not remove Marks of Counter on the enemy"
        /// "image": "https://example.com/eidolon1.png"
        /// "order": 1
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Eidolon was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateEidolon")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(EidolonDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEidolon([FromForm] EidolonCreationDto eidolon)
        {
            try
            {
                var newEidolonId = await _service.CreateEidolon(eidolon);

                return CreatedAtAction(null, null, null, new { id = newEidolonId });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Eidolon.");
            }
        }

        /// <summary>
        /// Gets all Eidolons in the database with the provided TrailblazerID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the Trailblazer to retrieve the Eidolons</param>
        /// <returns>IEnumerable with the Eidolons.</returns>
        /// <response code="200">The Eidolons were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("id", Name = "GetAllEidolonsByTrailblazerId")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<EidolonDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEidolonsByTrailblazerId(int trailblazerId)
        {
            try
            {
                var trailblazerEidolons = await _service.GetAllEidolonsByTrailblazerId(trailblazerId);

                if (trailblazerEidolons.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(trailblazerEidolons);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Eidolons.");
            }
        }

        /// <summary>
        /// Updates Eidolon with given data.
        /// </summary>
        /// <param name="updateEidolon">Data to update to the Eidolon.</param>
        /// <returns>True if the updating was successful, false otherwise.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/Eidolons
        /// {
        /// "id": 9
        /// "name": "A Tall Figure",
        /// "description": "Using Skill will not remove Marks of Counter on the enemy"
        /// "image": "https://example.com/eidolon1.png"
        /// "order": 1
        /// }
        ///
        /// </remarks>
        /// <response code="200">The Eidolon was successfully updated.</response>
        /// <response code="404">The Eidolon was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdateEidolon")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEidolon([FromForm] EidolonUpdateDto updateEidolon)
        {
            try
            {
                int id = updateEidolon.Id;
                var updatedEidolon = await _service.UpdateEidolon(updateEidolon);
                return Ok(updatedEidolon);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Eidolon.");
            }
        }

        /// <summary>
        /// Deletes an Eidolon with the given Id
        /// </summary>
        /// <param name="id">Id of Eidolon to be deleted</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        /// <response code="200">The Eidolon was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Eidolon was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpDelete("{id}", Name = "DeleteEidolon")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEidolon(int id){
            try
            {
                var isDeleted = await _service.DeleteEidolon(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Eidolon with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Eidolon.");
            }
        }
    }
}
