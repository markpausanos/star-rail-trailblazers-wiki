
using trailblazers_api.Dtos.Eidolons;
using trailblazers_api.Dtos.Skills;
using trailblazers_api.Dtos.Traces;
using trailblazers_api.Dtos.Elements;
using trailblazers_api.Dtos.Paths;

namespace trailblazers_api.Dtos.Trailblazers
{
    public class TrailblazerDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public int Rarity { get; set; }
        public int BaseHp { get; set; }
        public int BaseAtk { get; set; }
        public int BaseDef { get; set; }
        public int BaseSpeed { get; set; }
        public ElementDto? Element { get; set; }
        public PathSRDto? PathSR { get; set; }
        public List<EidolonTrailblazerDto> Eidolons { get; set; } = new List<EidolonTrailblazerDto>();
        public List<TraceTrailblazerDto> Traces { get; set; } = new List<TraceTrailblazerDto>();
        public List<SkillsTrailblazerDto> Skills { get; set; } = new List<SkillsTrailblazerDto>();
    }
}
