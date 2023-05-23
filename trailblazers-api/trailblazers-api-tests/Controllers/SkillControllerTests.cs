using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using trailblazers_api.Controllers;
using trailblazers_api.Dtos.Skills;
using trailblazers_api.Services.Skills;
using Xunit;

namespace trailblazers_api.UnitTests.Controllers
{
    public class SkillsControllerTests
    {
        private readonly Mock<ILogger<ISkillService>> _loggerMock;
        private readonly Mock<ISkillService> _skillServiceMock;
        private readonly SkillsController _controller;

        public SkillsControllerTests()
        {
            _loggerMock = new Mock<ILogger<ISkillService>>();
            _skillServiceMock = new Mock<ISkillService>();
            _controller = new SkillsController(_loggerMock.Object, _skillServiceMock.Object);
        }

        [Fact]
        public async Task CreateSkill_ValidRequest_ReturnsCreatedSkill()
        {
            // Arrange
            var skillToCreate = new SkillCreationDto { Name = "UpdatedName" };
            var createdSkill = new SkillDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.CreateSkill(skillToCreate)).ReturnsAsync(createdSkill);

            // Act
            var result = await _controller.CreateSkill(skillToCreate) as CreatedAtRouteResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result!.StatusCode);
            Assert.Equal("GetSkillById", result!.RouteName);
            Assert.Equal(createdSkill.Id, result!.RouteValues!["id"]);
            Assert.Equal(createdSkill, result!.Value);
        }

        [Fact]
        public async Task CreateSkill_InvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var skillToCreate = new SkillCreationDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.CreateSkill(skillToCreate)).ReturnsAsync((SkillDto)null!);

            // Act
            var result = await _controller.CreateSkill(skillToCreate) as BadRequestObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
            Assert.Equal("Trailblazer does not exist or Skill Type already exists.", result!.Value);
        }

        [Fact]
        public async Task CreateSkill_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var skillToCreate = new SkillCreationDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.CreateSkill(skillToCreate)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.CreateSkill(skillToCreate) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while creating the skill.", result!.Value);
        }

        [Fact]
        public async Task GetAllSkills_NoTrailblazerId_ReturnsAllSkills()
        {
            // Arrange
            var skills = new List<SkillDto> { new SkillDto { Name = "TestName" } };
            _skillServiceMock.Setup(x => x.GetAllSkills()).ReturnsAsync(skills);

            // Act
            var result = await _controller.GetAllSkills(null) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(skills, result!.Value);
        }

        [Fact]
        public async Task GetAllSkills_WithTrailblazerId_ReturnsFilteredSkills()
        {
            // Arrange
            var trailblazerId = 1;
            var skills = new List<SkillDto> { new SkillDto { Name = "TestName" } };
            _skillServiceMock.Setup(x => x.GetSkillsByTrailblazerId(trailblazerId)).ReturnsAsync(skills);

            // Act
            var result = await _controller.GetAllSkills(trailblazerId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(skills, result!.Value);
        }

        [Fact]
        public async Task GetAllSkills_NoSkills_ReturnsNoContent()
        {
            // Arrange
            _skillServiceMock.Setup(x => x.GetAllSkills()).ReturnsAsync(new List<SkillDto>());

            // Act
            var result = await _controller.GetAllSkills(null) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetAllSkills_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            _skillServiceMock.Setup(x => x.GetAllSkills()).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetAllSkills(null) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the skills.", result!.Value);
        }

        [Fact]
        public async Task GetSkillById_ExistingId_ReturnsSkill()
        {
            // Arrange
            var skillId = 1;
            var skill = new SkillDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync(skill);

            // Act
            var result = await _controller.GetSkillById(skillId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(skill, result!.Value);
        }

        [Fact]
        public async Task GetSkillById_NonExistingId_ReturnsNoContent()
        {
            // Arrange
            var skillId = 1;
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync((SkillDto)null!);

            // Act
            var result = await _controller.GetSkillById(skillId) as NoContentResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status204NoContent, result!.StatusCode);
        }

        [Fact]
        public async Task GetSkillById_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var skillId = 1;
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.GetSkillById(skillId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while retrieving the skill.", result!.Value);
        }

        [Fact]
        public async Task UpdateSkill_ExistingIdAndValidRequest_ReturnsUpdatedSkill()
        {
            // Arrange
            var skillId = 1;
            var updatedSkillDto = new SkillUpdateDto { Name = "TestName" };
            var existingSkill = new SkillDto { Name = "TestName" };
            var updatedSkill = new SkillDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync(existingSkill);
            _skillServiceMock.Setup(x => x.UpdateSkill(skillId, updatedSkillDto)).ReturnsAsync(true);
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync(updatedSkill);

            // Act
            var result = await _controller.UpdateSkill(skillId, updatedSkillDto) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal(updatedSkill, result!.Value);
        }

        [Fact]
        public async Task UpdateSkill_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var skillId = 1;
            var updatedSkillDto = new SkillUpdateDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync((SkillDto)null!);

            // Act
            var result = await _controller.UpdateSkill(skillId, updatedSkillDto) as NotFoundObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status404NotFound, result!.StatusCode);
            Assert.Equal($"Skill with ID = {skillId} does not exist.", result!.Value);
        }

        [Fact]
        public async Task UpdateSkill_ExistingIdAndInvalidRequest_ReturnsBadRequest()
        {
            // Arrange
            var skillId = 1;
            var updatedSkillDto = new SkillUpdateDto { Name = "TestName" };
            var existingSkill = new SkillDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync(existingSkill);
            _skillServiceMock.Setup(x => x.UpdateSkill(skillId, updatedSkillDto)).ReturnsAsync(false);

            // Act
            var result = await _controller.UpdateSkill(skillId, updatedSkillDto) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task UpdateSkill_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var skillId = 1;
            var updatedSkillDto = new SkillUpdateDto { Name = "TestName" };
            var existingSkill = new SkillDto { Name = "TestName" };
            _skillServiceMock.Setup(x => x.GetSkillById(skillId)).ReturnsAsync(existingSkill);
            _skillServiceMock.Setup(x => x.UpdateSkill(skillId, updatedSkillDto)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.UpdateSkill(skillId, updatedSkillDto) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while updating the skill.", result!.Value);
        }

        [Fact]
        public async Task DeleteSkill_ExistingId_ReturnsOk()
        {
            // Arrange
            var skillId = 1;
            _skillServiceMock.Setup(x => x.DeleteSkill(skillId)).ReturnsAsync(true);

            // Act
            var result = await _controller.DeleteSkill(skillId) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status200OK, result!.StatusCode);
            Assert.Equal($"Successfully deleted skill with ID {skillId}.", result!.Value);
        }

        [Fact]
        public async Task DeleteSkill_NonExistingId_ReturnsBadRequest()
        {
            // Arrange
            var skillId = 1;
            _skillServiceMock.Setup(x => x.DeleteSkill(skillId)).ReturnsAsync(false);

            // Act
            var result = await _controller.DeleteSkill(skillId) as BadRequestResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status400BadRequest, result!.StatusCode);
        }

        [Fact]
        public async Task DeleteSkill_ExceptionThrown_ReturnsInternalServerError()
        {
            // Arrange
            var skillId = 1;
            _skillServiceMock.Setup(x => x.DeleteSkill(skillId)).ThrowsAsync(new Exception());

            // Act
            var result = await _controller.DeleteSkill(skillId) as ObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, result!.StatusCode);
            Assert.Equal("An error occurred while deleting the skill.", result!.Value);
        }
    }
}
