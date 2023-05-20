using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Paths
{
    public class PathSRCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        public string? Image { get; set; }
    }
}
