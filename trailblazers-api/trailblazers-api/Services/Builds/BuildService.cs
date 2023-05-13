using trailblazers_api.DTOs.Builds;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Builds;

namespace trailblazers_api.Services.Builds
{
    public class BuildService
    {
        private readonly IBuildRepository _repository;

        public BuildService(IBuildRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateBuild(BuildCreationDto build)
        {
            var buildModel = new Build();
            buildModel.User.Id = build.UserId;
            buildModel.Trailblazer.Id = build.TrailblazerId;
            // Chang'e l8r, maybe, not sure

            return await _repository.CreateBuild(buildModel);
        }

        public async Task<BuildDto?> GetBuildById(int id)
        {
            var build = await _repository.GetBuildById(id);
            if (build == null) return null;

            return new BuildDto
            {
                Id = build.Id,
                UserId = build.User.Id,
                TrailblazerId = build.Trailblazer.Id,
                LightconeId = build.Lightcone.Id,
                RelicIds = build.Relics.Select(relic => relic.Id).ToList(),
                OrnamentIds = build.Ornaments.Select(ornament => ornament.Id).ToList()
            };
        }
    }
}
