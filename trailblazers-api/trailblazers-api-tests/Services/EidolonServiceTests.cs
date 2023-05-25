using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Eidolons;
using trailblazers_api.Services.Eidolons;

namespace trailblazers_api.Tests.Services
{
    public class EidolonServiceTests
    {
        private readonly Mock<IEidolonRepository> _eidolonRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly EidolonService _eidolonService;

        public EidolonServiceTests()
        {
            _eidolonRepositoryMock = new Mock<IEidolonRepository>();
            _mapperMock = new Mock<IMapper>();
            _eidolonService = new EidolonService(
                _eidolonRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateEidolon_ValidEidolon_ReturnsCreatedEidolonDto()
        {
            // Arrange
            var newEidolon = new EidolonCreationDto { Name = "TestName" };
            var createdEidolon = new Eidolon { Name = "TestName" };
            var createdEidolonId = 1;
            var createdEidolonDto = new EidolonDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Eidolon>(newEidolon)).Returns(createdEidolon);
            _eidolonRepositoryMock.Setup(x => x.CreateEidolon(createdEidolon)).ReturnsAsync(createdEidolonId);
            _eidolonRepositoryMock.Setup(x => x.GetEidolonById(createdEidolonId)).ReturnsAsync(createdEidolon);
            _mapperMock.Setup(x => x.Map<EidolonDto>(createdEidolon)).Returns(createdEidolonDto);

            // Act
            var result = await _eidolonService.CreateEidolon(newEidolon);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdEidolonDto, result);
        }

        [Fact]
        public async Task GetAllEidolons_ReturnsAllEidolonDtos()
        {
            // Arrange
            var eidolons = new List<Eidolon> { new Eidolon { Name = "TestName" } };
            var eidolonDtos = new List<EidolonDto> { new EidolonDto { Name = "TestName" } };

            _eidolonRepositoryMock.Setup(x => x.GetAllEidolons()).ReturnsAsync(eidolons);
            _mapperMock.Setup(x => x.Map<EidolonDto>(It.IsAny<Eidolon>())).Returns(eidolonDtos.First());

            // Act
            var result = await _eidolonService.GetAllEidolons();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(eidolonDtos, result.ToList());
        }

        [Fact]
        public async Task GetEidolonsByTrailblazerId_ValidTrailblazerId_ReturnsMatchingEidolonDtos()
        {
            // Arrange
            var trailblazerId = 1;
            var eidolons = new List<Eidolon> { new Eidolon { Name = "TestName" } };
            var eidolonDtos = new List<EidolonDto> { new EidolonDto { Name = "TestName" } };

            _eidolonRepositoryMock.Setup(x => x.GetEidolonsByTrailblazerId(trailblazerId)).ReturnsAsync(eidolons);
            _mapperMock.Setup(x => x.Map<EidolonDto>(It.IsAny<Eidolon>())).Returns(eidolonDtos.First());

            // Act
            var result = await _eidolonService.GetEidolonsByTrailblazerId(trailblazerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(eidolonDtos, result.ToList());
        }

        [Fact]
        public async Task GetEidolonById_ValidId_ReturnsMatchingEidolonDto()
        {
            // Arrange
            var id = 1;
            var eidolon = new Eidolon { Name = "TestName" };
            var eidolonDto = new EidolonDto { Name = "TestName" };

            _eidolonRepositoryMock.Setup(x => x.GetEidolonById(id)).ReturnsAsync(eidolon);
            _mapperMock.Setup(x => x.Map<EidolonDto>(eidolon)).Returns(eidolonDto);

            // Act
            var result = await _eidolonService.GetEidolonById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(eidolonDto, result);
        }

        [Fact]
        public async Task UpdateEidolon_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedEidolon = new EidolonUpdateDto { Name = "TestName" };
            var eidolonToUpdate = new Eidolon { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Eidolon>(updatedEidolon)).Returns(eidolonToUpdate);
            _eidolonRepositoryMock.Setup(x => x.UpdateEidolon(eidolonToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _eidolonService.UpdateEidolon(id, updatedEidolon);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteEidolon_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _eidolonRepositoryMock.Setup(x => x.DeleteEidolon(id)).ReturnsAsync(true);

            // Act
            var result = await _eidolonService.DeleteEidolon(id);

            // Assert
            Assert.True(result);
        }
    }
}
