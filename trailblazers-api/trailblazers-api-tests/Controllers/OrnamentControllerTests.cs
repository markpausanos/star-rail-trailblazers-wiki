using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Dtos.Ornaments;
using trailblazers_api.Services.Ornaments;
using Xunit;

namespace trailblazers_api.Controllers.Tests
{
    public class OrnamentsControllerTests
    {
        private readonly Mock<ILogger<OrnamentsController>> _loggerMock;
        private readonly Mock<IOrnamentService> _ornamentServiceMock;
        private readonly OrnamentsController _controller;

        public OrnamentsControllerTests()
        {
            _loggerMock = new Mock<ILogger<OrnamentsController>>();
            _ornamentServiceMock = new Mock<IOrnamentService>();
            _controller = new OrnamentsController(_loggerMock.Object, _ornamentServiceMock.Object);
        }

        [Fact]
        public async Task CreateOrnament_ValidOrnament_ReturnsCreatedAtRoute()
        {
            // Arrange
            var ornamentCreationDto = new OrnamentCreationDto { Name = "TestName" };
            var newOrnament = new OrnamentDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.CreateOrnament(ornamentCreationDto)).ReturnsAsync(newOrnament);

            // Act
            var result = await _controller.CreateOrnament(ornamentCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetOrnamentById", result!.RouteName);
            Assert.Equal(newOrnament, result!.Value);
        }

        [Fact]
        public async Task CreateOrnament_InvalidOrnament_ReturnsBadRequest()
        {
            // Arrange
            var ornamentCreationDto = new OrnamentCreationDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.CreateOrnament(ornamentCreationDto)).ReturnsAsync((OrnamentDto)null!);

            // Act
            var result = await _controller.CreateOrnament(ornamentCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Ornament cannot be created.", result!.Value);
        }

        [Fact]
        public async Task CreateOrnament_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var ornamentCreationDto = new OrnamentCreationDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.CreateOrnament(ornamentCreationDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.CreateOrnament(ornamentCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the Ornament.", result!.Value);
        }

        [Fact]
        public async Task GetAllOrnaments_NoName_ReturnsOkWithOrnaments()
        {
            // Arrange
            string? name = null;
            var ornaments = new List<OrnamentDto> { new OrnamentDto { Name = "Name" } };
            _ornamentServiceMock.Setup(mock => mock.GetAllOrnaments()).ReturnsAsync(ornaments);

            // Act
            var result = await _controller.GetAllOrnaments(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(ornaments, result!.Value);
        }

        [Fact]
        public async Task GetAllOrnaments_WithName_ReturnsOkWithOrnament()
        {
            // Arrange
            var name = "SomeOrnamentName";
            var ornament = new OrnamentDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentByName(name)).ReturnsAsync(ornament);

            // Act
            var result = await _controller.GetAllOrnaments(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(ornament, result!.Value);
        }

        [Fact]
        public async Task GetAllOrnaments_NoOrnaments_ReturnsNoContent()
        {
            // Arrange
            string? name = null;
            _ornamentServiceMock.Setup(mock => mock.GetAllOrnaments()).ReturnsAsync(new List<OrnamentDto>());

            // Act
            var result = await _controller.GetAllOrnaments(name) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllOrnaments_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string? name = null;
            _ornamentServiceMock.Setup(mock => mock.GetAllOrnaments()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetAllOrnaments(name) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Ornaments.", result!.Value);
        }

        [Fact]
        public async Task GetOrnamentById_ExistingId_ReturnsOkWithOrnament()
        {
            // Arrange
            var ornamentId = 1;
            var ornament = new OrnamentDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync(ornament);

            // Act
            var result = await _controller.GetOrnamentById(ornamentId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(ornament, result!.Value);
        }

        [Fact]
        public async Task GetOrnamentById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var ornamentId = 1;
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync((OrnamentDto)null!);

            // Act
            var result = await _controller.GetOrnamentById(ornamentId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetOrnamentById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var ornamentId = 1;
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetOrnamentById(ornamentId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Ornament.", result!.Value);
        }

        [Fact]
        public async Task UpdateOrnament_ExistingId_ReturnsOkWithUpdatedOrnament()
        {
            // Arrange
            var ornamentId = 1;
            var newOrnament = new OrnamentUpdateDto { Name = "UpdateName" };
            var ornament = new OrnamentDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync(ornament);
            _ornamentServiceMock.Setup(mock => mock.UpdateOrnament(ornamentId, newOrnament)).ReturnsAsync(true);
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync(ornament);

            // Act
            var result = await _controller.UpdateOrnament(ornamentId, newOrnament) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(ornament, result!.Value);
        }

        [Fact]
        public async Task UpdateOrnament_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var ornamentId = 1;
            var newOrnament = new OrnamentUpdateDto { Name = "UpdateName" };
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync((OrnamentDto)null!);

            // Act
            var result = await _controller.UpdateOrnament(ornamentId, newOrnament) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Ornament with ID = {ornamentId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateOrnament_UpdateFails_ReturnsBadRequest()
        {
            // Arrange
            var ornamentId = 1;
            var newOrnament = new OrnamentUpdateDto { Name = "UpdateName" };
            var ornament = new OrnamentDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync(ornament);
            _ornamentServiceMock.Setup(mock => mock.UpdateOrnament(ornamentId, newOrnament)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateOrnament(ornamentId, newOrnament) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateOrnament_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var ornamentId = 1;
            var newOrnament = new OrnamentUpdateDto { Name = "UpdateName" };
            var ornament = new OrnamentDto { Name = "TestName" };
            _ornamentServiceMock.Setup(mock => mock.GetOrnamentById(ornamentId)).ReturnsAsync(ornament);
            _ornamentServiceMock.Setup(mock => mock.UpdateOrnament(ornamentId, newOrnament)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.UpdateOrnament(ornamentId, newOrnament) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the Ornament.", result!.Value);
        }

        [Fact]
        public async Task DeleteOrnament_ExistingId_ReturnsOk()
        {
            // Arrange
            var ornamentId = 1;
            _ornamentServiceMock.Setup(mock => mock.DeleteOrnament(ornamentId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteOrnament(ornamentId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result.StatusCode);
            Assert.Equal($"Successfully deleted ornament with ID {ornamentId}.", result.Value);
        }

        [Fact]
        public async Task DeleteOrnament_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var ornamentId = 1;
            _ornamentServiceMock.Setup(mock => mock.DeleteOrnament(ornamentId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteOrnament(ornamentId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result.StatusCode);
        }

        [Fact]
        public async Task DeleteOrnament_InternalServerError_ReturnsStatusCode500()
        {
            // Arrange
            var ornamentId = 1;
            _ornamentServiceMock.Setup(mock => mock.DeleteOrnament(ornamentId)).ThrowsAsync(new Exception("Some error occurred."));

            // Act
            var result = await _controller.DeleteOrnament(ornamentId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result.StatusCode);
            Assert.Equal("An error occurred while deleting the Ornament.", result.Value);
        }

        [Fact]
        public async Task DeleteOrnament_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var ornamentId = 1;
            _ornamentServiceMock.Setup(mock => mock.DeleteOrnament(ornamentId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.DeleteOrnament(ornamentId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the Ornament.", result!.Value);
        }
    }
}
