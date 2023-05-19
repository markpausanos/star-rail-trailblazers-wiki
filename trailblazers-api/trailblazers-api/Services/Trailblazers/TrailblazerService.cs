using AutoMapper;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Trailblazers;

namespace trailblazers_api.Services.Trailblazers
{
    public class TrailblazerService : ITrailblazerService
    {
        private readonly ITrailblazersRepository _trailblazerRepository;
        private readonly IMapper _mapper;

        public TrailblazerService(ITrailblazersRepository trailblazerRepository, IMapper mapper)
        {
            _trailblazerRepository = trailblazerRepository;
            _mapper = mapper;
        }

        public async Task<TrailblazerDto?> CreateTrailblazer(TrailblazerCreationDto newTrailblazer)
        {
            var trailblazerToCreate = _mapper.Map<Trailblazer>(newTrailblazer);

            var newlyCreatedTrailblazer = await _trailblazerRepository.GetTrailblazerById(await _trailblazerRepository.CreateTrailblazer(trailblazerToCreate));
            return _mapper.Map<TrailblazerDto>(newlyCreatedTrailblazer);
        }

        public async Task<IEnumerable<TrailblazerDto>> GetAllTrailblazers()
        {
            var trailblazers = await _trailblazerRepository.GetAllTrailblazers();

            return trailblazers.Select(trailblazer => _mapper.Map<TrailblazerDto>(trailblazer));
        }

        public async Task<TrailblazerDto?> GetTrailblazerById(int id)
        {
            var trailblazer = await _trailblazerRepository.GetTrailblazerById(id);

            return trailblazer == null ? null : _mapper.Map<TrailblazerDto>(trailblazer);
        }

        public async Task<bool> UpdateTrailblazer(int id, TrailblazerUpdateDto updatedTrailblazer)
        {
            var trailblazerToUpdate = _mapper.Map<Trailblazer>(updatedTrailblazer);
            trailblazerToUpdate.Id = id;

            return await _trailblazerRepository.UpdateTrailblazer(trailblazerToUpdate);
        }
    }
}
