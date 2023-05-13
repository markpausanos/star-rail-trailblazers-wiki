using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Skills
{
    /// <summary>
    /// Skill creation DTO class
    /// </summary>
    public class SkillUpdateDto
    {
        /// <summary>
        /// Id of the Skill
        /// </summary>
        [Required(ErrorMessage = "Title is a required field")]
        public int Id { get; set; }

        /// <summary>
        /// Title of the Skill
        /// </summary>
        [Required(ErrorMessage = "Title is a required field")]
        public string? Title { get; set; }

        /// <summary>
        /// Name of the Skill
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Skill
        /// </summary>
        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }

        /// <summary>
        /// Image of the Skill
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }

        /// <summary>
        /// Type of the Skill
        /// </summary>
        [Required(ErrorMessage = "Type is a required field")]
        public string? Type { get; set; }

        /// <summary>
        /// Id of Trailblazer of the Skill
        /// </summary>
        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }
    }
}
