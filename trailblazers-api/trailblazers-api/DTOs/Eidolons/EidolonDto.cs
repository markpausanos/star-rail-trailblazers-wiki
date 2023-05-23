namespace trailblazers_api.Dtos.Eidolons
{
    public class EidolonDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }
        public int TrailblazerId { get; set; }
    }
}
