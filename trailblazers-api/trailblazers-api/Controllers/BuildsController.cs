using Microsoft.AspNetCore.Mvc;
using trailblazers_api.DTOs.Builds;
using trailblazers_api.Services.Builds;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        private readonly ILogger<BuildsController> _logger;
        private readonly IBuildService _service;

        public BuildsController(ILogger<BuildsController> logger, IBuildService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Create a new Build in the Database.
        /// </summary>
        /// <param name="build">New Build to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Build</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Builds
        /// {
        /// "userid": 3,
        /// "trailblazerid": 6
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Build was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateBuild")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BuildDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBuild(BuildCreationDto build)
        {
            try
            {
                var newBuildId = await _service.CreateBuild(build);
                var newBuild = await _service.GetBuildById(newBuildId);

                return CreatedAtRoute("GetBuildById", new { id = newBuild.Id }, newBuild);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Build.");
            }
        }

        /// <summary>
        /// Gets Build in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Build to get in the database.</param>
        /// <returns>A nullable Build</returns>
        /// <response code="200">The Build was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Build details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetBuildById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BuildDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBuildById(int id)
        {
            try
            {
                var build = await _service.GetBuildById(id);

                if (build == null)
                {
                    return NoContent();
                }
                return Ok(build);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Build.");
            }
        }
    }
}
