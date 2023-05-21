namespace trailblazers_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public char? UserType { get; set; } = 'U';
    }
}
