namespace trailblazers_api.Models
{
    public class Build
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TrailblazerId { get; set; }
        public List<Relic> Relics { get; set; } = new List<Relic>();
        public List<Ornament> Ornaments { get; set; } = new List<Ornament>();
    }
}
