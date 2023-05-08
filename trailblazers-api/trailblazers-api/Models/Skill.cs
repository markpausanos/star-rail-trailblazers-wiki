namespace trailblazers_api.Models
{
    public class Skill
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Type { get; set; }
        public Trailblazer? Trailblazer { get; set; }
    }
}
