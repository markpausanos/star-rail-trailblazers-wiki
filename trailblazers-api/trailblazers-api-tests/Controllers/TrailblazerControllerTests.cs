using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.Services.Trailblazers;
using Xunit;

namespace trailblazers_api.Tests.Controllers
{
    public class TrailblazersControllerTests
    {
        private readonly Mock<ILogger<TrailblazersController>> _loggerMock;
        private readonly Mock<ITrailblazerService> _trailblazerServiceMock;
        private readonly TrailblazersController _controller;

        public TrailblazersControllerTests()
        {
            _loggerMock = new Mock<ILogger<TrailblazersController>>();
            _trailblazerServiceMock = new Mock<ITrailblazerService>();
            _controller = new TrailblazersController(_loggerMock.Object, _trailblazerServiceMock.Object);
        }

        [Fact]
        public async Task CreateTrailblazer_ValidTrailblazer_ReturnsCreatedResponseWithTrailblazer()
        {
            // Arrange
            var trailblazerDto = new TrailblazerDto { Name = "TestName" };
            var trailblazerCreationDto = new TrailblazerCreationDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.CreateTrailblazer(trailblazerCreationDto)).ReturnsAsync(trailblazerDto);

            // Act
            var result = await _controller.CreateTrailblazer(trailblazerCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetTrailblazerById", result!.RouteName);
            Assert.Equal(trailblazerDto.Id, result!.RouteValues!["id"]);
            Assert.Equal(trailblazerDto, result!.Value);
        }

        [Fact]
        public async Task CreateTrailblazer_InvalidTrailblazer_ReturnsBadRequest()
        {
            // Arrange
            var trailblazerCreationDto = new TrailblazerCreationDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.CreateTrailblazer(trailblazerCreationDto)).ReturnsAsync((TrailblazerDto)null!);

            // Act
            var result = await _controller.CreateTrailblazer(trailblazerCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Trailblazer cannot be created.", result!.Value);
        }

        [Fact]
        public async Task CreateTrailblazer_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var trailblazerCreationDto = new TrailblazerCreationDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.CreateTrailblazer(trailblazerCreationDto)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.CreateTrailblazer(trailblazerCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the Trailblazer.", result!.Value);
        }

        [Fact]
        public async Task GetAllTrailblazers_ExistingTrailblazers_ReturnsOkResponseWithTrailblazers()
        {
            // Arrange
            var trailblazers = new List<TrailblazerDto> { new TrailblazerDto { Name = "TestName" } };
            _trailblazerServiceMock.Setup(x => x.GetAllTrailblazers()).ReturnsAsync(trailblazers);

            // Act
            var result = await _controller.GetAllTrailblazers() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(trailblazers, result!.Value);
        }

        [Fact]
        public async Task GetAllTrailblazers_NoTrailblazers_ReturnsNoContent()
        {
            // Arrange
            _trailblazerServiceMock.Setup(x => x.GetAllTrailblazers()).ReturnsAsync(new List<TrailblazerDto>());

            // Act
            var result = await _controller.GetAllTrailblazers() as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllTrailblazers_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _trailblazerServiceMock.Setup(x => x.GetAllTrailblazers()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllTrailblazers() as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving Trailblazers.", result!.Value);
        }

        [Fact]
        public async Task GetTrailblazerById_ExistingId_ReturnsOkResponseWithTrailblazer()
        {
            // Arrange
            var trailblazerDto = new TrailblazerDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ReturnsAsync(trailblazerDto);

            // Act
            var result = await _controller.GetTrailblazerByid(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(trailblazerDto, result!.Value);
        }

        [Fact]
        public async Task GetTrailblazerById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ReturnsAsync((TrailblazerDto)null!);

            // Act
            var result = await _controller.GetTrailblazerByid(1) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetTrailblazerById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetTrailblazerByid(1) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Trailblazer.", result!.Value);
        }

        [Fact]
        public async Task UpdateTrailblazer_ExistingIdAndValidTrailblazer_ReturnsOkResponseWithUpdatedTrailblazer()
        {
            // Arrange
            var trailblazerDto = new TrailblazerDto { Name = "TestName" };
            var trailblazerUpdateDto = new TrailblazerUpdateDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ReturnsAsync(trailblazerDto);
            _trailblazerServiceMock.Setup(x => x.UpdateTrailblazer(It.IsAny<int>(), trailblazerUpdateDto)).ReturnsAsync(true);
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ReturnsAsync(trailblazerDto);

            // Act
            var result = await _controller.UpdateTrailblazer(1, trailblazerUpdateDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(trailblazerDto, result!.Value);
        }

        [Fact]
        public async Task UpdateTrailblazer_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var trailblazerUpdateDto = new TrailblazerUpdateDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ReturnsAsync((TrailblazerDto)null!);

            // Act
            var result = await _controller.UpdateTrailblazer(1, trailblazerUpdateDto) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal("Trailblazer with ID = 1 does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateTrailblazer_ExistingIdAndInvalidTrailblazer_ReturnsBadRequest()
        {
            // Arrange
            var trailblazerDto = new TrailblazerDto { Name = "TestName" };
            var trailblazerUpdateDto = new TrailblazerUpdateDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ReturnsAsync(trailblazerDto);
            _trailblazerServiceMock.Setup(x => x.UpdateTrailblazer(It.IsAny<int>(), trailblazerUpdateDto)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateTrailblazer(1, trailblazerUpdateDto) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateTrailblazer_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var trailblazerUpdateDto = new TrailblazerUpdateDto { Name = "TestName" };
            _trailblazerServiceMock.Setup(x => x.GetTrailblazerById(It.IsAny<int>())).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.UpdateTrailblazer(1, trailblazerUpdateDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the Trailblazer.", result!.Value);
        }
    }
}
