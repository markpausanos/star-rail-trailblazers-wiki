using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Builds;
using trailblazers_api.Services.Builds;
using trailblazers_api.Services.Users;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildsController : ControllerBase
    {
        private readonly ILogger<BuildsController> _logger;
        private readonly IBuildService _buildService;
        private readonly IUserService _userService;

        public BuildsController(ILogger<BuildsController> logger, IBuildService buildService, IUserService userService)
        {
            _logger = logger;
            _buildService = buildService;
            _userService = userService;
        }

        /// <summary>
        /// Creates a new build.
        /// </summary>
        /// <param name="build">The build creation data.</param>
        /// <returns>The created build.</returns>
        [HttpPost(Name = "CreateBuild")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A, U")]
        [ProducesResponseType(typeof(BuildDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateBuild(BuildCreationDto build)
        {
            try
            {
                var newBuild = await _buildService.CreateBuild(build);

                if (newBuild == null)
                {
                    return BadRequest("Build cannot be created.");
                }

                return Created(new Uri($"api/Builds/{newBuild.Id}", UriKind.Relative), newBuild);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the build.");
            }
        }

        /// <summary>
        /// Retrieves all builds for the current user.
        /// </summary>
        /// <returns>The list of builds.</returns>
        [HttpGet(Name = "GetAllBuilds")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<BuildDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllBuilds()
        {
            try
            {
                var user = await _userService.GetCurrentUser(HttpContext);

                if (user == null)
                {
                    return NoContent();
                }

                var builds = await _buildService.GetAllBuilds(user.Id);

                if (builds.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(builds);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the builds.");
            }
        }

        /// <summary>
        /// Adds a like to a build.
        /// </summary>
        /// <param name="buildId">The ID of the build to like.</param>
        /// <returns>The updated build.</returns>
        [HttpPost("{buildId}/like", Name = "LikeBuild")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A, U")]
        [ProducesResponseType(typeof(BuildDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddLike(int buildId)
        {
            try
            {
                var user = await _userService.GetCurrentUser(HttpContext);

                if (user == null)
                {
                    return Unauthorized();
                }

                var like = await _buildService.AddLike(user.Id, buildId);

                return Ok(like);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while liking the build.");
            }
        }

        /// <summary>
        /// Removes a like from a build.
        /// </summary>
        /// <param name="buildId">The ID of the build to unlike.</param>
        /// <returns>The updated build.</returns>
        [HttpPost("{buildId}/unlike", Name = "UnlikeBuild")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A, U")]
        [ProducesResponseType(typeof(BuildDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveLike(int buildId)
        {
            try
            {
                var user = await _userService.GetCurrentUser(HttpContext);

                if (user == null)
                {
                    return Unauthorized();
                }

                var like = await _buildService.RemoveLike(user.Id, buildId);

                return Ok(like);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while disliking the build.");
            }
        }

        /// <summary>
        /// Update a build.
        /// </summary>
        /// <param name="id">The build ID.</param>
        /// <param name="newBuild">The updated build DTO.</param>
        /// <returns>The updated build.</returns>
        [HttpPut(Name = "UpdateBuild")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(BuildDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateBuild(int id, [FromBody] BuildUpdateDto newBuild)
        {
            try
            {
                var build = await _buildService.GetBuildById(id);

                if (build == null)
                {
                    return NotFound($"Build with ID = {id} does not exist.");
                }

                newBuild.Name ??= build.Name;
                newBuild.LightconeId ??= build.Lightcone!.Id;
                newBuild.RelicId ??= build.Relic!.Id;
                newBuild.OrnamentId ??= build.Ornament!.Id;

                if (await _buildService.UpdateBuild(id, newBuild))
                {
                    var updatedBuild = await _buildService.GetBuildById(id);

                    return Ok(updatedBuild);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the build.");
            }
        }

        /// <summary>
        /// Delete a build by ID.
        /// </summary>
        /// <param name="id">The build ID.</param>
        /// <returns>A boolean indicating if the build was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteBuild")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteBuild(int id)
        {
            try
            {
                if (await _buildService.DeleteBuild(id))
                {
                    return Ok($"Successfully deleted build with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the build.");
            }
        }
    }
}
