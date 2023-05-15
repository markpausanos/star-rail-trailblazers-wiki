using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.DTOs.Paths;
using trailblazers_api.Services.Paths;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PathSRController : ControllerBase
    {
        private readonly ILogger<PathSRController> _logger;
        private readonly IPathSRService _service;

        public PathSRController(ILogger<PathSRController> logger, IPathSRService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Path.
        /// </summary>
        /// <param name="path">The Path to be created.</param>
        /// <returns>The the newly created Path.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/PathSR
        /// {
        /// "name": "Abundance",
        /// "image": "https://example.com/abundance.png"
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Path was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreatePath")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PathSRDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePathSR([FromForm] PathSRCreationDto path)
        {
            try
            {
                var newPathId = await _service.CreatePathSR(path);
                var newPath = await _service.GetPathSRById(newPathId);

                return CreatedAtRoute("GetPathById", new { id = newPath.Id }, newPath);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Path.");
            }
        }

        /// <summary>
        /// Gets all Paths in the database.
        /// </summary>
        /// <returns>IEnumerable with all Paths.</returns>
        /// <response code="200">The Paths were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet(Name = "GetAllPaths")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PathSRDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPathSRs()
        {
            try
            {
                var paths = await _service.GetAllPathSRs();

                if (paths.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(paths);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Paths.");
            }
        }

        /// <summary>
        /// Gets Path with the given Id from the database.
        /// </summary>
        /// <param name="id">Id of Path to be retrieved.</param>
        /// <returns>Path with Id.</returns>
        /// <response code="200">The Path was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Path details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetPathById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PathSRDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPathSRById(int id)
        {
            try
            {
                var path = await _service.GetPathSRById(id);

                if (path == null)
                {
                    return NoContent();
                }
                return Ok(path);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Path.");
            }
        }

        /// <summary>
        /// Gets Path with the given Name from the database.
        /// </summary>
        /// <param name="id">Name of Path to be retrieved.</param>
        /// <returns>Path with Name.</returns>
        /// <response code="200">The Path was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Path details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{name}", Name = "GetPathByName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PathSRDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPathSRByName(string name)
        {
            try
            {
                var path = await _service.GetPathSRByName(name);

                if (path == null)
                {
                    return NoContent();
                }
                return Ok(path);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Path.");
            }
        }

        /// <summary>
        /// Updates Path with given data.
        /// </summary>
        /// <param name="updatePath">Data to update to the Path.</param>
        /// <returns>True if the updating was successful, false otherwise.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/PathSR
        /// {
        /// "id": 2
        /// "name": "Abundance",
        /// "image": "https://example.com/abundance.png"
        /// }
        /// </remarks>
        /// <response code="200">The Path was successfully updated.</response>
        /// <response code="404">The Path was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdatePath")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePathSR([FromForm] PathSRUpdateDto updatePath)
        {
            try
            {
                int id = updatePath.Id;
                var path = await _service.GetPathSRById(id);
                if (path == null)
                {
                    return NotFound($"Path with ID = {id} does not exist.");
                }

                var updatedPath = await _service.UpdatePathSR(updatePath);
                return Ok(updatedPath);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Path.");
            }
        }

        /// <summary>
        /// Deletes an Path with the given Id
        /// </summary>
        /// <param name="id">Id of Path to be deleted</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        /// <response code="200">The Path was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Path was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpDelete("{id}", Name = "DeletePath")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePathSR(int id)
        {
            try
            {
                var path = await _service.GetPathSRById(id);
                if (path == null)
                {
                    return NotFound($"Path with ID = {id} not found.");
                }

                var isDeleted = await _service.DeletePathSR(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Path with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Path.");
            }
        }
    }
}
