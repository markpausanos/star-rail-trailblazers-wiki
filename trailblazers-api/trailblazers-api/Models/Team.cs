namespace trailblazers_api.Models
{
    public class Team
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public List<Build> Builds { get; set; } = new List<Build>();
    }
}
