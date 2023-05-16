using Microsoft.AspNetCore.Mvc;
using trailblazers_api.Dtos.Users;
using trailblazers_api.Services.Users;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<IUserService> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<IUserService> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpPost("Login", Name = "LoginTest")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] UserCreationLoginDto userLogin)
        {
            try
            {
                var user = await _userService.Authenticate(userLogin);

                if (user != null)
                {
                    var token = await _userService.GenerateToken(userLogin);
                    return Ok(token);
                }

                return NotFound("User not found.");

            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while logging in.");
            }
        }
        //private UserAccessDto? GetCurrentUser()
        //{
        //    var identity = HttpContext.User.Identity as ClaimsIdentity;

        //    if (identity != null)
        //    {
        //        var userClaims = identity.Claims;

        //        return new UserAccessDto
        //        {
        //            Name = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value!,
        //            Role = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value!,
        //        };
        //    }
        //    return null;
        //}
    }
}
