using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using trailblazers_api.DTOs.Paths;
using trailblazers_api.DTOs.Relics;
using trailblazers_api.Services.Paths;
using Microsoft.IdentityModel.Tokens;

namespace trailblazers_api.Controllers
{
    /// <summary>
    /// Controller for managing Paths.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PathsController : ControllerBase
    {
        private readonly ILogger<PathsController> _logger;
        private readonly IPathSRService _pathService;

        public PathsController(ILogger<PathsController> logger, IPathSRService service)
        {
            _logger = logger;
            _pathService = service;
        }

        /// <summary>
        /// Creates a new PathSR.
        /// </summary>
        /// <param name="path">The PathSR creation data.</param>
        /// <returns>The created PathSR.</returns>
        [HttpPost(Name = "CreatePath")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(PathSRDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePathSR(PathSRCreationDto path)
        {
            try
            {
                var newPath = await _pathService.CreatePathSR(path);

                if (newPath == null)
                {
                    return BadRequest("Path cannot be created.");
                }

                return CreatedAtRoute("GetPathById", new { id = newPath.Id }, newPath);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Path.");
            }
        }

        /// <summary>
        /// Gets all PathSRs.
        /// </summary>
        /// <param name="name">Optional. Filter paths by name.</param>
        /// <returns>The list of PathSRs.</returns>
        [HttpGet(Name = "GetAllPaths")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<PathSRDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllPathSRs([FromQuery] string? name)
        {
            try
            {
                var paths = string.IsNullOrEmpty(name) ? await _pathService.GetAllPathSRs() :
                    new List<PathSRDto> { await _pathService.GetPathSRByName(name) };

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
        /// Gets a PathSR by ID.
        /// </summary>
        /// <param name="id">The ID of the PathSR to retrieve.</param>
        /// <returns>The PathSR with the specified ID.</returns>
        [HttpGet("{id}", Name = "GetPathById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PathSRDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPathSRById(int id)
        {
            try
            {
                var path = await _pathService.GetPathSRById(id);

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
        /// Updates a PathSR.
        /// </summary>
        /// <param name="id">The ID of the PathSR to update.</param>
        /// <param name="newPath">The updated PathSR data.</param>
        /// <returns>The updated PathSR.</returns>
        [HttpPut(Name = "UpdatePath")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePathSR(int id, [FromBody] PathSRUpdateDto newPath)
        {
            try
            {
                var path = await _pathService.GetPathSRById(id);

                if (path == null)
                {
                    return NotFound($"Path with ID = {id} does not exist.");
                }

                newPath.Name ??= path.Name;
                newPath.Image ??= path.Image;

                if (await _pathService.UpdatePathSR(id, newPath))
                {
                    var updatedPath = await _pathService.GetPathSRById(id);

                    return Ok(updatedPath);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Path.");
            }
        }

        /// <summary>
        /// Deletes a PathSR by ID.
        /// </summary>
        /// <param name="id">The ID of the PathSR to delete.</param>
        /// <returns>A boolean indicating whether the deletion was successful.</returns>
        [HttpDelete("{id}", Name = "DeletePath")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePathSR(int id)
        {
            try
            {
                if (await _pathService.DeletePathSR(id))
                {
                    return Ok($"Successfully deleted path with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Path.");
            }
        }
    }
}
