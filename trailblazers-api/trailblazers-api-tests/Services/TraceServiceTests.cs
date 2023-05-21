using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Traces;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Traces;
using trailblazers_api.Services.Traces;

namespace trailblazers_api.Tests.Services
{
    public class TraceServiceTests
    {
        private readonly Mock<ITraceRepository> _traceRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TraceService _traceService;

        public TraceServiceTests()
        {
            _traceRepositoryMock = new Mock<ITraceRepository>();
            _mapperMock = new Mock<IMapper>();
            _traceService = new TraceService(
                _traceRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateTrace_ValidTrace_ReturnsCreatedTraceDto()
        {
            // Arrange
            var newTrace = new TraceCreationDto { Name = "TestName" };
            var traceToCreate = new Trace { Name = "TestName" };
            var createdTrace = new Trace { Name = "TestName" };
            var createdTraceId = 1;
            var createdTraceDto = new TraceDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Trace>(newTrace)).Returns(traceToCreate);
            _traceRepositoryMock.Setup(x => x.CreateTrace(traceToCreate)).ReturnsAsync(createdTraceId);
            _traceRepositoryMock.Setup(x => x.GetTraceById(createdTraceId)).ReturnsAsync(createdTrace);
            _mapperMock.Setup(x => x.Map<TraceDto>(createdTrace)).Returns(createdTraceDto);

            // Act
            var result = await _traceService.CreateTrace(newTrace);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdTraceDto, result);
        }

        [Fact]
        public async Task GetAllTraces_ReturnsAllTraceDtos()
        {
            // Arrange
            var traces = new List<Trace> { new Trace { Name = "TestName" } };
            var traceDtos = new List<TraceDto> { new TraceDto { Name = "TestName" } };

            _traceRepositoryMock.Setup(x => x.GetAllTraces()).ReturnsAsync(traces);
            _mapperMock.Setup(x => x.Map<TraceDto>(It.IsAny<Trace>())).Returns(traceDtos.First());

            // Act
            var result = await _traceService.GetAllTraces();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(traceDtos, result.ToList());
        }

        [Fact]
        public async Task GetTracesByTrailblazerId_ValidId_ReturnsMatchingTraceDtos()
        {
            // Arrange
            var trailblazerId = 1;
            var traces = new List<Trace> { new Trace { Name = "TestName" } };
            var traceDtos = new List<TraceDto> { new TraceDto { Name = "TestName" } };

            _traceRepositoryMock.Setup(x => x.GetTracesByTrailblazerId(trailblazerId)).ReturnsAsync(traces);
            _mapperMock.Setup(x => x.Map<TraceDto>(It.IsAny<Trace>())).Returns(traceDtos.First());

            // Act
            var result = await _traceService.GetTracesByTrailblazerId(trailblazerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(traceDtos, result.ToList());
        }

        [Fact]
        public async Task GetTraceById_ValidId_ReturnsMatchingTraceDto()
        {
            // Arrange
            var id = 1;
            var trace = new Trace { Name = "TestName" };
            var traceDto = new TraceDto { Name = "TestName" };

            _traceRepositoryMock.Setup(x => x.GetTraceById(id)).ReturnsAsync(trace);
            _mapperMock.Setup(x => x.Map<TraceDto>(trace)).Returns(traceDto);

            // Act
            var result = await _traceService.GetTraceById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(traceDto, result);
        }

        [Fact]
        public async Task UpdateTrace_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedTrace = new TraceUpdateDto { Name = "TestName" };
            var traceToUpdate = new Trace { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Trace>(updatedTrace)).Returns(traceToUpdate);
            _traceRepositoryMock.Setup(x => x.UpdateTrace(traceToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _traceService.UpdateTrace(id, updatedTrace);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteTrace_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _traceRepositoryMock.Setup(x => x.DeleteTrace(id)).ReturnsAsync(true);

            // Act
            var result = await _traceService.DeleteTrace(id);

            // Assert
            Assert.True(result);
        }
    }
}
