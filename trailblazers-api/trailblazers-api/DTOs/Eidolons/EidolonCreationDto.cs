using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Eidolons
{
    public class EidolonCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }
        public string? Image { get; set; }

        [Required(ErrorMessage = "Order is a required field")]
        public int Order { get; set; }

        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }
    }
}
