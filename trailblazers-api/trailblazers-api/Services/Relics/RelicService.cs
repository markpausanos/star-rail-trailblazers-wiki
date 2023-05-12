using System.IO;
using trailblazers_api.DTOs.Elements;
using trailblazers_api.DTOs.Paths;
using trailblazers_api.DTOs.Relics;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Relics;

namespace trailblazers_api.Services.Relics
{
    public class RelicService : IRelicService
    {
        private readonly IRelicRepository _repository;

        public RelicService(IRelicRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateRelic(RelicCreationDto relic)
        {
            var relicModel = new Relic
            {
                Name = relic.Name,
                DescriptionOne = relic.DescriptionOne,
                DescriptionTwo = relic.DescriptionTwo,
                Image = relic.Image
            };
            
            return relicModel.Id = await _repository.CreateRelic(relicModel);
        }

        public async Task<IEnumerable<RelicDto>> GetAllRelics()
        {
            var relics = await _repository.GetAllRelics();
            if (relics == null) return null;

            return relics.Select(relic => new RelicDto
            {
                Id = relic.Id,
                Name = relic.Name,
                DescriptionOne = relic.DescriptionOne,
                DescriptionTwo = relic.DescriptionTwo,
                Image = relic.Image
            });
        }

        public async Task<RelicDto?> GetRelicById(int id)
        {
            var relic = await _repository.GetRelicById(id);
            if (relic == null) return null;

            return new RelicDto
            {
                Id = relic.Id,
                Name = relic.Name,
                DescriptionOne = relic.DescriptionOne,
                DescriptionTwo = relic.DescriptionTwo,
                Image = relic.Image
            };
        }

        public async Task<RelicDto?> GetRelicByName(string name)
        {
            var relic = await _repository.GetRelicByName(name);
            if (relic == null) return null;

            return new RelicDto
            {
                Id = relic.Id,
                Name = relic.Name,
                DescriptionOne = relic.DescriptionOne,
                DescriptionTwo = relic.DescriptionTwo,
                Image = relic.Image
            };
        }

        public async Task<bool> UpdateRelic(RelicUpdateDto relic)
        {
            var relicModel = new Relic
            {
                Id = relic.Id,
                Name = relic.Name,
                DescriptionOne = relic.DescriptionOne,
                DescriptionTwo = relic.DescriptionTwo,
                Image = relic.Image
            };
            return await _repository.UpdateRelic(relicModel);
        }

        public async Task<bool> DeleteRelic(int id)
        {
            return await _repository.DeleteRelic(id);
        }
    }
}
