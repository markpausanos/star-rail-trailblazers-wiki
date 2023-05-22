using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Traces;
using trailblazers_api.Services.Traces;
using Xunit;

namespace trailblazers_api.Tests.Controllers
{
    public class TracesControllerTests
    {
        private readonly Mock<ILogger<TracesController>> _loggerMock;
        private readonly Mock<ITraceService> _traceServiceMock;
        private readonly TracesController _controller;

        public TracesControllerTests()
        {
            _loggerMock = new Mock<ILogger<TracesController>>();
            _traceServiceMock = new Mock<ITraceService>();
            _controller = new TracesController(_loggerMock.Object, _traceServiceMock.Object);
        }

        [Fact]
        public async Task CreateTrace_ValidTrace_ReturnsCreated()
        {
            // Arrange
            var traceCreationDto = new TraceCreationDto { Name = "TestName" };
            var createdTrace = new TraceDto { Name = "TestName" };
            _traceServiceMock.Setup(mock => mock.CreateTrace(traceCreationDto)).ReturnsAsync(createdTrace);

            // Act
            var result = await _controller.CreateTrace(traceCreationDto) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetTraceById", result!.RouteName);
            Assert.Equal(createdTrace, result!.Value);
            Assert.Equal(createdTrace.Id, result!.RouteValues!["id"]);
        }

        [Fact]
        public async Task CreateTrace_InvalidTrace_ReturnsBadRequest()
        {
            // Arrange
            var traceCreationDto = new TraceCreationDto { Name = "TestName" };
            _traceServiceMock.Setup(mock => mock.CreateTrace(traceCreationDto)).ReturnsAsync((TraceDto)null!);

            // Act
            var result = await _controller.CreateTrace(traceCreationDto) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Trailblazer does not exist or Trace Type already exists.", result!.Value);
        }

        [Fact]
        public async Task CreateTrace_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var traceCreationDto = new TraceCreationDto { Name = "TestName" };
            _traceServiceMock.Setup(mock => mock.CreateTrace(traceCreationDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.CreateTrace(traceCreationDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the trace.", result!.Value);
        }

        [Fact]
        public async Task GetAllTraces_NoTrailblazerId_ReturnsOkWithTraces()
        {
            // Arrange
            var traces = new List<TraceDto> { new TraceDto { Name = "TestName" } };
            _traceServiceMock.Setup(mock => mock.GetAllTraces()).ReturnsAsync(traces);

            // Act
            var result = await _controller.GetAllTraces(null) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(traces, result!.Value);
        }

        [Fact]
        public async Task GetAllTraces_WithTrailblazerId_ReturnsOkWithFilteredTraces()
        {
            // Arrange
            var trailblazerId = 1;
            var traces = new List<TraceDto> { new TraceDto { Name = "TestName" } };
            _traceServiceMock.Setup(mock => mock.GetTracesByTrailblazerId(trailblazerId)).ReturnsAsync(traces);

            // Act
            var result = await _controller.GetAllTraces(trailblazerId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(traces, result!.Value);
        }

        [Fact]
        public async Task GetAllTraces_NoTraces_ReturnsNoContent()
        {
            // Arrange
            _traceServiceMock.Setup(mock => mock.GetAllTraces()).ReturnsAsync(new List<TraceDto>());

            // Act
            var result = await _controller.GetAllTraces(null) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllTraces_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _traceServiceMock.Setup(mock => mock.GetAllTraces()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetAllTraces(null) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the traces.", result!.Value);
        }

        [Fact]
        public async Task GetTraceById_ExistingId_ReturnsOkWithTrace()
        {
            // Arrange
            var traceId = 1;
            var trace = new TraceDto { Name = "TestName" };
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync(trace);

            // Act
            var result = await _controller.GetTraceById(traceId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(trace, result!.Value);
        }

        [Fact]
        public async Task GetTraceById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var traceId = 1;
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync((TraceDto)null!);

            // Act
            var result = await _controller.GetTraceById(traceId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetTraceById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var traceId = 1;
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.GetTraceById(traceId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the trace.", result!.Value);
        }

        [Fact]
        public async Task UpdateTrace_ExistingIdAndValidTrace_ReturnsOkWithUpdatedTrace()
        {
            // Arrange
            var traceId = 1;
            var updatedTrace = new TraceDto { Name = "TestName" };
            var updateDto = new TraceUpdateDto { Name = "UpdatedName" };
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync(updatedTrace);
            _traceServiceMock.Setup(mock => mock.UpdateTrace(traceId, updateDto)).ReturnsAsync(true);
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync(updatedTrace);

            // Act
            var result = await _controller.UpdateTrace(traceId, updateDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(updatedTrace, result!.Value);
        }

        [Fact]
        public async Task UpdateTrace_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var traceId = 1;
            var updateDto = new TraceUpdateDto { Name = "UpdatedName" };
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync((TraceDto)null!);

            // Act
            var result = await _controller.UpdateTrace(traceId, updateDto) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Trace with ID = {traceId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateTrace_ValidIdAndInvalidTrace_ReturnsBadRequest()
        {
            // Arrange
            var traceId = 1;
            var trace = new TraceDto { Name = "TestName" };
            var updateDto = new TraceUpdateDto { Name = "UpdatedName" };
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync(trace);

            // Act
            var result = await _controller.UpdateTrace(traceId, updateDto) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateTrace_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var traceId = 1;
            var trace = new TraceDto { Name = "TestName" };
            var updateDto = new TraceUpdateDto { Name = "UpdatedName" };
            _traceServiceMock.Setup(mock => mock.GetTraceById(traceId)).ReturnsAsync(trace);
            _traceServiceMock.Setup(mock => mock.UpdateTrace(traceId, updateDto)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.UpdateTrace(traceId, updateDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the trace.", result!.Value);
        }

        [Fact]
        public async Task DeleteTrace_ExistingId_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var traceId = 1;
            _traceServiceMock.Setup(mock => mock.DeleteTrace(traceId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteTrace(traceId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted trace with ID {traceId}.", result!.Value);
        }

        [Fact]
        public async Task DeleteTrace_NonExistingId_ReturnsBadRequest()
        {
            // Arrange
            var traceId = 1;
            _traceServiceMock.Setup(mock => mock.DeleteTrace(traceId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteTrace(traceId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task DeleteTrace_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var traceId = 1;
            _traceServiceMock.Setup(mock => mock.DeleteTrace(traceId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _controller.DeleteTrace(traceId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the trace.", result!.Value);
        }
    }
}
