using AutoMapper;
using Moq;
using Xunit;
using trailblazers_api.Dtos.Skills;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Skills;
using trailblazers_api.Services.Skills;

namespace trailblazers_api.Tests.Services
{
    public class SkillServiceTests
    {
        private readonly Mock<ISkillRepository> _skillRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly SkillService _skillService;

        public SkillServiceTests()
        {
            _skillRepositoryMock = new Mock<ISkillRepository>();
            _mapperMock = new Mock<IMapper>();
            _skillService = new SkillService(
                _skillRepositoryMock.Object,
                _mapperMock.Object
            );
        }

        [Fact]
        public async Task CreateSkill_ValidSkill_ReturnsCreatedSkillDto()
        {
            // Arrange
            var newSkill = new SkillCreationDto { Name = "TestName" };
            var skillToCreate = new Skill { Name = "TestName" };
            var createdSkill = new Skill { Name = "TestName" };
            var createdSkillId = 1;
            var createdSkillDto = new SkillDto { Name = "TestName" };

            _skillRepositoryMock
                .Setup(x => x.GetSkillsByTrailblazerId(newSkill.TrailblazerId))
                .ReturnsAsync(new List<Skill>());

            _mapperMock.Setup(x => x.Map<Skill>(newSkill)).Returns(skillToCreate);
            _skillRepositoryMock.Setup(x => x.CreateSkill(skillToCreate)).ReturnsAsync(createdSkillId);
            _skillRepositoryMock.Setup(x => x.GetSkillById(createdSkillId)).ReturnsAsync(createdSkill);
            _mapperMock.Setup(x => x.Map<SkillDto>(createdSkill)).Returns(createdSkillDto);

            // Act
            var result = await _skillService.CreateSkill(newSkill);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(createdSkillDto, result);
        }

        [Fact]
        public async Task GetAllSkills_ReturnsAllSkillDtos()
        {
            // Arrange
            var skills = new List<Skill> { new Skill { Name = "TestName" } };
            var skillDtos = new List<SkillDto> { new SkillDto { Name = "TestName" } };

            _skillRepositoryMock.Setup(x => x.GetAllSkills()).ReturnsAsync(skills);
            _mapperMock.Setup(x => x.Map<SkillDto>(It.IsAny<Skill>())).Returns(skillDtos.First());

            // Act
            var result = await _skillService.GetAllSkills();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(skillDtos, result.ToList());
        }

        [Fact]
        public async Task GetSkillsByTrailblazerId_ValidId_ReturnsMatchingSkillDtos()
        {
            // Arrange
            var trailblazerId = 1;
            var skills = new List<Skill> { new Skill { Name = "TestName" } };
            var skillDtos = new List<SkillDto> { new SkillDto { Name = "TestName" } };

            _skillRepositoryMock.Setup(x => x.GetSkillsByTrailblazerId(trailblazerId)).ReturnsAsync(skills);
            _mapperMock.Setup(x => x.Map<SkillDto>(It.IsAny<Skill>())).Returns(skillDtos.First());

            // Act
            var result = await _skillService.GetSkillsByTrailblazerId(trailblazerId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(skillDtos, result.ToList());
        }

        [Fact]
        public async Task GetSkillById_ValidId_ReturnsMatchingSkillDto()
        {
            // Arrange
            var id = 1;
            var skill = new Skill { Name = "TestName" };
            var skillDto = new SkillDto { Name = "TestName" };

            _skillRepositoryMock.Setup(x => x.GetSkillById(id)).ReturnsAsync(skill);
            _mapperMock.Setup(x => x.Map<SkillDto>(skill)).Returns(skillDto);

            // Act
            var result = await _skillService.GetSkillById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(skillDto, result);
        }

        [Fact]
        public async Task UpdateSkill_ValidIdAndData_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            var updatedSkill = new SkillUpdateDto { Name = "TestName" };
            var skillToUpdate = new Skill { Name = "TestName" };

            _mapperMock.Setup(x => x.Map<Skill>(updatedSkill)).Returns(skillToUpdate);
            _skillRepositoryMock.Setup(x => x.UpdateSkill(skillToUpdate)).ReturnsAsync(true);

            // Act
            var result = await _skillService.UpdateSkill(id, updatedSkill);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteSkill_ValidId_ReturnsTrue()
        {
            // Arrange
            var id = 1;
            _skillRepositoryMock.Setup(x => x.DeleteSkill(id)).ReturnsAsync(true);

            // Act
            var result = await _skillService.DeleteSkill(id);

            // Assert
            Assert.True(result);
        }
    }
}
