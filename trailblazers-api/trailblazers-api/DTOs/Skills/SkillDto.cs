using trailblazers_api.Dtos.Trailblazers;

namespace trailblazers_api.Dtos.Skills
{
    public class SkillDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Type { get; set; }
        public TrailblazerIdNameDto? Trailblazer{ get; set; }
    }
}
