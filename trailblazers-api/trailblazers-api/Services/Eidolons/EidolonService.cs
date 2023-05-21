using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Models;
using trailblazers_api.Repositories.Eidolons;

namespace trailblazers_api.Services.Eidolons
{
    public class EidolonService : IEidolonService
    {
        private readonly IEidolonRepository _repository;

        public EidolonService(IEidolonRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateEidolon(EidolonCreationDto eidolon)
        {
            var eidolonModel = new Eidolon
            {
                Name = eidolon.Name,
                Description = eidolon.Description,
                Image = eidolon.Image,
                Order = eidolon.Order
            };
            
            return await _repository.CreateEidolon(eidolonModel);
        }

        public async Task<IEnumerable<EidolonDto>> GetAllEidolonsByTrailblazerId(int trailblazerId)
        {
            var eidolons = await _repository.GetAllEidolonsByTrailblazerId(trailblazerId);
            if (eidolons == null) return null;

            return eidolons.Select(eidolon => new EidolonDto
            {
                Id = eidolon.Id,
                Name = eidolon.Name,
                Description = eidolon.Description,
                Image = eidolon.Image,
                Order = eidolon.Order
            });
        }

        public async Task<bool> UpdateEidolon(EidolonUpdateDto eidolon)
        {
            var eidolonModel = new Eidolon
            {
                Name = eidolon.Name,
                Description = eidolon.Description,
                Image = eidolon.Image,
                Order = eidolon.Order
            };

            return await _repository.UpdateEidolon(eidolonModel);
        }

        public async Task<bool> DeleteEidolon(int id)
        {
            return await _repository.DeleteEidolon(id);
        }
    }
}
