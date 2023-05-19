using AutoMapper;
using trailblazers_api.Dtos.Trailblazers;
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

        public async Task<IEnumerable<TrailblazerDto>> GetAllTrailblazers()
        {
            var trailblazers = await _trailblazerRepository.GetAllTrailblazers();

            return trailblazers.Select(trailblazer => _mapper.Map<TrailblazerDto>(trailblazer));
        }

    }
}
