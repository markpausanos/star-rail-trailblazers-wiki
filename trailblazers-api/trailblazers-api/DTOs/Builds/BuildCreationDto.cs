using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Builds
{
    /// <summary>
    /// Build creation DTO class
    /// </summary>
    public class BuildCreationDto
    {
        /// <summary>
        /// UserId of the Build
        /// </summary>
        [Required(ErrorMessage = "UserId is a required field")]
        public int UserId { get; set; }

        /// <summary>
        /// TrailblazerId of the Build
        /// </summary>
        [Required(ErrorMessage = "TrailblazerId is a required field")]
        public int TrailblazerId { get; set; }
    }
}
