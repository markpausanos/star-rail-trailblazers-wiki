using AutoMapper;
using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Eidolons;

namespace trailblazers_api.Services.Eidolons
{
    public class EidolonService : IEidolonService
    {
        private readonly IEidolonRepository _eidolonRepository;
        private readonly IMapper _mapper;

        public EidolonService(IEidolonRepository repository, IMapper mapper)
        {
            _eidolonRepository = repository;
            _mapper = mapper;
        }

        public async Task<EidolonDto?> CreateEidolon(EidolonCreationDto newEidolon)
        {
            var eidolonToCreate = _mapper.Map<Eidolon>(newEidolon);

            var newlyCreatedEidolon = await _eidolonRepository.GetEidolonById(await _eidolonRepository.CreateEidolon(eidolonToCreate));
            return _mapper.Map<EidolonDto>(newlyCreatedEidolon);
        }

        public async Task<IEnumerable<EidolonDto>> GetAllEidolons()
        {
            var eidolons = await _eidolonRepository.GetAllEidolons();

            return eidolons.Select(eidolon => _mapper.Map<EidolonDto>(eidolon));
        }

        public async Task<IEnumerable<EidolonDto>> GetEidolonsByTrailblazerId(int trailblazerId)
        {
            var eidolons = await _eidolonRepository.GetEidolonsByTrailblazerId(trailblazerId);

            return eidolons.Select(eidolon => _mapper.Map<EidolonDto>(eidolon));
        }

        public async Task<EidolonDto?> GetEidolonById(int id)
        {
            var eidolon = await _eidolonRepository.GetEidolonById(id);

            return eidolon == null ? null : _mapper.Map<EidolonDto>(eidolon);
        }

        public async Task<bool> UpdateEidolon(int id, EidolonUpdateDto updatedeidolon)
        {
            var eidolonToUpdate = _mapper.Map<Eidolon>(updatedeidolon);
            eidolonToUpdate.Id = id;

            return await _eidolonRepository.UpdateEidolon(eidolonToUpdate);
        }

        public async Task<bool> DeleteEidolon(int id)
        {
            return await _eidolonRepository.DeleteEidolon(id);
        }
    }
}
