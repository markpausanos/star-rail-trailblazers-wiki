using AutoMapper;
using trailblazers_api.Dtos.Paths;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Paths;

namespace trailblazers_api.Services.Paths
{
    public class PathSRService : IPathSRService
    {
        private readonly IPathSRRepository _pathRepository;
        private readonly IMapper _mapper;

        public PathSRService(IPathSRRepository repository, IMapper mapper)
        {
            _pathRepository = repository;
            _mapper = mapper;
        }

        public async Task<PathSRDto> CreatePathSR(PathSRCreationDto newPath)
        {
            var pathToCreate = _mapper.Map<PathSR>(newPath);

            var newlyCreatedPath = await _pathRepository.GetPathSRById(await _pathRepository.CreatePathSR(pathToCreate));
            return _mapper.Map<PathSRDto>(newlyCreatedPath);
        }

        public async Task<IEnumerable<PathSRDto>> GetAllPathSRs()
        {
            var paths = await _pathRepository.GetAllPathSRs();

            return paths.Select(path => _mapper.Map<PathSRDto>(path));
        }

        public async Task<PathSRDto?> GetPathSRById(int id)
        {
            var path = await _pathRepository.GetPathSRById(id);

            return path == null ? null : _mapper.Map<PathSRDto>(path);
        }

        public async Task<PathSRDto?> GetPathSRByName(string name)
        {
            var path = await _pathRepository.GetPathSRByName(name);

            return path == null ? null : _mapper.Map<PathSRDto>(path);
        }

        public async Task<bool> UpdatePathSR(int id, PathSRUpdateDto updatedPath)
        {
            var pathToUpdate = _mapper.Map<PathSR>(updatedPath);
            pathToUpdate.Id = id;

            return await _pathRepository.UpdatePathSR(pathToUpdate);
        }

        public async Task<bool> DeletePathSR(int id)
        {
            return await _pathRepository.DeletePathSR(id);
        }
    }
}
