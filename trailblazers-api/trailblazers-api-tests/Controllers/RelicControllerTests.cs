using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Dtos.Relics;
using trailblazers_api.Services.Relics;
using Xunit;

namespace trailblazers_api.Controllers.Tests
{
    public class RelicsControllerTests
    {
        private readonly Mock<ILogger<RelicsController>> _loggerMock;
        private readonly Mock<IRelicService> _relicServiceMock;
        private readonly RelicsController _controller;

        public RelicsControllerTests()
        {
            _loggerMock = new Mock<ILogger<RelicsController>>();
            _relicServiceMock = new Mock<IRelicService>();
            _controller = new RelicsController(_loggerMock.Object, _relicServiceMock.Object);
        }

        [Fact]
        public async Task CreateRelic_ValidRelic_ReturnsCreatedAtRoute()
        {
            // Arrange
            var relicCreationDto = new RelicCreationDto { Name = "TestName" };
            var newRelic = new RelicDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.CreateRelic(relicCreationDto)).ReturnsAsync(newRelic);

            // Act
            var result = await _controller.CreateRelic(relicCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetRelicById", result!.RouteName);
            Assert.Equal(newRelic, result!.Value);
        }

        [Fact]
        public async Task CreateRelic_InvalidRelic_ReturnsBadRequest()
        {
            // Arrange
            var relicCreationDto = new RelicCreationDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.CreateRelic(relicCreationDto)).ReturnsAsync((RelicDto)null!);

            // Act
            var result = await _controller.CreateRelic(relicCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Relic cannot be created.", result!.Value);
        }

        [Fact]
        public async Task CreateRelic_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var relicCreationDto = new RelicCreationDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.CreateRelic(relicCreationDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.CreateRelic(relicCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the Relic.", result!.Value);
        }

        [Fact]
        public async Task GetAllRelics_NoName_ReturnsOkWithRelics()
        {
            // Arrange
            string? name = null;
            var relics = new List<RelicDto> { new RelicDto { Name = "Name" } };
            _relicServiceMock.Setup(mock => mock.GetAllRelics()).ReturnsAsync(relics);

            // Act
            var result = await _controller.GetAllRelics(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(relics, result!.Value);
        }

        [Fact]
        public async Task GetAllRelics_WithName_ReturnsOkWithRelic()
        {
            // Arrange
            var name = "SomeRelicName";
            var relic = new RelicDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.GetRelicByName(name)).ReturnsAsync(relic);

            // Act
            var result = await _controller.GetAllRelics(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(relic, result!.Value);
        }

        [Fact]
        public async Task GetAllRelics_NoRelics_ReturnsNoContent()
        {
            // Arrange
            string? name = null;
            _relicServiceMock.Setup(mock => mock.GetAllRelics()).ReturnsAsync(new List<RelicDto>());

            // Act
            var result = await _controller.GetAllRelics(name) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllRelics_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string? name = null;
            _relicServiceMock.Setup(mock => mock.GetAllRelics()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetAllRelics(name) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Relics.", result!.Value);
        }

        [Fact]
        public async Task GetRelicById_ExistingId_ReturnsOkWithRelic()
        {
            // Arrange
            var relicId = 1;
            var relic = new RelicDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync(relic);

            // Act
            var result = await _controller.GetRelicById(relicId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(relic, result!.Value);
        }

        [Fact]
        public async Task GetRelicById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var relicId = 1;
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync((RelicDto)null!);

            // Act
            var result = await _controller.GetRelicById(relicId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetRelicById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var relicId = 1;
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetRelicById(relicId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Relic.", result!.Value);
        }

        [Fact]
        public async Task UpdateRelic_ExistingId_ReturnsOkWithUpdatedRelic()
        {
            // Arrange
            var relicId = 1;
            var newRelic = new RelicUpdateDto { Name = "UpdateName" };
            var relic = new RelicDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync(relic);
            _relicServiceMock.Setup(mock => mock.UpdateRelic(relicId, newRelic)).ReturnsAsync(true);
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync(relic);

            // Act
            var result = await _controller.UpdateRelic(relicId, newRelic) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(relic, result!.Value);
        }

        [Fact]
        public async Task UpdateRelic_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var relicId = 1;
            var newRelic = new RelicUpdateDto { Name = "UpdateName" };
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync((RelicDto)null!);

            // Act
            var result = await _controller.UpdateRelic(relicId, newRelic) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Relic with ID = {relicId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateRelic_UpdateFails_ReturnsBadRequest()
        {
            // Arrange
            var relicId = 1;
            var newRelic = new RelicUpdateDto { Name = "UpdateName" };
            var relic = new RelicDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync(relic);
            _relicServiceMock.Setup(mock => mock.UpdateRelic(relicId, newRelic)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateRelic(relicId, newRelic) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateRelic_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var relicId = 1;
            var newRelic = new RelicUpdateDto { Name = "UpdateName" };
            var relic = new RelicDto { Name = "TestName" };
            _relicServiceMock.Setup(mock => mock.GetRelicById(relicId)).ReturnsAsync(relic);
            _relicServiceMock.Setup(mock => mock.UpdateRelic(relicId, newRelic)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.UpdateRelic(relicId, newRelic) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the Relic.", result!.Value);
        }

        [Fact]
        public async Task DeleteRelic_ExistingId_ReturnsOk()
        {
            // Arrange
            var relicId = 1;
            _relicServiceMock.Setup(mock => mock.DeleteRelic(relicId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteRelic(relicId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted relic with ID {relicId}.", result!.Value);
        }

        [Fact]
        public async Task DeleteRelic_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var relicId = 1;
            _relicServiceMock.Setup(mock => mock.DeleteRelic(relicId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteRelic(relicId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task DeleteRelic_InternalServerError_ReturnsStatusCode500()
        {
            // Arrange
            var relicId = 1;
            _relicServiceMock.Setup(mock => mock.DeleteRelic(relicId)).ThrowsAsync(new Exception("Some error occurred."));

            // Act
            var result = await _controller.DeleteRelic(relicId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the Relic.", result!.Value);
        }

        [Fact]
        public async Task DeleteRelic_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var relicId = 1;
            _relicServiceMock.Setup(mock => mock.DeleteRelic(relicId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.DeleteRelic(relicId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the Relic.", result!.Value);
        }
    }
}
