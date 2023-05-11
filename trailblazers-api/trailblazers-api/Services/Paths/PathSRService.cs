using trailblazers_api.DTOs.Paths;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Paths;

namespace trailblazers_api.Services.Paths
{
    public class PathSRService :IPathSRService
    {
        private readonly IPathSRRepository _repository;

        public PathSRService(IPathSRRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreatePathSR(PathSRCreationDto path)
        {
            var pathModel = new PathSR
            {
                Name = path.Name,
                Image = path.Image
            };
            
            return pathModel.Id = await _repository.CreatePathSR(pathModel);
        }

        public async Task<IEnumerable<PathSRDto>> GetAllPathSRs()
        {
            var paths = await _repository.GetAllPathSRs();
            if (paths == null) return null;

            return paths.Select(path => new PathSRDto
            {
                Id = path.Id,
                Name = path.Name,
                Image = path.Image
            });
        }

        public async Task<PathSRDto?> GetPathSRById(int id)
        {
            var path = await _repository.GetPathSRById(id);
            if (path == null) return null;

            return new PathSRDto
            {
                Id = path.Id,
                Name = path.Name,
                Image = path.Image
            };
        }

        public async Task<PathSRDto?> GetPathSRByName(string name)
        {
            var path = await _repository.GetPathSRByName(name);
            if (path == null) return null;

            return new PathSRDto
            {
                Id = path.Id,
                Name = path.Name,
                Image = path.Image
            };
        }

        public async Task<bool> UpdatePathSR(PathSRUpdateDto path)
        {
            var pathModel = new PathSR
            {
                Id = path.Id,
                Name = path.Name,
                Image = path.Image
            };
            return await _repository.UpdatePathSR(pathModel);
        }

        public async Task<bool> DeletePathSR(int id)
        {
            return await _repository.DeletePathSR(id);
        }
    }
}
