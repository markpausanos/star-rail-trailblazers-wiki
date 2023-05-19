using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Elements
{
    public class ElementCreationDto
    {
        /// <summary>
        /// Name of the Element
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        /// <summary>
        /// Directory path of the Element image
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }
    }
}
