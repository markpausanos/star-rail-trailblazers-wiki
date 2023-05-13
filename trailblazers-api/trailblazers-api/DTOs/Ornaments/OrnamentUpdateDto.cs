using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Ornaments
{
    /// <summary>
    /// Ornament update DTO class
    /// </summary>
    public class OrnamentUpdateDto
    {
        /// <summary>
        /// Id of the Ornament
        /// </summary>
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

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
