using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Paths
{
    public class PathSRCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }
    }
}
