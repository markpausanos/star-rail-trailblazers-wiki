using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Relics;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Relics;
using trailblazers_api.Services.Relics;

namespace trailblazers_api.Tests.Services
{
    public class RelicServiceTests
    {
        private readonly Mock<IRelicRepository> _relicRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly RelicService _relicService;

        public RelicServiceTests()
        {
            _relicRepositoryMock = new Mock<IRelicRepository>();
            _mapperMock = new Mock<IMapper>();
            _relicService = new RelicService(
                _relicRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateRelic_ValidRelic_ReturnsCreatedRelicDto()
        {
            // Arrange
            var newRelic = new RelicCreationDto { Name = "TestName" };
            var createdRelic = new Relic { Name = "TestName" };
            var createdRelicId = 1;
            var createdRelicDto = new RelicDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Relic>(newRelic)).Returns(createdRelic);
            _relicRepositoryMock.Setup(x => x.CreateRelic(createdRelic)).ReturnsAsync(createdRelicId);
            _relicRepositoryMock.Setup(x => x.GetRelicById(createdRelicId)).ReturnsAsync(createdRelic);
            _mapperMock.Setup(x => x.Map<RelicDto>(createdRelic)).Returns(createdRelicDto);

            // Act
            var result = await _relicService.CreateRelic(newRelic);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdRelicDto, result);
        }

        [Fact]
        public async Task GetAllRelics_ReturnsAllRelicDtos()
        {
            // Arrange
            var relics = new List<Relic> { new Relic { Name = "TestName" } };
            var relicDtos = new List<RelicDto> { new RelicDto { Name = "TestName" } };

            _relicRepositoryMock.Setup(x => x.GetAllRelics()).ReturnsAsync(relics);
            _mapperMock.Setup(x => x.Map<RelicDto>(It.IsAny<Relic>())).Returns(relicDtos.First());

            // Act
            var result = await _relicService.GetAllRelics();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(relicDtos, result.ToList());
        }

        [Fact]
        public async Task GetRelicById_ValidId_ReturnsMatchingRelicDto()
        {
            // Arrange
            var id = 1;
            var relic = new Relic { Name = "TestName" };
            var relicDto = new RelicDto { Name = "TestName" };

            _relicRepositoryMock.Setup(x => x.GetRelicById(id)).ReturnsAsync(relic);
            _mapperMock.Setup(x => x.Map<RelicDto>(relic)).Returns(relicDto);

            // Act
            var result = await _relicService.GetRelicById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(relicDto, result);
        }

        [Fact]
        public async Task GetRelicByName_ValidName_ReturnsMatchingRelicDto()
        {
            // Arrange
            var name = "RelicName";
            var relic = new Relic { Name = "TestName" };
            var relicDto = new RelicDto { Name = "TestName" };

            _relicRepositoryMock.Setup(x => x.GetRelicByName(name)).ReturnsAsync(relic);
            _mapperMock.Setup(x => x.Map<RelicDto>(relic)).Returns(relicDto);

            // Act
            var result = await _relicService.GetRelicByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(relicDto, result);
        }

        [Fact]
        public async Task UpdateRelic_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedRelic = new RelicUpdateDto { Name = "TestName" };
            var relicToUpdate = new Relic { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Relic>(updatedRelic)).Returns(relicToUpdate);
            _relicRepositoryMock.Setup(x => x.UpdateRelic(relicToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _relicService.UpdateRelic(id, updatedRelic);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteRelic_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _relicRepositoryMock.Setup(x => x.DeleteRelic(id)).ReturnsAsync(true);

            // Act
            var result = await _relicService.DeleteRelic(id);

            // Assert
            Assert.True(result);
        }
    }
}
