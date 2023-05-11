namespace trailblazers_api.Models
{
    public class Eidolon
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }
        public Trailblazer? Trailblazer { get; set; }
    }
}
