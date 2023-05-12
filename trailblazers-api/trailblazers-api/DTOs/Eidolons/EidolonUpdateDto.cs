using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Eidolons
{
    /// <summary>
    /// Element update DTO class
    /// </summary>
    public class EidolonUpdateDto
    {
        /// <summary>
        /// Id of the Eidolon
        /// </summary>
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Eidolon
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Eidolon
        /// </summary>
        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }

        /// <summary>
        /// Directory path of the Eidolon image
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }

        /// <summary>
        /// Order of the Eidolon
        /// </summary>
        [Required(ErrorMessage = "Order is a required field")]
        public int Order { get; set; }

        /// <summary>
        /// Id of the Eidolon's Trailblazer
        /// </summary>
        /*
        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }
        */
    }
}
