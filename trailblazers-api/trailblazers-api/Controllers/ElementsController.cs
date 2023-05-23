using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Elements;
using trailblazers_api.Services.Elements;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementsController : ControllerBase
    {
        private readonly ILogger<ElementsController> _logger;
        private readonly IElementService _elementService;

        public ElementsController (ILogger<ElementsController> logger, IElementService service)
        {
            _logger = logger;
            _elementService = service;
        }

        /// <summary>
        /// Creates a new Element.
        /// </summary>
        /// <param name="element">The Element creation data.</param>
        /// <returns>The created Element.</returns>
        [HttpPost(Name = "CreateElement")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(ElementDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateElement(ElementCreationDto element)
        {
            try
            {
                var newElement = await _elementService.CreateElement(element);

                if (newElement == null)
                {
                    return BadRequest("Element cannot be created.");
                }

                return CreatedAtRoute("GetElementById", new { id = newElement.Id }, newElement);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Element.");
            }
        }

        /// <summary>
        /// Gets all Elements.
        /// </summary>
        /// <param name="name">Optional. Filter elements by name.</param>
        /// <returns>The list of Elements.</returns>
        [HttpGet(Name = "GetAllElements")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<ElementDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ElementDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllElements([FromQuery] string? name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    var elements = await _elementService.GetAllElements();

                    if (!elements.IsNullOrEmpty())
                    {
                        return Ok(elements);
                    }
                }
                else
                {
                    var element = await _elementService.GetElementByName(name);

                    if (element != null)
                    {
                        return Ok(element);
                    }
                }

                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Elements.");
            }
        }

        /// <summary>
        /// Gets a Element by ID.
        /// </summary>
        /// <param name="id">The ID of the Element to retrieve.</param>
        /// <returns>The Element with the specified ID.</returns>
        [HttpGet("{id}", Name = "GetElementById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ElementDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetElementById(int id)
        {
            try
            {
                var element = await _elementService.GetElementById(id);

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
        /// Updates a Element.
        /// </summary>
        /// <param name="id">The ID of the Element to update.</param>
        /// <param name="newElement">The updated Element data.</param>
        /// <returns>The updated Element.</returns>
        [HttpPut(Name = "UpdateElement")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateElement(int id, [FromBody] ElementUpdateDto newElement)
        {
            try
            {
                var element = await _elementService.GetElementById(id);

                if (element == null)
                {
                    return NotFound($"Element with ID = {id} does not exist.");
                }

                newElement.Name ??= element.Name;
                newElement.Image ??= element.Image;

                if (await _elementService.UpdateElement(id, newElement))
                {
                    var updatedElement = await _elementService.GetElementById(id);

                    return Ok(updatedElement);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Element.");
            }
        }

        /// <summary>
        /// Deletes a Element by ID.
        /// </summary>
        /// <param name="id">The ID of the Element to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete("{id}", Name = "DeleteElement")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteElement(int id)
        {
            try
            {
                if (await _elementService.DeleteElement(id))
                {
                    return Ok($"Successfully deleted element with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Element.");
            }
        }
    }
}
