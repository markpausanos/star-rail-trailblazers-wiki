using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Services.Lightcones;
using Xunit;

namespace trailblazers_api.Tests.Controllers
{
    public class LightconesControllerTests
    {
        private readonly Mock<ILogger<LightconesController>> _loggerMock;
        private readonly Mock<ILightconeService> _lightconeServiceMock;
        private readonly LightconesController _controller;

        public LightconesControllerTests()
        {
            _loggerMock = new Mock<ILogger<LightconesController>>();
            _lightconeServiceMock = new Mock<ILightconeService>();
            _controller = new LightconesController(_loggerMock.Object, _lightconeServiceMock.Object);
        }

        [Fact]
        public async Task CreateLightcone_ValidLightcone_ReturnsCreatedAtRoute()
        {
            // Arrange
            var lightconeCreationDto = new LightconeCreationDto { Name = "TestName" };
            var newLightcone = new LightconeDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.CreateLightcone(lightconeCreationDto)).ReturnsAsync(newLightcone);

            // Act
            var result = await _controller.CreateLightcone(lightconeCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetLightconeById", result!.RouteName);
            Assert.Equal(newLightcone, result!.Value);
        }

        [Fact]
        public async Task CreateLightcone_InvalidLightcone_ReturnsBadRequest()
        {
            // Arrange
            var lightconeCreationDto = new LightconeCreationDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.CreateLightcone(lightconeCreationDto)).ReturnsAsync((LightconeDto)null!);

            // Act
            var result = await _controller.CreateLightcone(lightconeCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Lightcone cannot be created.", result!.Value);
        }

        [Fact]
        public async Task CreateLightcone_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var lightconeCreationDto = new LightconeCreationDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.CreateLightcone(lightconeCreationDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.CreateLightcone(lightconeCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the Lightcone.", result!.Value);
        }

        [Fact]
        public async Task GetAllLightcones_NoFilter_ReturnsOkWithLightcones()
        {
            // Arrange
            string name = null;
            var lightcones = new List<LightconeDto> { new LightconeDto { Name = "TestName" } };
            _lightconeServiceMock.Setup(mock => mock.GetAllLightcones()).ReturnsAsync(lightcones);

            // Act
            var result = await _controller.GetAllLightcones(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(lightcones, result!.Value);
        }

        [Fact]
        public async Task GetAllLightcones_WithFilter_ReturnsOkWithLightcone()
        {
            // Arrange
            var name = "LightconeName";
            var lightcone = new LightconeDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.GetLightconeByName(name)).ReturnsAsync(lightcone);

            // Act
            var result = await _controller.GetAllLightcones(name) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(lightcone, result!.Value);
        }

        [Fact]
        public async Task GetAllLightcones_NoResult_ReturnsNoContent()
        {
            // Arrange
            string name = null;
            _lightconeServiceMock.Setup(mock => mock.GetAllLightcones()).ReturnsAsync(new List<LightconeDto>());

            // Act
            var result = await _controller.GetAllLightcones(name) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllLightcones_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            string name = null;
            _lightconeServiceMock.Setup(mock => mock.GetAllLightcones()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetAllLightcones(name) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Lightcones.", result!.Value);
        }

        [Fact]
        public async Task GetLightconeById_ExistingId_ReturnsOkWithLightcone()
        {
            // Arrange
            var lightconeId = 1;
            var lightcone = new LightconeDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync(lightcone);

            // Act
            var result = await _controller.GetLightconeById(lightconeId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(lightcone, result!.Value);
        }

        [Fact]
        public async Task GetLightconeById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var lightconeId = 1;
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync((LightconeDto)null!);

            // Act
            var result = await _controller.GetLightconeById(lightconeId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetLightconeById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var lightconeId = 1;
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetLightconeById(lightconeId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the Lightcone.", result!.Value);
        }

        [Fact]
        public async Task UpdateLightcone_ExistingIdAndValidLightcone_ReturnsOkWithUpdatedLightcone()
        {
            // Arrange
            var lightconeId = 1;
            var newLightcone = new LightconeUpdateDto { Name = "UpdateName" };
            var lightcone = new LightconeDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync(lightcone);
            _lightconeServiceMock.Setup(mock => mock.UpdateLightcone(lightconeId, newLightcone)).ReturnsAsync(true);
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync(lightcone);

            // Act
            var result = await _controller.UpdateLightcone(lightconeId, newLightcone) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(lightcone, result!.Value);
        }

        [Fact]
        public async Task UpdateLightcone_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var lightconeId = 1;
            var newLightcone = new LightconeUpdateDto { /* set your desired updated lightcone here */ };
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync((LightconeDto)null!);

            // Act
            var result = await _controller.UpdateLightcone(lightconeId, newLightcone) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Lightcone with ID = {lightconeId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateLightcone_ExistingIdAndInvalidLightcone_ReturnsBadRequest()
        {
            // Arrange
            var lightconeId = 1;
            var newLightcone = new LightconeUpdateDto { Name = "UpdateName" };
            var lightcone = new LightconeDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync(lightcone);

            // Act
            var result = await _controller.UpdateLightcone(lightconeId, newLightcone) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateLightcone_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var lightconeId = 1;
            var newLightcone = new LightconeUpdateDto { Name = "UpdateName" };
            var lightcone = new LightconeDto { Name = "TestName" };
            _lightconeServiceMock.Setup(mock => mock.GetLightconeById(lightconeId)).ReturnsAsync(lightcone);
            _lightconeServiceMock.Setup(mock => mock.UpdateLightcone(lightconeId, newLightcone)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.UpdateLightcone(lightconeId, newLightcone) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the Lightcone.", result!.Value);
        }

        [Fact]
        public async Task DeleteLightcone_ExistingId_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var lightconeId = 1;
            _lightconeServiceMock.Setup(mock => mock.DeleteLightcone(lightconeId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteLightcone(lightconeId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted lightcone with ID {lightconeId}.", result!.Value);
        }

        [Fact]
        public async Task DeleteLightcone_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var lightconeId = 1;
            _lightconeServiceMock.Setup(mock => mock.DeleteLightcone(lightconeId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.DeleteLightcone(lightconeId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the Lightcone.", result!.Value);
        }
    }
}
