using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Models;
using trailblazers_api.DTOs.Elements;
using trailblazers_api.Services.Elements;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly ILogger<ElementController> _logger;
        private readonly IElementService _service;

        public ElementController (ILogger<ElementController> logger, IElementService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Element.
        /// </summary>
        /// <param name="element">The Element to be created.</param>
        /// <returns>The newly created Element.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Elements
        /// {
        /// "name": "Fire",
        /// "image": "https://example.com/fire.png"
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Element was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateElement")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ElementDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateElement([FromForm] ElementCreationDto element)
        {
            try
            {
                var newElement = await _service.CreateElement(element);

                return CreatedAtRoute("GetElementById", new { id = newElement.Id }, newElement);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Element.");
            }
        }

        /// <summary>
        /// Gets all Elements in the database.
        /// </summary>
        /// <returns>IEnumerable with all Elements.</returns>
        /// <response code="200">The Elements were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet(Name = "GetAllElements")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ElementDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllElements()
        {
            try
            {
                var allElements = await _service.GetAllElements();

                if (allElements.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(allElements);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Elements.");
            }
        }

        /// <summary>
        /// Gets Element with the given Id from the database.
        /// </summary>
        /// <param name="id">Id of Element to be retrieved.</param>
        /// <returns>Element with Id.</returns>
        /// <response code="200">The Element was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Element details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetElementById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ElementDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetElementById(int id)
        {
            try
            {
                var element = await _service.GetElementById(id);

                if (element == null)
                {
                    return NoContent();
                }
                return Ok(element);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Element.");
            }
        }

        /// <summary>
        /// Updates Element with given data.
        /// </summary>
        /// <param name="updateElement">Data to update to the Element.</param>
        /// <returns>True if the updating was successful, false otherwise.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/Elements
        /// {
        /// "id": 3
        /// "name": "Fire",
        /// "image": "https://example.com/fire.png"
        /// }
        /// </remarks>
        /// <response code="200">The Element was successfully updated.</response>
        /// <response code="404">The Element was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdateElement")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateElement([FromForm] ElementUpdateDto updateElement)
        {
            try
            {
                int id = updateElement.Id;
                var element = await _service.GetElementById(id);
                if (element == null)
                {
                    return NotFound($"Element with ID = {id} does not exist.");
                }

                var updatedElement = await _service.UpdateElement(updateElement);
                return Ok(updatedElement);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Element.");
            }
        }

        /// <summary>
        /// Deletes an Element with the given Id
        /// </summary>
        /// <param name="id">Id of Element to be deleted</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        /// <response code="200">The Element was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Element was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpDelete("{id}", Name = "DeleteElement")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteElement(int id)
        {
            try
            {
                var element = await _service.GetElementById(id);
                if (element == null)
                {
                    return NotFound($"Element with ID = {id} not found.");
                }

                var isDeleted = await _service.DeleteElement(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Element with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Element.");
            }
        }
    }
}
