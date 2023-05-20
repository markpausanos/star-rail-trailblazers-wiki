using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using trailblazers_api.Dtos.Users;
using trailblazers_api.Services.Users;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<IUserService> _logger;
        private readonly IUserService _userService;

        public UsersController(ILogger<IUserService> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        /// <summary>
        /// Authenticates the user and generates a token.
        /// </summary>
        /// <param name="userLogin">The user login information.</param>
        /// <returns>The generated token.</returns>
        [HttpPost("Login", Name = "Login")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login(UserCreationLoginDto userLogin)
        {
            try
            {
                var valid = await _userService.Authenticate(userLogin);

                if (valid)
                {
                    var token = await _userService.GenerateToken(userLogin);
                    return Ok(token);
                }

                return NotFound("Invalid credentials.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while logging in.");
            }
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="user">The user information.</param>
        /// <returns>The created user access token.</returns>
        [HttpPost(Name = "CreateUser")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UserAccessDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateUser(UserCreationLoginDto user)
        {
            try
            {
                var newUserToken = await _userService.CreateUser(user);

                if (newUserToken == null)
                {
                    return BadRequest("User cannot be created.");
                }

                return Ok(newUserToken);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the User.");
            }
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The retrieved user.</returns>
        [HttpGet("{id}", Name = "GetUserById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserAccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetUserById(id);

                if (user == null)
                {
                    return NoContent();
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the User.");
            }
        }

        /// <summary>
        /// Retrieves a user by their name.
        /// </summary>
        /// <param name="name">The user name.</param>
        /// <returns>The retrieved user.</returns>
        [HttpGet("{name}", Name = "GetUserByName")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(UserAccessDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUserByName(string name)
        {
            try
            {
                var user = await _userService.GetUserByName(name);

                if (user == null)
                {
                    return NoContent();
                }

                return Ok(user);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the User.");
            }
        }

        /// <summary>
        /// Updates the current user's password.
        /// </summary>
        /// <param name="newUser">The new user information.</param>
        /// <returns>A boolean indicating if the password was updated successfully.</returns>
        [HttpPut(Name = "UpdateUser")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDto newUser)
        {
            try
            {
                var currentUser = await _userService.GetCurrentUser(HttpContext);

                if (currentUser != null && currentUser.Name == newUser.Name)
                {
                    if (await _userService.UpdateUserByName(newUser))
                    {
                        return Ok("Updated password");
                    }
                }

                return Unauthorized();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the User.");
            }
        }

        /// <summary>
        /// Deletes a user by their name.
        /// </summary>
        /// <param name="name">The user name.</param>
        /// <returns>A boolean indicating if the user was deleted successfully.</returns>
        [HttpDelete("{name}", Name = "DeleteUser")]
        [Produces("application/json")]
        [Authorize(Roles = "A, U")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteUser(string name)
        {
            try
            {
                var currentUser = await _userService.GetCurrentUser(HttpContext);

                if (currentUser != null && currentUser.Name == name)
                {
                    if (await _userService.DeleteUser(name))
                    {
                        return Ok("User deleted.");
                    }
                }

                return Unauthorized();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the User.");
            }
        }
    }
}
