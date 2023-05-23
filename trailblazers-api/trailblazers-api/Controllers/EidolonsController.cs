using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Services.Eidolons;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EidolonsController : ControllerBase
    {
        private readonly ILogger<EidolonsController> _logger;
        private readonly IEidolonService _eidolonService;

        public EidolonsController(ILogger<EidolonsController> logger, IEidolonService service)
        {
            _logger = logger;
            _eidolonService = service;
        }

        /// <summary>
        /// Create a new eidolon.
        /// </summary>
        /// <param name="eidolon">The eidolon creation DTO.</param>
        /// <returns>The created eidolon.</returns>
        [HttpPost(Name = "CreateEidolon")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(EidolonDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateEidolon(EidolonCreationDto eidolon)
        {
            try
            {
                var newEidolon = await _eidolonService.CreateEidolon(eidolon);

                if (newEidolon == null)
                {
                    return BadRequest("Trailblazer does not exist or Eidolon Type already exists.");
                }

                return CreatedAtRoute("GetEidolonById", new { id = newEidolon.Id }, newEidolon);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the eidolon.");
            }
        }

        /// <summary>
        /// Get all eidolons or eidolons filtered by trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">Optional. The trailblazer ID to filter eidolons by.</param>
        /// <returns>A list of eidolons.</returns>
        [HttpGet(Name = "GetAllEidolons")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<EidolonDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllEidolons([FromQuery] int? trailblazerId)
        {
            try
            {
                var eidolons = trailblazerId == null ? await _eidolonService.GetAllEidolons() :
                    await _eidolonService.GetEidolonsByTrailblazerId((int)trailblazerId);

                if (eidolons.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(eidolons);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the eidolons.");
            }
        }

        /// <summary>
        /// Get a eidolon by ID.
        /// </summary>
        /// <param name="id">The eidolon ID.</param>
        /// <returns>The eidolon.</returns>
        [HttpGet("{id}", Name = "GetEidolonById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(EidolonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetEidolonById(int id)
        {
            try
            {
                var eidolon = await _eidolonService.GetEidolonById(id);

                if (eidolon == null)
                {
                    return NoContent();
                }

                return Ok(eidolon);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the eidolon.");
            }
        }
        /// <summary>
        /// Update a eidolon.
        /// </summary>
        /// <param name="id">The eidolon ID.</param>
        /// <param name="newEidolon">The updated eidolon DTO.</param>
        /// <returns>The updated eidolon.</returns>
        [HttpPut(Name = "UpdateEidolon")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(EidolonDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateEidolon(int id, [FromBody] EidolonUpdateDto newEidolon)
        {
            try
            {
                var eidolon = await _eidolonService.GetEidolonById(id);

                if (eidolon == null)
                {
                    return NotFound($"Eidolon with ID = {id} does not exist.");
                }

                newEidolon.Name ??= eidolon.Name;
                newEidolon.Description ??= eidolon.Description;
                newEidolon.Image ??= eidolon.Image;

                if (await _eidolonService.UpdateEidolon(id, newEidolon))
                {
                    var updatedEidolon = await _eidolonService.GetEidolonById(id);

                    return Ok(updatedEidolon);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the eidolon.");
            }
        }

        /// <summary>
        /// Delete a eidolon by ID.
        /// </summary>
        /// <param name="id">The eidolon ID.</param>
        /// <returns>A boolean indicating if the eidolon was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteEidolon")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEidolon(int id)
        {
            try
            {
                if (await _eidolonService.DeleteEidolon(id))
                {
                    return Ok($"Successfully deleted eidolon with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the eidolon.");
            }
        }
    }
}
