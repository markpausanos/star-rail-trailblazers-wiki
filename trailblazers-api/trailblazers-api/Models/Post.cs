namespace trailblazers_api.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public User? User { get; set; }
        public Team? Team { get; set; }
    }
}
