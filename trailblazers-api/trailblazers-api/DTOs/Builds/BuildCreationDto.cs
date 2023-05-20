using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Builds
{
    public class BuildCreationDto
    {
        [Required(ErrorMessage = "UserId is a required field")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }
    }
}
