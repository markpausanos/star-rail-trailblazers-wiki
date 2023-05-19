using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Ornaments
{
    public class OrnamentCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }
    }
}
