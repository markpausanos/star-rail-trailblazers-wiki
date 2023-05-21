using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Paths;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Paths;
using trailblazers_api.Services.Paths;

namespace trailblazers_api.Tests.Services
{
    public class PathSRServiceTests
    {
        private readonly Mock<IPathSRRepository> _pathRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly PathSRService _pathService;

        public PathSRServiceTests()
        {
            _pathRepositoryMock = new Mock<IPathSRRepository>();
            _mapperMock = new Mock<IMapper>();
            _pathService = new PathSRService(
                _pathRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreatePathSR_ValidPath_ReturnsCreatedPathSRDto()
        {
            // Arrange
            var newPath = new PathSRCreationDto { Name = "TestName" };
            var createdPath = new PathSR { Name = "TestName" };
            var createdPathId = 1;
            var createdPathDto = new PathSRDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<PathSR>(newPath)).Returns(createdPath);
            _pathRepositoryMock.Setup(x => x.CreatePathSR(createdPath)).ReturnsAsync(createdPathId);
            _pathRepositoryMock.Setup(x => x.GetPathSRById(createdPathId)).ReturnsAsync(createdPath);
            _mapperMock.Setup(x => x.Map<PathSRDto>(createdPath)).Returns(createdPathDto);

            // Act
            var result = await _pathService.CreatePathSR(newPath);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdPathDto, result);
        }

        [Fact]
        public async Task GetAllPathSRs_ReturnsAllPathSRDtos()
        {
            // Arrange
            var paths = new List<PathSR> { new PathSR { Name = "TestName" } };
            var pathDtos = new List<PathSRDto> { new PathSRDto { Name = "TestName" } };

            _pathRepositoryMock.Setup(x => x.GetAllPathSRs()).ReturnsAsync(paths);
            _mapperMock.Setup(x => x.Map<PathSRDto>(It.IsAny<PathSR>())).Returns(pathDtos.First());

            // Act
            var result = await _pathService.GetAllPathSRs();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pathDtos, result.ToList());
        }

        [Fact]
        public async Task GetPathSRById_ValidId_ReturnsMatchingPathSRDto()
        {
            // Arrange
            var id = 1;
            var path = new PathSR { Name = "TestName" };
            var pathDto = new PathSRDto { Name = "TestName" };

            _pathRepositoryMock.Setup(x => x.GetPathSRById(id)).ReturnsAsync(path);
            _mapperMock.Setup(x => x.Map<PathSRDto>(path)).Returns(pathDto);

            // Act
            var result = await _pathService.GetPathSRById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pathDto, result);
        }

        [Fact]
        public async Task GetPathSRByName_ValidName_ReturnsMatchingPathSRDto()
        {
            // Arrange
            var name = "Test";
            var path = new PathSR { Name = "TestName" };
            var pathDto = new PathSRDto { Name = "TestName" };

            _pathRepositoryMock.Setup(x => x.GetPathSRByName(name)).ReturnsAsync(path);
            _mapperMock.Setup(x => x.Map<PathSRDto>(path)).Returns(pathDto);

            // Act
            var result = await _pathService.GetPathSRByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(pathDto, result);
        }

        [Fact]
        public async Task UpdatePathSR_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedPath = new PathSRUpdateDto { Name = "TestName" };
            var pathToUpdate = new PathSR { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<PathSR>(updatedPath)).Returns(pathToUpdate);
            _pathRepositoryMock.Setup(x => x.UpdatePathSR(pathToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _pathService.UpdatePathSR(id, updatedPath);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeletePathSR_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _pathRepositoryMock.Setup(x => x.DeletePathSR(id)).ReturnsAsync(true);

            // Act
            var result = await _pathService.DeletePathSR(id);

            // Assert
            Assert.True(result);
        }
    }
}
