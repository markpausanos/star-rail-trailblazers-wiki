using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Lightcones;
using trailblazers_api.Services.Lightcones;

namespace trailblazers_api.Tests.Services
{
    public class LightconeServiceTests
    {
        private readonly Mock<ILightconeRepository> _lightconeRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly LightconeService _lightconeService;

        public LightconeServiceTests()
        {
            _lightconeRepositoryMock = new Mock<ILightconeRepository>();
            _mapperMock = new Mock<IMapper>();
            _lightconeService = new LightconeService(
                _lightconeRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateLightcone_ValidLightcone_ReturnsCreatedLightconeDto()
        {
            // Arrange
            var newLightcone = new LightconeCreationDto { Name = "TestName" };
            var createdLightcone = new Lightcone { Name = "TestName" };
            var createdLightconeId = 1;
            var createdLightconeDto = new LightconeDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Lightcone>(newLightcone)).Returns(createdLightcone);
            _lightconeRepositoryMock.Setup(x => x.CreateLightcone(createdLightcone)).ReturnsAsync(createdLightconeId);
            _lightconeRepositoryMock.Setup(x => x.GetLightconeById(createdLightconeId)).ReturnsAsync(createdLightcone);
            _mapperMock.Setup(x => x.Map<LightconeDto>(createdLightcone)).Returns(createdLightconeDto);

            // Act
            var result = await _lightconeService.CreateLightcone(newLightcone);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdLightconeDto, result);
        }

        [Fact]
        public async Task GetAllLightcones_ReturnsAllLightconeDtos()
        {
            // Arrange
            var lightcones = new List<Lightcone> { new Lightcone { Name = "TestName" } };
            var lightconeDtos = new List<LightconeDto> { new LightconeDto { Name = "TestName" } };

            _lightconeRepositoryMock.Setup(x => x.GetAllLightcones()).ReturnsAsync(lightcones);
            _mapperMock.Setup(x => x.Map<LightconeDto>(It.IsAny<Lightcone>())).Returns(lightconeDtos.First());

            // Act
            var result = await _lightconeService.GetAllLightcones();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(lightconeDtos, result.ToList());
        }

        [Fact]
        public async Task GetLightconeById_ValidId_ReturnsMatchingLightconeDto()
        {
            // Arrange
            var id = 1;
            var lightcone = new Lightcone { Name = "TestName" };
            var lightconeDto = new LightconeDto { Name = "TestName" };

            _lightconeRepositoryMock.Setup(x => x.GetLightconeById(id)).ReturnsAsync(lightcone);
            _mapperMock.Setup(x => x.Map<LightconeDto>(lightcone)).Returns(lightconeDto);

            // Act
            var result = await _lightconeService.GetLightconeById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(lightconeDto, result);
        }

        [Fact]
        public async Task GetLightconeByName_ValidName_ReturnsMatchingLightconeDto()
        {
            // Arrange
            var name = "Test";
            var lightcone = new Lightcone { Name = "TestName" };
            var lightconeDto = new LightconeDto { Name = "TestName" };

            _lightconeRepositoryMock.Setup(x => x.GetLightconeByName(name)).ReturnsAsync(lightcone);
            _mapperMock.Setup(x => x.Map<LightconeDto>(lightcone)).Returns(lightconeDto);

            // Act
            var result = await _lightconeService.GetLightconeByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(lightconeDto, result);
        }

        [Fact]
        public async Task UpdateLightcone_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedLightcone = new LightconeUpdateDto { Name = "TestName" };
            var lightconeToUpdate = new Lightcone { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Lightcone>(updatedLightcone)).Returns(lightconeToUpdate);
            _lightconeRepositoryMock.Setup(x => x.UpdateLightcone(lightconeToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _lightconeService.UpdateLightcone(id, updatedLightcone);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteLightcone_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _lightconeRepositoryMock.Setup(x => x.DeleteLightcone(id)).ReturnsAsync(true);

            // Act
            var result = await _lightconeService.DeleteLightcone(id);

            // Assert
            Assert.True(result);
        }
    }
}
