using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using trailblazers_api.DTOs.Lightcones;
using trailblazers_api.DTOs.Paths;
using trailblazers_api.Models;
using trailblazers_api.Services.Lightcones;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LightconesController : ControllerBase
    {
        private readonly ILogger<LightconesController> _logger;
        private readonly ILightconeService _service;

        public LightconesController(ILogger<LightconesController> logger, ILightconeService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Lightcone.
        /// </summary>
        /// <param name="path">The Lightcone to be created.</param>
        /// <returns>The Id of the newly created Lightcone.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Lightcones
        /// {
        /// "title": "Meditation",
        /// "name": "Family",
        /// "description": "A drop of strength...",
        /// "image": "https://example.com/meditation.png",
        /// "rarity": 3,
        /// "basehp": 38,
        /// "baseatk": 14,
        /// "basedef": 12
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Lightcone was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateLightcone")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LightconeDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateLightcone([FromForm] LightconeCreationDto lightcone)
        {
            try
            {
                var newLightconeId = await _service.CreateLightcone(lightcone);
                var newLightcone = await _service.GetLightconeById(newLightconeId);

                return CreatedAtRoute("GetLightconeById", new { id = newLightcone.Id }, newLightcone);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Lightcone.");
            }
        }

        /// <summary>
        /// Gets all Lightcones in the database.
        /// </summary>
        /// <returns>IEnumerable with all Lightcones.</returns>
        /// <response code="200">The Lightcones were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet(Name = "GetAllLightcones")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<LightconeDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllLightcones()
        {
            try
            {
                var lightcones = await _service.GetAllLightcones();

                if (lightcones.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(lightcones);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Lightcones.");
            }
        }

        /// <summary>
        /// Gets Lightcone with the given Id from the database.
        /// </summary>
        /// <param name="id">Id of Lightcone to be retrieved.</param>
        /// <returns>Lightcone with Id.</returns>
        /// <response code="200">The Lightcone was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Path details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetLightconeById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LightconeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLightconeById(int id)
        {
            try
            {
                var lightcone = await _service.GetLightconeById(id);

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
        /// Gets Lightcone with the given Name from the database.
        /// </summary>
        /// <param name="name">Name of Lightcone to be retrieved.</param>
        /// <returns>Lightcone with Name.</returns>
        /// <response code="200">The Lightcone was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Lightcone details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{name}", Name = "GetLightconeByName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(LightconeDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLightconeByName(string name)
        {
            try
            {
                var lightcone = await _service.GetLightconeByName(name);

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
        /// Updates Lightcone with given data.
        /// </summary>
        /// <param name="updateLightcone">Data to update to the Lightcone.</param>
        /// <returns>True if the updating was successful, false otherwise.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Lightcones
        /// {
        /// "id": 2
        /// "title": "Meditation",
        /// "name": "Family",
        /// "description": "A drop of strength...",
        /// "image": "https://example.com/meditation.png",
        /// "rarity": 3,
        /// "basehp": 38,
        /// "baseatk": 14,
        /// "basedef": 12
        /// }
        /// 
        /// </remarks>
        /// <response code="200">The Lightcone was successfully updated.</response>
        /// <response code="404">The Lightcone was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdateLightcone")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateLightcone([FromForm] LightconeUpdateDto updateLightcone)
        {
            try
            {
                int id = updateLightcone.Id;
                var lightcone = await _service.GetLightconeById(id);
                if (lightcone == null)
                {
                    return NotFound($"Lightcone with ID = {id} does not exist.");
                }

                var updatedLightcone = await _service.UpdateLightcone(updateLightcone);
                return Ok(updatedLightcone);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Lightcone.");
            }
        }

        /// <summary>
        /// Deletes an Lightcone with the given Id
        /// </summary>
        /// <param name="id">Id of Lightcone to be deleted</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        /// <response code="200">The Lightcone was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Lightcone was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
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
                var lightcone = await _service.GetLightconeById(id);
                if (lightcone == null)
                {
                    return NotFound($"Lightcone with ID = {id} not found.");
                }

                var isDeleted = await _service.DeleteLightcone(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Lightcone with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Lightcone.");
            }
        }
    }
}
