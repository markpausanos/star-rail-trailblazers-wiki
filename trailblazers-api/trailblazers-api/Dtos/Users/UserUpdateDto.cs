using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Users
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }

        [MaxLength(50, ErrorMessage = "Password can have at most 50 characters")]
        public string? Password { get; set; }
    }
}
