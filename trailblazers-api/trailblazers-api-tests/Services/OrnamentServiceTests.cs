using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Ornaments;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Ornaments;
using trailblazers_api.Services.Ornaments;

namespace trailblazers_api.Tests.Services
{
    public class OrnamentServiceTests
    {
        private readonly Mock<IOrnamentRepository> _ornamentRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly OrnamentService _ornamentService;

        public OrnamentServiceTests()
        {
            _ornamentRepositoryMock = new Mock<IOrnamentRepository>();
            _mapperMock = new Mock<IMapper>();
            _ornamentService = new OrnamentService(
                _ornamentRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateOrnament_ValidOrnament_ReturnsCreatedOrnamentDto()
        {
            // Arrange
            var newOrnament = new OrnamentCreationDto { Name = "TestName" };
            var createdOrnament = new Ornament { Name = "TestName" };
            var createdOrnamentId = 1;
            var createdOrnamentDto = new OrnamentDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Ornament>(newOrnament)).Returns(createdOrnament);
            _ornamentRepositoryMock.Setup(x => x.CreateOrnament(createdOrnament)).ReturnsAsync(createdOrnamentId);
            _ornamentRepositoryMock.Setup(x => x.GetOrnamentById(createdOrnamentId)).ReturnsAsync(createdOrnament);
            _mapperMock.Setup(x => x.Map<OrnamentDto>(createdOrnament)).Returns(createdOrnamentDto);

            // Act
            var result = await _ornamentService.CreateOrnament(newOrnament);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdOrnamentDto, result);
        }

        [Fact]
        public async Task GetAllOrnaments_ReturnsAllOrnamentDtos()
        {
            // Arrange
            var ornaments = new List<Ornament> { new Ornament { Name = "TestName" } };
            var ornamentDtos = new List<OrnamentDto> { new OrnamentDto { Name = "TestName" } };

            _ornamentRepositoryMock.Setup(x => x.GetAllOrnaments()).ReturnsAsync(ornaments);
            _mapperMock.Setup(x => x.Map<OrnamentDto>(It.IsAny<Ornament>())).Returns(ornamentDtos.First());

            // Act
            var result = await _ornamentService.GetAllOrnaments();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ornamentDtos, result.ToList());
        }

        [Fact]
        public async Task GetOrnamentById_ValidId_ReturnsMatchingOrnamentDto()
        {
            // Arrange
            var id = 1;
            var ornament = new Ornament { Name = "TestName" };
            var ornamentDto = new OrnamentDto { Name = "TestName" };

            _ornamentRepositoryMock.Setup(x => x.GetOrnamentById(id)).ReturnsAsync(ornament);
            _mapperMock.Setup(x => x.Map<OrnamentDto>(ornament)).Returns(ornamentDto);

            // Act
            var result = await _ornamentService.GetOrnamentById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ornamentDto, result);
        }

        [Fact]
        public async Task GetOrnamentByName_ValidName_ReturnsMatchingOrnamentDto()
        {
            // Arrange
            var name = "Test";
            var ornament = new Ornament { Name = "TestName" };
            var ornamentDto = new OrnamentDto { Name = "TestName" };

            _ornamentRepositoryMock.Setup(x => x.GetOrnamentByName(name)).ReturnsAsync(ornament);
            _mapperMock.Setup(x => x.Map<OrnamentDto>(ornament)).Returns(ornamentDto);

            // Act
            var result = await _ornamentService.GetOrnamentByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(ornamentDto, result);
        }

        [Fact]
        public async Task UpdateOrnament_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedOrnament = new OrnamentUpdateDto { Name = "TestName" };
            var ornamentToUpdate = new Ornament { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Ornament>(updatedOrnament)).Returns(ornamentToUpdate);
            _ornamentRepositoryMock.Setup(x => x.UpdateOrnament(ornamentToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _ornamentService.UpdateOrnament(id, updatedOrnament);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteOrnament_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _ornamentRepositoryMock.Setup(x => x.DeleteOrnament(id)).ReturnsAsync(true);

            // Act
            var result = await _ornamentService.DeleteOrnament(id);

            // Assert
            Assert.True(result);
        }
    }
}
