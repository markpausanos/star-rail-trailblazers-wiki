using AutoMapper;
using trailblazers_api.Dtos.Traces;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Traces;

namespace trailblazers_api.Services.Traces
{
    public class TraceService : ITraceService
    {
        private readonly ITraceRepository _traceRepository;
        private readonly IMapper _mapper;

        public TraceService(ITraceRepository repository, IMapper mapper)
        {
            _traceRepository = repository;
            _mapper = mapper;
        }

        public async Task<TraceDto?> CreateTrace(TraceCreationDto newTrace)
        {
            var traceToCreate = _mapper.Map<Trace>(newTrace);

            var newlyCreatedTrace = await _traceRepository.GetTraceById(await _traceRepository.CreateTrace(traceToCreate));
            return _mapper.Map<TraceDto>(newlyCreatedTrace);
        }

        public async Task<IEnumerable<TraceDto>> GetAllTraces()
        {
            var traces = await _traceRepository.GetAllTraces();

            return traces.Select(trace => _mapper.Map<TraceDto>(trace));
        }

        public async Task<IEnumerable<TraceDto>> GetTracesByTrailblazerId(int trailblazerId)
        {
            var traces = await _traceRepository.GetTracesByTrailblazerId(trailblazerId);

            return traces.Select(trace => _mapper.Map<TraceDto>(trace));
        }

        public async Task<TraceDto?> GetTraceById(int id)
        {
            var trace = await _traceRepository.GetTraceById(id);

            return trace == null ? null : _mapper.Map<TraceDto>(trace);
        }

        public async Task<bool> UpdateTrace(int id, TraceUpdateDto updatedtrace)
        {
            var traceToUpdate = _mapper.Map<Trace>(updatedtrace);
            traceToUpdate.Id = id;

            return await _traceRepository.UpdateTrace(traceToUpdate);
        }

        public async Task<bool> DeleteTrace(int id)
        {
            return await _traceRepository.DeleteTrace(id);
        }
    }
}
