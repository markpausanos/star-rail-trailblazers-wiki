using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Paths
{
    /// <summary>
    /// Path creation DTO class
    /// </summary>
    public class PathSRCreationDto
    {
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
