using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Lightcones;

namespace trailblazers_api.Services.Lightcones
{
    public class LightconeService : ILightconeService
    {
        private readonly ILightconeRepository _repository;

        public LightconeService(ILightconeRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateLightcone(LightconeCreationDto lightcone)
        {
            var lightcodeModel = new Lightcone
            {
                Title = lightcone.Title,
                Name = lightcone.Name,
                Description = lightcone.Description,
                Image = lightcone.Image,
                Rarity = lightcone.Rarity,
                BaseHp = lightcone.BaseHp,
                BaseAtk = lightcone.BaseAtk,
                BaseDef = lightcone.BaseDef
            };

            return lightcodeModel.Id = await _repository.CreateLightcone(lightcodeModel);
        }

        public async Task<IEnumerable<LightconeDto>> GetAllLightcones()
        {
            var lightcones = await _repository.GetAllLightcones();
            if (lightcones == null) return null;

            return lightcones.Select(lightcone => new LightconeDto
            {
                Id = lightcone.Id,
                Title = lightcone.Title,
                Name = lightcone.Name,
                Description = lightcone.Description,
                Image = lightcone.Image,
                Rarity = lightcone.Rarity,
                BaseHp = lightcone.BaseHp,
                BaseAtk= lightcone.BaseAtk,
                BaseDef = lightcone.BaseDef
            });
        }

        public async Task<LightconeDto> GetLightconeById(int id)
        {
            var lightcone = await _repository.GetLightconeById(id);
            if (lightcone == null) return null;

            return new LightconeDto
            {
                Id = lightcone.Id,
                Title = lightcone.Title,
                Name = lightcone.Name,
                Description = lightcone.Description,
                Image = lightcone.Image,
                Rarity = lightcone.Rarity,
                BaseHp = lightcone.BaseHp,
                BaseAtk = lightcone.BaseAtk,
                BaseDef = lightcone.BaseDef
            };
        }

        public async Task<LightconeDto> GetLightconeByName(string name)
        {
            var lightcone = await _repository.GetLightconeByName(name);
            if (lightcone == null) return null;

            return new LightconeDto
            {
                Id = lightcone.Id,
                Title = lightcone.Title,
                Name = lightcone.Name,
                Description = lightcone.Description,
                Image = lightcone.Image,
                Rarity = lightcone.Rarity,
                BaseHp = lightcone.BaseHp,
                BaseAtk = lightcone.BaseAtk,
                BaseDef = lightcone.BaseDef
            };
        }

        public async Task<bool> UpdateLightcone(LightconeUpdateDto lightcone)
        {
            var lightconeModel = new Lightcone
            {
                Id = lightcone.Id,
                Title = lightcone.Title,
                Name = lightcone.Name,
                Description = lightcone.Description,
                Image = lightcone.Image,
                BaseHp = lightcone.BaseHp,
                BaseAtk = lightcone.BaseAtk,
                BaseDef = lightcone.BaseDef
            };
            return await _repository.UpdateLightcone(lightconeModel);
        }

        public async Task<bool> DeleteLightcone(int id)
        {
            return await _repository.DeleteLightcone(id);
        }
    }
}
