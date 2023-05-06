namespace trailblazers_api.Models
{
    public class Build
    {
        public int Id { get; set; }
        public User? User { get; set; }
        public Trailblazer? Trailblazer { get; set; }
        public List<Relic> Relics { get; set; } = new List<Relic>();
        public List<Ornament> Ornaments { get; set; } = new List<Ornament>();
    }
}
