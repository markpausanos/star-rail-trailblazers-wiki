using AutoMapper;
using trailblazers_api.DTOs.Relics;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Relics;

namespace trailblazers_api.Services.Relics
{
    public class RelicService : IRelicService
    {
        private readonly IRelicRepository _relicRepository;
        private readonly IMapper _mapper;

        public RelicService(IRelicRepository repository, IMapper mapper)
        {
            _relicRepository = repository;
            _mapper = mapper;
        }

        public async Task<RelicDto?> CreateRelic(RelicCreationDto newRelic)
        {
            var relicToCreate = _mapper.Map<Relic>(newRelic);

            var newlyCreatedRelic = await _relicRepository.GetRelicById(await _relicRepository.CreateRelic(relicToCreate));
            return _mapper.Map<RelicDto>(newlyCreatedRelic);
        }

        public async Task<IEnumerable<RelicDto>> GetAllRelics()
        {
            var relics = await _relicRepository.GetAllRelics();

            return relics.Select(relic => _mapper.Map<RelicDto>(relic));
        }

        public async Task<RelicDto?> GetRelicById(int id)
        {
            var relic = await _relicRepository.GetRelicById(id);

            return relic == null ? null : _mapper.Map<RelicDto>(relic);
        }

        public async Task<RelicDto?> GetRelicByName(string name)
        {
            var relic = await _relicRepository.GetRelicByName(name);

            return relic == null ? null : _mapper.Map<RelicDto>(relic);
        }

        public async Task<bool> UpdateRelic(int id, RelicUpdateDto updatedRelic)
        {
            var relicToUpdate = _mapper.Map<Relic>(updatedRelic);
            relicToUpdate.Id = id;

            return await _relicRepository.UpdateRelic(id, relicToUpdate);
        }

        public async Task<bool> DeleteRelic(int id)
        {
            return await _relicRepository.DeleteRelic(id);
        }
    }
}
