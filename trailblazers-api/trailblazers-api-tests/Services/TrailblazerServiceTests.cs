using AutoMapper;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Trailblazers;
using trailblazers_api.Services.Trailblazers;

namespace trailblazers_api.Tests.Services.Trailblazers
{
    public class TrailblazerServiceTests
    {
        private readonly Mock<ITrailblazersRepository> _trailblazerRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TrailblazerService _trailblazerService;

        public TrailblazerServiceTests()
        {
            _trailblazerRepositoryMock = new Mock<ITrailblazersRepository>();
            _mapperMock = new Mock<IMapper>();
            _trailblazerService = new TrailblazerService(
                _trailblazerRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateTrailblazer_ValidTrailblazer_ReturnsCreatedTrailblazerDto()
        {
            // Arrange
            var newTrailblazer = new TrailblazerCreationDto { Name = "TestName" };
            var trailblazerToCreate = new Trailblazer { Name = "TestName" };
            var createdTrailblazer = new Trailblazer { Name = "TestName" };
            var createdTrailblazerId = 1;
            var createdTrailblazerDto = new TrailblazerDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Trailblazer>(newTrailblazer)).Returns(trailblazerToCreate);
            _trailblazerRepositoryMock.Setup(x => x.CreateTrailblazer(trailblazerToCreate)).ReturnsAsync(createdTrailblazerId);
            _trailblazerRepositoryMock.Setup(x => x.GetTrailblazerById(createdTrailblazerId)).ReturnsAsync(createdTrailblazer);
            _mapperMock.Setup(x => x.Map<TrailblazerDto>(createdTrailblazer)).Returns(createdTrailblazerDto);

            // Act
            var result = await _trailblazerService.CreateTrailblazer(newTrailblazer);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdTrailblazerDto, result);
        }

        [Fact]
        public async Task GetAllTrailblazers_ReturnsAllTrailblazerDtos()
        {
            // Arrange
            var trailblazers = new List<Trailblazer> { new Trailblazer { Name = "TestName" } };
            var trailblazerDtos = new List<TrailblazerDto> { new TrailblazerDto { Name = "TestName" } };

            _trailblazerRepositoryMock.Setup(x => x.GetAllTrailblazers()).ReturnsAsync(trailblazers);
            _mapperMock.Setup(x => x.Map<TrailblazerDto>(It.IsAny<Trailblazer>())).Returns(trailblazerDtos.First());

            // Act
            var result = await _trailblazerService.GetAllTrailblazers();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(trailblazerDtos, result.ToList());
        }

        [Fact]
        public async Task GetTrailblazerById_ValidId_ReturnsMatchingTrailblazerDto()
        {
            // Arrange
            var id = 1;
            var trailblazer = new Trailblazer { Name = "TestName" };
            var trailblazerDto = new TrailblazerDto { Name = "TestName" };

            _trailblazerRepositoryMock.Setup(x => x.GetTrailblazerById(id)).ReturnsAsync(trailblazer);
            _mapperMock.Setup(x => x.Map<TrailblazerDto>(trailblazer)).Returns(trailblazerDto);

            // Act
            var result = await _trailblazerService.GetTrailblazerById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(trailblazerDto, result);
        }

        [Fact]
        public async Task UpdateTrailblazer_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedTrailblazer = new TrailblazerUpdateDto { Name = "TestName" };
            var trailblazerToUpdate = new Trailblazer { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Trailblazer>(updatedTrailblazer)).Returns(trailblazerToUpdate);
            _trailblazerRepositoryMock.Setup(x => x.UpdateTrailblazer(trailblazerToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _trailblazerService.UpdateTrailblazer(id, updatedTrailblazer);

            // Assert
            Assert.True(result);
        }
    }
}
