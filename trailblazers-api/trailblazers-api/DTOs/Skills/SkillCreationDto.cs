using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Skills
{
    public class SkillCreationDto
    {
        [Required(ErrorMessage = "Title is a required field")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }
        public string? Image { get; set; }

        [Required(ErrorMessage = "Type is a required field")]
        public string? Type { get; set; }

        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }
    }
}
