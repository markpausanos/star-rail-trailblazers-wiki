using trailblazers_api.Dtos.Trailblazers;

namespace trailblazers_api.Services.Trailblazers
{
    public interface ITrailblazerService
    {
        Task<TrailblazerDto?> CreateTrailblazer(TrailblazerCreationDto newTrailblazer);
        Task<IEnumerable<TrailblazerDto>> GetAllTrailblazers();
        Task<TrailblazerDto?> GetTrailblazerById(int id);
        Task<bool> UpdateTrailblazer(int id, TrailblazerUpdateDto updatedTrailblazer);
    }
}
