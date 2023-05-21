using AutoMapper;
using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Lightcones;

namespace trailblazers_api.Services.Lightcones
{
    public class LightconeService : ILightconeService
    {
        private readonly ILightconeRepository _lightconeRepository;
        private readonly IMapper _mapper;

        public LightconeService(ILightconeRepository repository, IMapper mapper)
        {
            _lightconeRepository = repository;
            _mapper = mapper;
        }   

        public async Task<LightconeDto?> CreateLightcone(LightconeCreationDto newLightcone)
        {
            var lightconeToCreate = _mapper.Map<Lightcone>(newLightcone);

            var newlyCreatedLightcone = await _lightconeRepository.GetLightconeById(await _lightconeRepository.CreateLightcone(lightconeToCreate));
            return _mapper.Map<LightconeDto>(newlyCreatedLightcone);
        }

        public async Task<IEnumerable<LightconeDto>> GetAllLightcones()
        {
            var lightcones = await _lightconeRepository.GetAllLightcones();

            return lightcones.Select(lightcone => _mapper.Map<LightconeDto>(lightcone));
        }

        public async Task<LightconeDto?> GetLightconeById(int id)
        {
            var lightcone = await _lightconeRepository.GetLightconeById(id);

            return lightcone == null ? null : _mapper.Map<LightconeDto>(lightcone);
        }

        public async Task<LightconeDto?> GetLightconeByName(string name)
        {
            var lightcone = await _lightconeRepository.GetLightconeByName(name);

            return lightcone == null ? null : _mapper.Map<LightconeDto>(lightcone);
        }

        public async Task<bool> UpdateLightcone(int id, LightconeUpdateDto updatedLightcone)
        {
            var lightconeToUpdate = _mapper.Map<Lightcone>(updatedLightcone);
            lightconeToUpdate.Id = id;

            return await _lightconeRepository.UpdateLightcone(lightconeToUpdate);
        }

        public async Task<bool> DeleteLightcone(int id)
        {
            return await _lightconeRepository.DeleteLightcone(id);
        }
    }
}
