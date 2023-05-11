using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Paths
{
    /// <summary>
    /// Path update DTO class
    /// </summary>
    public class PathSRUpdateDto
    {
        /// <summary>
        /// Id of the Path
        /// </summary>
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        /// <summary>
        /// Name of the Path
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string Name { get; set; }

        /// <summary>
        /// Directory path of the Path image
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string Image { get; set; }
    }
}
