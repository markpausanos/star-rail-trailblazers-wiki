using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Elements;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Elements;
using trailblazers_api.Services.Elements;

namespace trailblazers_api.Tests.Services
{
    public class ElementServiceTests
    {
        private readonly Mock<IElementRepository> _elementRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ElementService _elementService;

        public ElementServiceTests()
        {
            _elementRepositoryMock = new Mock<IElementRepository>();
            _mapperMock = new Mock<IMapper>();
            _elementService = new ElementService(
                _elementRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateElement_ValidElement_ReturnsCreatedElementDto()
        {
            // Arrange
            var newElement = new ElementCreationDto { Name = "TestName" };
            var createdElement = new Element { Name = "TestName" };
            var createdElementId = 1;
            var createdElementDto = new ElementDto { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Element>(newElement)).Returns(createdElement);
            _elementRepositoryMock.Setup(x => x.CreateElement(createdElement)).ReturnsAsync(createdElementId);
            _elementRepositoryMock.Setup(x => x.GetElementById(createdElementId)).ReturnsAsync(createdElement);
            _mapperMock.Setup(x => x.Map<ElementDto>(createdElement)).Returns(createdElementDto);

            // Act
            var result = await _elementService.CreateElement(newElement);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdElementDto, result);
        }

        [Fact]
        public async Task GetAllElements_ReturnsAllElementDtos()
        {
            // Arrange
            var elements = new List<Element> { new Element { Name = "TestName" } };
            var elementDtos = new List<ElementDto> { new ElementDto { Name = "TestName" } };

            _elementRepositoryMock.Setup(x => x.GetAllElements()).ReturnsAsync(elements);
            _mapperMock.Setup(x => x.Map<ElementDto>(It.IsAny<Element>())).Returns(elementDtos.First());

            // Act
            var result = await _elementService.GetAllElements();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(elementDtos, result.ToList());
        }

        [Fact]
        public async Task GetElementById_ValidId_ReturnsMatchingElementDto()
        {
            // Arrange
            var id = 1;
            var element = new Element { Name = "TestName" };
            var elementDto = new ElementDto { Name = "TestName" };

            _elementRepositoryMock.Setup(x => x.GetElementById(id)).ReturnsAsync(element);
            _mapperMock.Setup(x => x.Map<ElementDto>(element)).Returns(elementDto);

            // Act
            var result = await _elementService.GetElementById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(elementDto, result);
        }

        [Fact]
        public async Task GetElementByName_ValidName_ReturnsMatchingElementDto()
        {
            // Arrange
            var name = "Fire";
            var element = new Element { Name = "TestName" };
            var elementDto = new ElementDto { Name = "TestName" };

            _elementRepositoryMock.Setup(x => x.GetElementByName(name)).ReturnsAsync(element);
            _mapperMock.Setup(x => x.Map<ElementDto>(element)).Returns(elementDto);

            // Act
            var result = await _elementService.GetElementByName(name);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(elementDto, result);
        }

        [Fact]
        public async Task UpdateElement_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedElement = new ElementUpdateDto { Name = "TestName" };
            var elementToUpdate = new Element { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Element>(updatedElement)).Returns(elementToUpdate);
            _elementRepositoryMock.Setup(x => x.UpdateElement(elementToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _elementService.UpdateElement(id, updatedElement);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteElement_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _elementRepositoryMock.Setup(x => x.DeleteElement(id)).ReturnsAsync(true);

            // Act
            var result = await _elementService.DeleteElement(id);

            // Assert
            Assert.True(result);
        }
    }
}
