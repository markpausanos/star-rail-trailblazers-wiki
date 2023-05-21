using trailblazers_api.Dtos.Lightcones;
using trailblazers_api.Dtos.Ornaments;
using trailblazers_api.Dtos.Relics;
using trailblazers_api.Dtos.Trailblazers;
using trailblazers_api.Dtos.Users;

namespace trailblazers_api.Dtos.Builds
{
    public class BuildDto
    {
        public int Id { get; set; }

        public string? Name { get; set; }
        public UserIdNameDto? User { get; set; }
        public TrailblazerDto? Trailblazer { get; set; }
        public LightconeDto? Lightcone { get; set; }
        public RelicDto? Relic { get; set; }
        public OrnamentDto? Ornament { get; set; }
        public int TotalLikes { get; set; }
        public bool IsLike { get; set; }
    }
}
