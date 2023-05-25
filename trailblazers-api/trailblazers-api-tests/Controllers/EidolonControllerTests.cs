using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Services.Eidolons;
using Xunit;

namespace trailblazers_api.Tests.Controllers
{
    public class EidolonsControllerTests
    {
        private readonly Mock<ILogger<EidolonsController>> _loggerMock;
        private readonly Mock<IEidolonService> _eidolonServiceMock;
        private readonly EidolonsController _controller;

        public EidolonsControllerTests()
        {
            _loggerMock = new Mock<ILogger<EidolonsController>>();
            _eidolonServiceMock = new Mock<IEidolonService>();
            _controller = new EidolonsController(_loggerMock.Object, _eidolonServiceMock.Object);
        }

        [Fact]
        public async Task CreateEidolon_ValidEidolon_ReturnsCreated()
        {
            // Arrange
            var eidolonCreationDto = new EidolonCreationDto { Name = "TestName" };
            var createdEidolon = new EidolonDto { Name = "TestName" };
            _eidolonServiceMock.Setup(mock => mock.CreateEidolon(eidolonCreationDto)).ReturnsAsync(createdEidolon);

            // Act
            var result = await _controller.CreateEidolon(eidolonCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetEidolonById", result!.RouteName);
            Assert.Equal(createdEidolon, result!.Value);
            Assert.Equal(createdEidolon.Id, result!.RouteValues!["id"]);
        }

        [Fact]
        public async Task CreateEidolon_InvalidEidolon_ReturnsBadRequest()
        {
            // Arrange
            var eidolonCreationDto = new EidolonCreationDto { Name = "TestName" };
            _eidolonServiceMock.Setup(mock => mock.CreateEidolon(eidolonCreationDto)).ReturnsAsync((EidolonDto)null!);

            // Act
            var result = await _controller.CreateEidolon(eidolonCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Trailblazer does not exist or Eidolon Type already exists.", result!.Value);
        }

        [Fact]
        public async Task CreateEidolon_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var eidolonCreationDto = new EidolonCreationDto { Name = "TestName" };
            _eidolonServiceMock.Setup(mock => mock.CreateEidolon(eidolonCreationDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.CreateEidolon(eidolonCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the eidolon.", result!.Value);
        }

        [Fact]
        public async Task GetAllEidolons_NoTrailblazerId_ReturnsOkWithEidolons()
        {
            // Arrange
            var eidolons = new List<EidolonDto> { new EidolonDto { Name = "TestName" } };
            _eidolonServiceMock.Setup(mock => mock.GetAllEidolons()).ReturnsAsync(eidolons);

            // Act
            var result = await _controller.GetAllEidolons(null) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(eidolons, result!.Value);
        }

        [Fact]
        public async Task GetAllEidolons_WithTrailblazerId_ReturnsOkWithFilteredEidolons()
        {
            // Arrange
            var trailblazerId = 1;
            var eidolons = new List<EidolonDto> { new EidolonDto { Name = "TestName" } };
            _eidolonServiceMock.Setup(mock => mock.GetEidolonsByTrailblazerId(trailblazerId)).ReturnsAsync(eidolons);

            // Act
            var result = await _controller.GetAllEidolons(trailblazerId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(eidolons, result!.Value);
        }

        [Fact]
        public async Task GetAllEidolons_NoEidolons_ReturnsNoContent()
        {
            // Arrange
            _eidolonServiceMock.Setup(mock => mock.GetAllEidolons()).ReturnsAsync(new List<EidolonDto>());

            // Act
            var result = await _controller.GetAllEidolons(null) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllEidolons_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _eidolonServiceMock.Setup(mock => mock.GetAllEidolons()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetAllEidolons(null) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the eidolons.", result!.Value);
        }

        [Fact]
        public async Task GetEidolonById_ExistingId_ReturnsOkWithEidolon()
        {
            // Arrange
            var eidolonId = 1;
            var eidolon = new EidolonDto { Name = "TestName" };
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync(eidolon);

            // Act
            var result = await _controller.GetEidolonById(eidolonId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(eidolon, result!.Value);
        }

        [Fact]
        public async Task GetEidolonById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var eidolonId = 1;
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync((EidolonDto)null!);

            // Act
            var result = await _controller.GetEidolonById(eidolonId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetEidolonById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var eidolonId = 1;
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetEidolonById(eidolonId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the eidolon.", result!.Value);
        }

        [Fact]
        public async Task UpdateEidolon_ExistingIdAndValidEidolon_ReturnsOkWithUpdatedEidolon()
        {
            // Arrange
            var eidolonId = 1;
            var updatedEidolon = new EidolonDto { Name = "TestName" };
            var updateDto = new EidolonUpdateDto { Name = "UpdatedName" };
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync(updatedEidolon);
            _eidolonServiceMock.Setup(mock => mock.UpdateEidolon(eidolonId, updateDto)).ReturnsAsync(true);
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync(updatedEidolon);

            // Act
            var result = await _controller.UpdateEidolon(eidolonId, updateDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(updatedEidolon, result!.Value);
        }

        [Fact]
        public async Task UpdateEidolon_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var eidolonId = 1;
            var updateDto = new EidolonUpdateDto { Name = "UpdatedName" };
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync((EidolonDto)null!);

            // Act
            var result = await _controller.UpdateEidolon(eidolonId, updateDto) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Eidolon with ID = {eidolonId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateEidolon_ValidIdAndInvalidEidolon_ReturnsBadRequest()
        {
            // Arrange
            var eidolonId = 1;
            var eidolon = new EidolonDto { Name = "TestName" };
            var updateDto = new EidolonUpdateDto { Name = "UpdatedName" };
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync(eidolon);

            // Act
            var result = await _controller.UpdateEidolon(eidolonId, updateDto) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateEidolon_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var eidolonId = 1;
            var eidolon = new EidolonDto { Name = "TestName" };
            var updateDto = new EidolonUpdateDto { Name = "UpdatedName" };
            _eidolonServiceMock.Setup(mock => mock.GetEidolonById(eidolonId)).ReturnsAsync(eidolon);
            _eidolonServiceMock.Setup(mock => mock.UpdateEidolon(eidolonId, updateDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.UpdateEidolon(eidolonId, updateDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the eidolon.", result!.Value);
        }

        [Fact]
        public async Task DeleteEidolon_ExistingId_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var eidolonId = 1;
            _eidolonServiceMock.Setup(mock => mock.DeleteEidolon(eidolonId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteEidolon(eidolonId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted eidolon with ID {eidolonId}.", result!.Value);
        }

        [Fact]
        public async Task DeleteEidolon_NonExistingId_ReturnsBadRequest()
        {
            // Arrange
            var eidolonId = 1;
            _eidolonServiceMock.Setup(mock => mock.DeleteEidolon(eidolonId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteEidolon(eidolonId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task DeleteEidolon_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var eidolonId = 1;
            _eidolonServiceMock.Setup(mock => mock.DeleteEidolon(eidolonId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.DeleteEidolon(eidolonId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the eidolon.", result!.Value);
        }
    }
}
