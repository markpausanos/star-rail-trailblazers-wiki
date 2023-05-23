using AutoMapper;
using trailblazers_api.Dtos.Builds;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Builds;

namespace trailblazers_api.Services.Builds
{
    public class BuildService : IBuildService
    {
        private readonly IBuildRepository _buildRepository;
        private readonly IBuildLikeRepository _buildLikeRepository;
        private readonly IMapper _mapper;
        public BuildService(IBuildRepository buildRepository, IBuildLikeRepository buildLikerepository, IMapper mapper)
        {
            _buildRepository = buildRepository;
            _buildLikeRepository = buildLikerepository;
            _mapper = mapper;
        }

        public async Task<BuildDto?> CreateBuild(BuildCreationDto newBuild)
        {
            var buildToCreate = _mapper.Map<Build>(newBuild);

            var newlyCreatedBuild = await _buildRepository.GetBuildById(await _buildRepository.CreateBuild(buildToCreate));
            return _mapper.Map<BuildDto>(newlyCreatedBuild);
        }

        public async Task<IEnumerable<BuildDto>> GetAllBuilds(int userId)
        {
            var builds = await _buildRepository.GetAllBuilds();
            var buildsDtos = builds.Select(build => _mapper.Map<BuildDto>(build)).ToList();

            for (int i = 0; i < buildsDtos.Count(); i++)
            {
                buildsDtos[i].TotalLikes = await _buildLikeRepository.GetTotalLikesByBuild(buildsDtos[i].Id);
                buildsDtos[i].IsLike = await _buildLikeRepository.IsLikedByUser(userId, buildsDtos[i].Id);
            }

            return buildsDtos;
        }

        public async Task<bool> AddLike(int userId, int buildId)
        {
            return await _buildLikeRepository.AddLike(userId, buildId);
        }
        public async Task<BuildDto?> GetBuildById(int id)
        {
            var build = await _buildRepository.GetBuildById(id);

            return build == null ? null : _mapper.Map<BuildDto>(build);
        }
        public async Task<bool> UpdateBuild(int id, BuildUpdateDto updatedBuild)
        {
            var buildToUpdate = _mapper.Map<Build>(updatedBuild);
            buildToUpdate.Id = id;

            return await _buildRepository.UpdateBuild(buildToUpdate);
        }

        public async Task<bool> RemoveLike(int userId, int buildId)
        {
            return await _buildLikeRepository.RemoveLike(userId, buildId);
        }
        public async Task<bool> DeleteBuild(int id)
        {
            return await _buildRepository.DeleteBuild(id);
        }
    }
}
