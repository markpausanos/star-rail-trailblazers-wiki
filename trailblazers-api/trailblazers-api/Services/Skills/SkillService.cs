using trailblazers_api.DTOs.Skills;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Skills;

namespace trailblazers_api.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _repository;

        public SkillService(ISkillRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateSkill(SkillCreationDto skill)
        {
            var skillModel = new Skill
            {
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
                // Trailblazer = skill.TrailblazerId // Mapping needed probably
            };

            return skillModel.Id = await _repository.CreateSkill(skillModel);
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkills()
        {
            var skills = await _repository.GetAllSkills();
            if (skills == null) return null;

            return skills.Select(skill => new SkillDto
            {
                Id = skill.Id,
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
                TrailblazerId = skill.Trailblazer.Id
            });
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsByTrailblazerId(int trailblazerId)
        {
            var skills = await _repository.GetSkillsByTrailblazerId(trailblazerId);
            if (skills == null) return null;

            return skills.Select(skill => new SkillDto
            {
                Id = skill.Id,
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
                TrailblazerId = skill.Trailblazer.Id
            });
        }

        public async Task<SkillDto> GetSkillById(int id)
        {
            var skills = await _repository.GetAllSkills();
            if (skills == null) return null;
            var skill = skills.FirstOrDefault(x => x.Id == id);
            if (skill == null) return null;

            return new SkillDto
            {
                Id = skill.Id,
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
                TrailblazerId = skill.Trailblazer.Id
            };
        }

        public async Task<bool> UpdateSkill(SkillUpdateDto skill)
        {
            var skillModel = new Skill
            {
                Id = skill.Id,
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
                // Trailblazer = skill.TrailblazerId // Mapping needed probably
            };
            return await _repository.UpdateSkill(skillModel);
        }

        public async Task<bool> DeleteSkill(int id)
        {
            return await _repository.DeleteSkill(id);
        }
    }
}
