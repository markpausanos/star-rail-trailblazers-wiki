namespace trailblazers_api.Models
{
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TeamId { get; set; }
        public bool IsLike { get; set; }
    }
}
