using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Builds;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Builds;
using trailblazers_api.Services.Builds;

namespace trailblazers_api.Tests.Services
{
    public class BuildServiceTests
    {
        private readonly Mock<IBuildRepository> _buildRepositoryMock;
        private readonly Mock<IBuildLikeRepository> _buildLikeRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BuildService _buildService;

        public BuildServiceTests()
        {
            _buildRepositoryMock = new Mock<IBuildRepository>();
            _buildLikeRepositoryMock = new Mock<IBuildLikeRepository>();
            _mapperMock = new Mock<IMapper>();
            _buildService = new BuildService(
                _buildRepositoryMock.Object,
                _buildLikeRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateBuild_ValidBuild_ReturnsCreatedBuildDto()
        {
            // Arrange
            var newBuild = new BuildCreationDto { Name = "TestName" };
            var createdBuild = new Build { Name = "TestName" };
            var createdBuildId = 1;
            var createdBuildDto = new BuildDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Build>(newBuild)).Returns(createdBuild);
            _buildRepositoryMock.Setup(x => x.CreateBuild(createdBuild)).ReturnsAsync(createdBuildId);
            _buildRepositoryMock.Setup(x => x.GetBuildById(createdBuildId)).ReturnsAsync(createdBuild);
            _mapperMock.Setup(x => x.Map<BuildDto>(createdBuild)).Returns(createdBuildDto);

            // Act
            var result = await _buildService.CreateBuild(newBuild);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdBuildDto, result);
        }

        [Fact]
        public async Task GetAllBuilds_ReturnsAllBuildDtos()
        {
            // Arrange
            var userId = 1;
            var builds = new List<Build> { new Build { Name = "TestName" } };
            var buildDtos = new List<BuildDto> { new BuildDto { Name = "TestName" } };

            _buildRepositoryMock.Setup(x => x.GetAllBuilds()).ReturnsAsync(builds);
            _buildLikeRepositoryMock.SetupSequence(x => x.GetTotalLikesByBuild(It.IsAny<int>()))
                .ReturnsAsync(5);
            _buildLikeRepositoryMock.SetupSequence(x => x.IsLikedByUser(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(true);
            _mapperMock.Setup(x => x.Map<BuildDto>(It.IsAny<Build>())).Returns(buildDtos.First());

            // Act
            var result = await _buildService.GetAllBuilds(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(buildDtos, result.ToList());
        }

        [Fact]
        public async Task AddLike_ValidData_ReturnsTrue()
        {
            // Arrange
            var userId = 1;
            var buildId = 1;
            _buildLikeRepositoryMock.Setup(x => x.AddLike(userId, buildId)).ReturnsAsync(true);

            // Act
            var result = await _buildService.AddLike(userId, buildId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task GetBuildById_ValidId_ReturnsBuildDto()
        {
            // Arrange
            var id = 1;
            var build = new Build { Name = "TestName" };
            var buildDto = new BuildDto { Name = "TestName" };

            _buildRepositoryMock.Setup(x => x.GetBuildById(id)).ReturnsAsync(build);
            _mapperMock.Setup(x => x.Map<BuildDto>(build)).Returns(buildDto);

            // Act
            var result = await _buildService.GetBuildById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(buildDto, result);
        }

        [Fact]
        public async Task UpdateBuild_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedBuild = new BuildUpdateDto { Name = "TestName" };
            var buildToUpdate = new Build { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Build>(updatedBuild)).Returns(buildToUpdate);
            _buildRepositoryMock.Setup(x => x.UpdateBuild(buildToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _buildService.UpdateBuild(id, updatedBuild);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task RemoveLike_ValidData_ReturnsTrue()
        {
            // Arrange
            var userId = 1;
            var buildId = 1;
            _buildLikeRepositoryMock.Setup(x => x.RemoveLike(userId, buildId)).ReturnsAsync(true);

            // Act
            var result = await _buildService.RemoveLike(userId, buildId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteBuild_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _buildRepositoryMock.Setup(x => x.DeleteBuild(id)).ReturnsAsync(true);

            // Act
            var result = await _buildService.DeleteBuild(id);

            // Assert
            Assert.True(result);
        }
    }
}
