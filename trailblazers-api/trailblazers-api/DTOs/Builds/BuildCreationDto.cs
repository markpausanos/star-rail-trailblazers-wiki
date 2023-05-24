using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Builds
{
    public class BuildCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }
        public int UserId { get; set; }

        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }

        [Required(ErrorMessage = "LightconeId is a required field")]
        public int LightconeId { get; set; }

        [Required(ErrorMessage = "RelicId is a required field")]
        public int RelicId { get; set; }

        [Required(ErrorMessage = "OrnamentId is a required field")]
        public int OrnamentId { get; set; }
    }
}
