using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Elements;
using trailblazers_api.Services.Elements;
using Xunit;

namespace trailblazers_api.Tests.Controllers
{
    public class ElementsControllerTests
    {
        private readonly Mock<ILogger<ElementsController>> _loggerMock;
        private readonly Mock<IElementService> _elementServiceMock;
        private readonly ElementsController _elementsController;

        public ElementsControllerTests()
        {
            _loggerMock = new Mock<ILogger<ElementsController>>();
            _elementServiceMock = new Mock<IElementService>();
            _elementsController = new ElementsController(_loggerMock.Object, _elementServiceMock.Object);
        }

        [Fact]
        public async Task CreateElement_ValidData_ReturnsCreatedResponse()
        {
            // Arrange
            var elementCreationDto = new ElementCreationDto { Name = "AfterTest" };
            var createdElementDto = new ElementDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.CreateElement(It.IsAny<ElementCreationDto>())).ReturnsAsync(createdElementDto);

            // Act
            var result = await _elementsController.CreateElement(elementCreationDto);

            // Assert
            var createdResult = Assert.IsType<CreatedAtRouteResult>(result);
            Assert.Equal("GetElementById", createdResult.RouteName);
            Assert.Equal(createdElementDto.Id, createdResult.RouteValues["id"]);
            Assert.Equal(createdElementDto, createdResult.Value);
        }

        [Fact]
        public async Task CreateElement_InvalidData_ReturnsBadRequest()
        {
            // Arrange
            var elementCreationDto = new ElementCreationDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.CreateElement(It.IsAny<ElementCreationDto>())).ReturnsAsync((ElementDto)null);

            // Act
            var result = await _elementsController.CreateElement(elementCreationDto);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Element cannot be created.", badRequestResult.Value);
        }

        [Fact]
        public async Task CreateElement_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var elementCreationDto = new ElementCreationDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.CreateElement(It.IsAny<ElementCreationDto>())).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _elementsController.CreateElement(elementCreationDto);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("An error occurred while creating the Element.", statusCodeResult.Value);
        }

        [Fact]
        public async Task GetAllElements_NoFilter_ReturnsOkWithElements()
        {
            // Arrange
            var elements = new List<ElementDto> { new ElementDto() { Name = "Test" } };
            _elementServiceMock.Setup(x => x.GetAllElements()).ReturnsAsync(elements);

            // Act
            var result = await _elementsController.GetAllElements(null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedElements = Assert.IsAssignableFrom<IEnumerable<ElementDto>>(okResult.Value);
            Assert.Equal(elements, returnedElements);
        }

        [Fact]
        public async Task GetAllElements_WithFilter_ReturnsOkWithElement()
        {
            // Arrange
            var elementName = "SomeElement";
            var element = new ElementDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.GetElementByName(elementName)).ReturnsAsync(element);

            // Act
            var result = await _elementsController.GetAllElements(elementName);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedElement = Assert.IsAssignableFrom<ElementDto>(okResult.Value);
            Assert.Equal(element, returnedElement);
        }

        [Fact]
        public async Task GetAllElements_NoElements_ReturnsNoContent()
        {
            // Arrange
            var elements = new List<ElementDto>(); // Empty list
            _elementServiceMock.Setup(x => x.GetAllElements()).ReturnsAsync(elements);

            // Act
            var result = await _elementsController.GetAllElements(null);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetAllElements_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _elementServiceMock.Setup(x => x.GetAllElements()).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _elementsController.GetAllElements(null);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("An error occurred while retrieving the Elements.", statusCodeResult.Value);
        }

        [Fact]
        public async Task GetElementById_ExistingElement_ReturnsOkWithElement()
        {
            // Arrange
            var elementId = 1;
            var element = new ElementDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ReturnsAsync(element);

            // Act
            var result = await _elementsController.GetElementById(elementId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedElement = Assert.IsAssignableFrom<ElementDto>(okResult.Value);
            Assert.Equal(element, returnedElement);
        }

        [Fact]
        public async Task GetElementById_NonExistingElement_ReturnsNoContent()
        {
            // Arrange
            var elementId = 1;
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ReturnsAsync((ElementDto)null);

            // Act
            var result = await _elementsController.GetElementById(elementId);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task GetElementById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var elementId = 1;
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _elementsController.GetElementById(elementId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("An error occurred while retrieving the Element.", statusCodeResult.Value);
        }

        [Fact]
        public async Task UpdateElement_ExistingElement_ReturnsOkWithUpdatedElement()
        {
            // Arrange
            var elementId = 1;
            var newElement = new ElementUpdateDto { Name = "AfterTest" };
            var existingElement = new ElementDto { Name = "BeforeTest" };
            var updatedElement = new ElementDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ReturnsAsync(existingElement);
            _elementServiceMock.Setup(x => x.UpdateElement(elementId, newElement)).ReturnsAsync(true);
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ReturnsAsync(updatedElement);

            // Act
            var result = await _elementsController.UpdateElement(elementId, newElement);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedElement = Assert.IsType<ElementDto>(okResult.Value);
            Assert.Equal(updatedElement, returnedElement);
        }

        [Fact]
        public async Task UpdateElement_NonExistingElement_ReturnsNotFound()
        {
            // Arrange
            var elementId = 1;
            var newElement = new ElementUpdateDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ReturnsAsync((ElementDto)null);

            // Act
            var result = await _elementsController.UpdateElement(elementId, newElement);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result);
            Assert.Equal($"Element with ID = {elementId} does not exist.", notFoundResult.Value);
        }

        [Fact]
        public async Task UpdateElement_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var elementId = 1;
            var newElement = new ElementUpdateDto { Name = "AfterTest" };
            _elementServiceMock.Setup(x => x.GetElementById(elementId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _elementsController.UpdateElement(elementId, newElement);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("An error occurred while updating the Element.", statusCodeResult.Value);
        }

        [Fact]
        public async Task DeleteElement_ExistingElement_ReturnsOkWithSuccessMessage()
        {
            // Arrange
            var elementId = 1;
            _elementServiceMock.Setup(x => x.DeleteElement(elementId)).ReturnsAsync(true);

            // Act
            var result = await _elementsController.DeleteElement(elementId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal($"Successfully deleted element with ID {elementId}.", okResult.Value);
        }

        [Fact]
        public async Task DeleteElement_NonExistingElement_ReturnsBadRequest()
        {
            // Arrange
            var elementId = 1;
            _elementServiceMock.Setup(x => x.DeleteElement(elementId)).ReturnsAsync(false);

            // Act
            var result = await _elementsController.DeleteElement(elementId);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteElement_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var elementId = 1;
            _elementServiceMock.Setup(x => x.DeleteElement(elementId)).ThrowsAsync(new Exception("Some error message"));

            // Act
            var result = await _elementsController.DeleteElement(elementId);

            // Assert
            var statusCodeResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
            Assert.Equal("An error occurred while deleting the Element.", statusCodeResult.Value);
        }

    }
}
