using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Builds;
using trailblazers_api.Services.Builds;
using trailblazers_api.Services.Users;
using Microsoft.AspNetCore.Http;
using trailblazers_api.Dtos.Users;

namespace trailblazers_api.Tests.Controllers
{
    public class BuildControllerTests
    {
        private readonly Mock<ILogger<BuildsController>> _loggerMock;
        private readonly Mock<IBuildService> _buildServiceMock;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly BuildsController _controller;

        public BuildControllerTests()
        {
            _loggerMock = new Mock<ILogger<BuildsController>>();
            _buildServiceMock = new Mock<IBuildService>();
            _userServiceMock = new Mock<IUserService>();

            _controller = new BuildsController(_loggerMock.Object, _buildServiceMock.Object, _userServiceMock.Object);
        }

        [Fact]
        public async Task CreateBuild_ValidBuild_ReturnsCreated()
        {
            // Arrange
            var build = new BuildCreationDto {Name = "TestName" };
            var createdBuild = new BuildDto {Name = "TestName" };
            _buildServiceMock.Setup(mock => mock.CreateBuild(build)).ReturnsAsync(createdBuild);

            // Act
            var result = await _controller.CreateBuild(build) as CreatedResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal(createdBuild, result!.Value);
        }

        [Fact]
        public async Task CreateBuild_InvalidBuild_ReturnsBadRequest()
        {
            // Arrange
            var build = new BuildCreationDto {Name = "TestName" };
            _buildServiceMock.Setup(mock => mock.CreateBuild(build)).ReturnsAsync((BuildDto)null!);

            // Act
            var result = await _controller.CreateBuild(build) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Build cannot be created.", result!.Value);
        }

        [Fact]
        public async Task GetAllBuilds_ExistingUser_ReturnsBuilds()
        {
            // Arrange
            var user = new UserAccessDto { Id = 1, Name = "TestName" };
            var builds = new List<BuildDto> { new BuildDto { Name = "TestName" } };
            _userServiceMock.Setup(mock => mock.GetCurrentUser(It.IsAny<HttpContext>())).ReturnsAsync(user);
            _buildServiceMock.Setup(mock => mock.GetAllBuilds(user.Id)).ReturnsAsync(builds);

            // Act
            var result = await _controller.GetAllBuilds() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(builds, result!.Value);
        }

        [Fact]
        public async Task UpdateBuild_BuildNotFound_ReturnsNotFound()
        {
            // Arrange
            var id = 1;
            var newBuild = new BuildUpdateDto { Name = "TestName" };
            _buildServiceMock.Setup(mock => mock.GetBuildById(id)).ReturnsAsync((BuildDto)null!);

            // Act
            var result = await _controller.UpdateBuild(id, newBuild) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Build with ID = {id} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateBuild_UnknownError_ReturnsInternalServerError()
        {
            // Arrange
            var id = 1;
            var newBuild = new BuildUpdateDto { Name = "TestName" };
            _buildServiceMock.Setup(mock => mock.GetBuildById(id)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.UpdateBuild(id, newBuild) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the build.", result!.Value);
        }

        [Fact]
        public async Task DeleteBuild_ValidBuildId_ReturnsOk()
        {
            // Arrange
            var buildId = 1;
            _buildServiceMock.Setup(mock => mock.DeleteBuild(buildId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteBuild(buildId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted build with ID {buildId}.", result!.Value);
        }

        [Fact]
        public async Task DeleteBuild_InvalidBuildId_ReturnsBadRequest()
        {
            // Arrange
            var buildId = 1;
            _buildServiceMock.Setup(mock => mock.DeleteBuild(buildId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteBuild(buildId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }
    }
}
