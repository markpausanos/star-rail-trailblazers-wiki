using trailblazers_api.DTOs.Ornaments;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Ornaments;

namespace trailblazers_api.Services.Ornaments
{
    public class OrnamentService : IOrnamentService
    {
        private readonly IOrnamentRepository _repository;

        public OrnamentService(IOrnamentRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateOrnament(OrnamentCreationDto ornament)
        {
            var ornamentModel = new Ornament
            {
                Name = ornament.Name,
                Description = ornament.Description,
                Image = ornament.Image
            };

            return ornamentModel.Id = await _repository.CreateOrnament(ornamentModel);
        }

        public async Task<IEnumerable<OrnamentDto>> GetAllOrnaments()
        {
            var ornaments = await _repository.GetAllOrnaments();
            if (ornaments == null) return null;

            return ornaments.Select(ornament => new OrnamentDto
            {
                Id = ornament.Id,
                Name = ornament.Name,
                Description = ornament.Description,
                Image = ornament.Image
            });
        }

        public async Task<OrnamentDto?> GetOrnamentById(int id)
        {
            var ornament = await _repository.GetOrnamentById(id);
            if (ornament == null) return null;

            return new OrnamentDto
            {
                Id = ornament.Id,
                Name = ornament.Name,
                Description = ornament.Description,
                Image = ornament.Image
            };
        }

        public async Task<OrnamentDto?> GetOrnamentByName(string name)
        {
            var ornament = await _repository.GetOrnamentByName(name);
            if (ornament == null) return null;

            return new OrnamentDto
            {
                Id = ornament.Id,
                Name = ornament.Name,
                Description = ornament.Description,
                Image = ornament.Image
            };
        }

        public async Task<bool> UpdateOrnament(OrnamentUpdateDto ornament)
        {
            var ornamentModel = new Ornament
            {
                Id = ornament.Id,
                Name = ornament.Name,
                Description = ornament.Description,
                Image = ornament.Image
            };
            return await _repository.UpdateOrnament(ornamentModel);
        }

        public async Task<bool> DeleteOrnament(int id)
        {
            return await _repository.DeleteOrnament(id);
        }
    }
}
