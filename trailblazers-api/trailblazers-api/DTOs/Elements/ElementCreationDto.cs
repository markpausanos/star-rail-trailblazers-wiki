using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Elements
{
    public class ElementCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
}
