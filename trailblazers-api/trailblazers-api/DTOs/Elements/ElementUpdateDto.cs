using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Elements
{
    /// <summary>
    /// Element update DTO class
    /// </summary>
    public class ElementUpdateDto
    {
        /// <summary>
        /// Id of the Element
        /// </summary>
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Element
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }

        /// <summary>
        /// Directory path of the Element image
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string Image { get; set; }
    }
}
