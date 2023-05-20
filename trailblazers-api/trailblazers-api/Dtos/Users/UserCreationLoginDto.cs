using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Users
{
    public class UserCreationLoginDto
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(5, ErrorMessage = "Name too short")]
        [MaxLength(50, ErrorMessage = "Name can have at most 50 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(6, ErrorMessage = "Password too short")]
        [MaxLength(50, ErrorMessage = "Password can have at most 50 characters")]
        public string? Password { get; set; }
    }
}
