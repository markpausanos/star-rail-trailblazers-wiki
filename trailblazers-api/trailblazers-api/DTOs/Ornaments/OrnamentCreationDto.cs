using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Ornaments
{
    /// <summary>
    /// Ornament creation DTO class
    /// </summary>
    public class OrnamentCreationDto
    {
        /// <summary>
        /// Name of the Ornament
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Ornament
        /// </summary>
        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }

        /// <summary>
        /// Directory path of the Ornament image
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }
    }
}
