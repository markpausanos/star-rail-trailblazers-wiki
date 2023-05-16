using AutoMapper;
using trailblazers_api.DTOs.Skills;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Skills;

namespace trailblazers_api.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        private readonly IMapper _mapper;

        public SkillService(ISkillRepository repository, IMapper mapper)
        {
            _skillRepository = repository;
            _mapper = mapper;
        }

        public async Task<SkillDto?> CreateSkill(SkillCreationDto newSkill)
        {
            var skillsByTrailblazer = await _skillRepository.GetSkillsByTrailblazerId(newSkill.TrailblazerId);

            if (skillsByTrailblazer.Select(x => x.Type).Contains(newSkill.Type))
            {
                return null;
            }

            var skillToCreate = _mapper.Map<Skill>(newSkill);

            var newlyCreatedSkill = await _skillRepository.GetSkillById(await _skillRepository.CreateSkill(skillToCreate));
            return _mapper.Map<SkillDto>(newlyCreatedSkill);
        }

        public async Task<IEnumerable<SkillDto>> GetAllSkills()
        {
            var skills = await _skillRepository.GetAllSkills();
            if (skills == null) return null;

            return skills.Select(skill => new SkillDto
            {
                Id = skill.Id,
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
            });
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsByTrailblazerId(int trailblazerId)
        {
            var skills = await _skillRepository.GetSkillsByTrailblazerId(trailblazerId);
            if (skills == null) return null;

            return skills.Select(skill => new SkillDto
            {
                Id = skill.Id,
                Title = skill.Title,
                Name = skill.Name,
                Description = skill.Description,
                Image = skill.Image,
                Type = skill.Type,
            });
        }

        public async Task<SkillDto> GetSkillById(int id)
        {
            var skills = await _skillRepository.GetAllSkills();
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
            return await _skillRepository.UpdateSkill(skillModel);
        }

        public async Task<bool> DeleteSkill(int id)
        {
            return await _skillRepository.DeleteSkill(id);
        }
    }
}
