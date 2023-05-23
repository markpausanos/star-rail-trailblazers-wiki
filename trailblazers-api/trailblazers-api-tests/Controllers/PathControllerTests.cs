using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Dtos.Paths;
using trailblazers_api.Services.Paths;
using Xunit;

namespace trailblazers_api.Controllers.Tests
{
    public class PathSRsControllerTests
    {
        private readonly Mock<ILogger<PathsController>> _loggerMock;
        private readonly Mock<IPathSRService> _pathSRServiceMock;
        private readonly PathsController _controller;

        public PathSRsControllerTests()
        {
            _loggerMock = new Mock<ILogger<PathsController>>();
            _pathSRServiceMock = new Mock<IPathSRService>();
            _controller = new PathsController(_loggerMock.Object, _pathSRServiceMock.Object);
        }

        [Fact]
        public async Task CreatePathSR_ValidPathSR_ReturnsCreatedAtRoute()
        {
            // Arrange
            var pathSRCreationDto = new PathSRCreationDto { Name = "TestName" };
            var newPathSR = new PathSRDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.CreatePathSR(pathSRCreationDto)).ReturnsAsync(newPathSR);

            // Act
            var result = await _controller.CreatePathSR(pathSRCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetPathById", result!.RouteName);
            Assert.Equal(newPathSR, result!.Value);
        }

        [Fact]
        public async Task CreatePathSR_InvalidPathSR_ReturnsBadRequest()
        {
            // Arrange
            var pathSRCreationDto = new PathSRCreationDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.CreatePathSR(pathSRCreationDto)).ReturnsAsync((PathSRDto)null!);

            // Act
            var result = await _controller.CreatePathSR(pathSRCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Path cannot be created.", result!.Value);
        }

        [Fact]
        public async Task CreatePathSR_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var pathSRCreationDto = new PathSRCreationDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.CreatePathSR(pathSRCreationDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.CreatePathSR(pathSRCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the Path.", result!.Value);
        }

        [Fact]
        public async Task GetAllPathSRs_NoName_ReturnsOkWithPathSRs()
        {
            // Arrange
            string? name = null;
            var pathSRs = new List<PathSRDto> { new PathSRDto { Name = "Name" } };
            _pathSRServiceMock.Setup(mock => mock.GetAllPathSRs()).ReturnsAsync(pathSRs);

            // Act
            var result = await _controller.GetAllPathSRs(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(pathSRs, result!.Value);
        }

        [Fact]
        public async Task GetAllPathSRs_WithName_ReturnsOkWithPathSR()
        {
            // Arrange
            var name = "SomePathSRName";
            var pathSR = new PathSRDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.GetPathSRByName(name)).ReturnsAsync(pathSR);

            // Act
            var result = await _controller.GetAllPathSRs(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(pathSR, result!.Value);
        }

        [Fact]
        public async Task GetAllPathSRs_NoPathSRs_ReturnsNoContent()
        {
            // Arrange
            string? name = null;
            _pathSRServiceMock.Setup(mock => mock.GetAllPathSRs()).ReturnsAsync(new List<PathSRDto>());

            // Act
            var result = await _controller.GetAllPathSRs(name) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllPathSRs_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string? name = null;
            _pathSRServiceMock.Setup(mock => mock.GetAllPathSRs()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetAllPathSRs(name) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Paths.", result!.Value);
        }

        [Fact]
        public async Task GetPathSRById_ExistingId_ReturnsOkWithPathSR()
        {
            // Arrange
            var pathSRId = 1;
            var pathSR = new PathSRDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync(pathSR);

            // Act
            var result = await _controller.GetPathSRById(pathSRId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(pathSR, result!.Value);
        }

        [Fact]
        public async Task GetPathSRById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var pathSRId = 1;
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync((PathSRDto)null!);

            // Act
            var result = await _controller.GetPathSRById(pathSRId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetPathSRById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var pathSRId = 1;
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetPathSRById(pathSRId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Path.", result!.Value);
        }

        [Fact]
        public async Task UpdatePathSR_ExistingId_ReturnsOkWithUpdatedPathSR()
        {
            // Arrange
            var pathSRId = 1;
            var newPathSR = new PathSRUpdateDto { Name = "UpdateName" };
            var pathSR = new PathSRDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync(pathSR);
            _pathSRServiceMock.Setup(mock => mock.UpdatePathSR(pathSRId, newPathSR)).ReturnsAsync(true);
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync(pathSR);

            // Act
            var result = await _controller.UpdatePathSR(pathSRId, newPathSR) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(pathSR, result!.Value);
        }

        [Fact]
        public async Task UpdatePathSR_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var pathSRId = 1;
            var newPathSR = new PathSRUpdateDto { Name = "UpdateName" };
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync((PathSRDto)null!);

            // Act
            var result = await _controller.UpdatePathSR(pathSRId, newPathSR) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Path with ID = {pathSRId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdatePathSR_UpdateFails_ReturnsBadRequest()
        {
            // Arrange
            var pathSRId = 1;
            var newPathSR = new PathSRUpdateDto { Name = "UpdateName" };
            var pathSR = new PathSRDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync(pathSR);
            _pathSRServiceMock.Setup(mock => mock.UpdatePathSR(pathSRId, newPathSR)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdatePathSR(pathSRId, newPathSR) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdatePathSR_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var pathSRId = 1;
            var newPathSR = new PathSRUpdateDto { Name = "UpdateName" };
            var pathSR = new PathSRDto { Name = "TestName" };
            _pathSRServiceMock.Setup(mock => mock.GetPathSRById(pathSRId)).ReturnsAsync(pathSR);
            _pathSRServiceMock.Setup(mock => mock.UpdatePathSR(pathSRId, newPathSR)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.UpdatePathSR(pathSRId, newPathSR) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the Path.", result!.Value);
        }

        [Fact]
        public async Task DeletePathSR_ExistingId_ReturnsOk()
        {
            // Arrange
            var pathSRId = 1;
            _pathSRServiceMock.Setup(mock => mock.DeletePathSR(pathSRId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeletePathSR(pathSRId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted path with ID {pathSRId}.", result!.Value);
        }

        [Fact]
        public async Task DeletePathSR_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var pathSRId = 1;
            _pathSRServiceMock.Setup(mock => mock.DeletePathSR(pathSRId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeletePathSR(pathSRId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task DeletePathSR_InternalServerError_ReturnsStatusCode500()
        {
            // Arrange
            var pathSRId = 1;
            _pathSRServiceMock.Setup(mock => mock.DeletePathSR(pathSRId)).ThrowsAsync(new Exception("Some error occurred."));

            // Act
            var result = await _controller.DeletePathSR(pathSRId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the Path.", result!.Value);
        }

        [Fact]
        public async Task DeletePathSR_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var pathSRId = 1;
            _pathSRServiceMock.Setup(mock => mock.DeletePathSR(pathSRId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.DeletePathSR(pathSRId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the Path.", result!.Value);
        }
    }
}
