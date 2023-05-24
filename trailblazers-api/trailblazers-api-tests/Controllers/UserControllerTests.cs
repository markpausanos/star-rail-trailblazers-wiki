using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Users;
using trailblazers_api.Services.Users;

namespace trailblazers_api.Tests.Controllers
{
    public class UsersControllerTests
    {
        private readonly UsersController _controller;
        private readonly Mock<ILogger<IUserService>> _loggerMock;
        private readonly Mock<IUserService> _userServiceMock;

        public UsersControllerTests()
        {
            _loggerMock = new Mock<ILogger<IUserService>>();
            _userServiceMock = new Mock<IUserService>();
            _controller = new UsersController(_loggerMock.Object, _userServiceMock.Object);
        }

        [Fact]
        public async Task Login_ValidUser_ReturnsToken()
        {
            // Arrange
            var userLogin = new UserCreationLoginDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.Authenticate(userLogin)).ReturnsAsync(true);
            _userServiceMock.Setup(x => x.GenerateToken(userLogin)).ReturnsAsync("token");

            // Act
            var result = await _controller.Login(userLogin) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal("token", result!.Value);
        }

        [Fact]
        public async Task Login_InvalidUser_ReturnsNotFound()
        {
            // Arrange
            var userLogin = new UserCreationLoginDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.Authenticate(userLogin)).ReturnsAsync(false);

            // Act
            var result = await _controller.Login(userLogin) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal("Invalid credentials.", result!.Value);
        }

        [Fact]
        public async Task Login_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var userLogin = new UserCreationLoginDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.Authenticate(userLogin)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.Login(userLogin) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while logging in.", result!.Value);
        }

        [Fact]
        public async Task CreateUser_ValidUser_ReturnsAccessToken()
        {
            // Arrange
            var user = new UserCreationLoginDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.CreateUser(user)).ReturnsAsync("access_token");

            // Act
            var result = await _controller.CreateUser(user) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal("access_token", result!.Value);
        }

        [Fact]
        public async Task CreateUser_InvalidUser_ReturnsBadRequest()
        {
            // Arrange
            var user = new UserCreationLoginDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.CreateUser(user)).ReturnsAsync((string)null!);

            // Act
            var result = await _controller.CreateUser(user) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("User cannot be created.", result!.Value);
        }

        [Fact]
        public async Task CreateUser_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var user = new UserCreationLoginDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.CreateUser(user)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.CreateUser(user) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the User.", result!.Value);
        }

        [Fact]
        public async Task GetUserById_ExistingId_ReturnsUser()
        {
            // Arrange
            var userDto = new UserAccessDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync(userDto);

            // Act
            var result = await _controller.GetUserById(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(userDto, result!.Value);
        }

        [Fact]
        public async Task GetUserById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetUserById(It.IsAny<int>())).ReturnsAsync((UserAccessDto)null!);

            // Act
            var result = await _controller.GetUserById(1) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetUserById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetUserById(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetUserById(1) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the User.", result!.Value);
        }

        [Fact]
        public async Task GetUserByName_ExistingName_ReturnsUser()
        {
            // Arrange
            var userDto = new UserAccessDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.GetUserByName(It.IsAny<string>())).ReturnsAsync(userDto);

            // Act
            var result = await _controller.GetUserByName("username") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(userDto, result!.Value);
        }

        [Fact]
        public async Task GetUserByName_NonExistingName_ReturnsNoContent()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetUserByName(It.IsAny<string>())).ReturnsAsync((UserAccessDto)null!);

            // Act
            var result = await _controller.GetUserByName("username") as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetUserByName_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _userServiceMock.Setup(x => x.GetUserByName(It.IsAny<string>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetUserByName("username") as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the User.", result!.Value);
        }

        [Fact]
        public async Task UpdateUser_ValidUser_ReturnsOk()
        {
            // Arrange
            var newUser = new UserUpdateDto { Name = "TestName" };
            var currentUser = new UserAccessDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(currentUser);
            _userServiceMock.Setup(x => x.UpdateUserByName(newUser)).ReturnsAsync(true);

            // Act
            var result = await _controller.UpdateUser(newUser) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal("Updated password", result!.Value);
        }

        [Fact]
        public async Task UpdateUser_Unauthorized_ReturnsUnauthorized()
        {
            // Arrange
            var newUser = new UserUpdateDto { Name = "TestName" };
            var currentUser = new UserAccessDto { Name = "different_user" };
            _userServiceMock.Setup(x => x.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(currentUser);

            // Act
            var result = await _controller.UpdateUser(newUser) as UnauthorizedResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status401Unauthorized, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateUser_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var newUser = new UserUpdateDto { Name = "TestName" };
            var currentUser = new UserAccessDto { Name = "TestName" };
            _userServiceMock.Setup(x => x.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(currentUser);
            _userServiceMock.Setup(x => x.UpdateUserByName(newUser)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.UpdateUser(newUser) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the User.", result!.Value);
        }

        [Fact]
        public async Task DeleteUser_ValidUser_ReturnsOk()
        {
            // Arrange
            var name = "username";
            var currentUser = new UserAccessDto { Name = name };
            _userServiceMock.Setup(x => x.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(currentUser);
            _userServiceMock.Setup(x => x.DeleteUser(name)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteUser(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal("User deleted.", result!.Value);
        }

        [Fact]
        public async Task DeleteUser_Unauthorized_ReturnsUnauthorized()
        {
            // Arrange
            var name = "username";
            var currentUser = new UserAccessDto { Name = "different_user" };
            _userServiceMock.Setup(x => x.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(currentUser);

            // Act
            var result = await _controller.DeleteUser(name) as UnauthorizedResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status401Unauthorized, result!.StatusCode);
        }

        [Fact]
        public async Task DeleteUser_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var name = "username";
            var currentUser = new UserAccessDto { Name = name };
            _userServiceMock.Setup(x => x.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(currentUser);
            _userServiceMock.Setup(x => x.DeleteUser(name)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.DeleteUser(name) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the User.", result!.Value);
        }
    }
}
