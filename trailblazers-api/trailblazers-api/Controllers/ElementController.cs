using Microsoft.AspNetCore.Mvc;
using trailblazers_api.Models;
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
        /// <response code="400">The Element details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateElement")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Element), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateElement(Element element)
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
    }
}
