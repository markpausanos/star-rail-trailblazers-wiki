using trailblazers_api.Dtos.Trailblazers;

namespace trailblazers_api.Services.Trailblazers
{
    public interface ITrailblazerService
    {
        Task<IEnumerable<TrailblazerDto>> GetAllTrailblazers();
    }
}
