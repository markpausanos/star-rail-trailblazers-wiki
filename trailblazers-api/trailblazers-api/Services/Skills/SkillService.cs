using AutoMapper;
using trailblazers_api.Dtos.Skills;
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

            return skills.Select(skill => _mapper.Map<SkillDto>(skill));
        }

        public async Task<IEnumerable<SkillDto>> GetSkillsByTrailblazerId(int trailblazerId)
        {
            var skills = await _skillRepository.GetSkillsByTrailblazerId(trailblazerId);

            return skills.Select(skill => _mapper.Map<SkillDto>(skill));
        }

        public async Task<SkillDto?> GetSkillById(int id)
        {
            var skill = await _skillRepository.GetSkillById(id);

            return skill == null ? null : _mapper.Map<SkillDto>(skill);
        }

        public async Task<bool> UpdateSkill(int id, SkillUpdateDto updatedskill)
        {
            var skillToUpdate = _mapper.Map<Skill>(updatedskill);
            skillToUpdate.Id = id;

            return await _skillRepository.UpdateSkill(skillToUpdate);
        }

        public async Task<bool> DeleteSkill(int id)
        {
            return await _skillRepository.DeleteSkill(id);
        }
    }
}
