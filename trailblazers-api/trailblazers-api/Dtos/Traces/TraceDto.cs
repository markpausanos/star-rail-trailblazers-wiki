namespace trailblazers_api.Dtos.Traces
{
    public class TraceDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public int Order { get; set; }
        public int TrailblazerId { get; set; }
    }
}
