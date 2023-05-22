namespace trailblazers_api.Models
{
    public class Build
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public User? User { get; set; }
        public Trailblazer? Trailblazer { get; set; }
        public Lightcone? Lightcone { get; set; }
        public Relic? Relic { get; set; }
        public Ornament? Ornament { get; set; }
    }
}
