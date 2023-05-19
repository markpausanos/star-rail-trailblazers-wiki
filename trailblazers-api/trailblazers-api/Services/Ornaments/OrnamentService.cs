using AutoMapper;
using trailblazers_api.DTOs.Ornaments;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Ornaments;

namespace trailblazers_api.Services.Ornaments
{
    public class OrnamentService : IOrnamentService
    {
        private readonly IOrnamentRepository _ornamentRepository;
        private readonly IMapper _mapper;

        public OrnamentService(IOrnamentRepository repository, IMapper mapper)
        {
            _ornamentRepository = repository;
            _mapper = mapper;
        }

        public async Task<OrnamentDto?> CreateOrnament(OrnamentCreationDto newOrnament)
        {
            var ornamentToCreate = _mapper.Map<Ornament>(newOrnament);

            var newlyCreatedOrnament = await _ornamentRepository.GetOrnamentById(await _ornamentRepository.CreateOrnament(ornamentToCreate));
            return _mapper.Map<OrnamentDto>(newlyCreatedOrnament);
        }

        public async Task<IEnumerable<OrnamentDto>> GetAllOrnaments()
        {
            var ornaments = await _ornamentRepository.GetAllOrnaments();

            return ornaments.Select(ornament => _mapper.Map<OrnamentDto>(ornament));
        }

        public async Task<OrnamentDto?> GetOrnamentById(int id)
        {
            var ornament = await _ornamentRepository.GetOrnamentById(id);

            return ornament == null ? null : _mapper.Map<OrnamentDto>(ornament);
        }

        public async Task<OrnamentDto?> GetOrnamentByName(string name)
        {
            var ornament = await _ornamentRepository.GetOrnamentByName(name);

            return ornament == null ? null : _mapper.Map<OrnamentDto>(ornament);
        }

        public async Task<bool> UpdateOrnament(int id, OrnamentUpdateDto updatedOrnament)
        {
            var ornamentToUpdate = _mapper.Map<Ornament>(updatedOrnament);
            ornamentToUpdate.Id = id;

            return await _ornamentRepository.UpdateOrnament(ornamentToUpdate);
        }

        public async Task<bool> DeleteOrnament(int id)
        {
            return await _ornamentRepository.DeleteOrnament(id);
        }
    }
}
