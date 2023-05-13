using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Relics
{
    /// <summary>
    /// Relic creation DTO class
    /// </summary>
    public class RelicCreationDto
    {
        /// <summary>
        /// Name of the Relic
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        /// <summary>
        /// DescriptionOne of the Relic
        /// </summary>
        [Required(ErrorMessage = "DescriptionOne is a required field")]
        public string? DescriptionOne { get; set; }

        /// <summary>
        /// DescriptionTwo of the Relic
        /// </summary>
        [Required(ErrorMessage = "DescriptionTwo is a required field")]
        public string? DescriptionTwo { get; set; }

        /// <summary>
        /// Directory path of the Relic image
        /// </summary>
        [Required(ErrorMessage = "Imaged is a required field")]
        public string? Image { get; set; }
    }
}
