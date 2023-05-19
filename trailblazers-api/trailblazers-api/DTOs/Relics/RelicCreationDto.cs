using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Relics
{
    public class RelicCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "DescriptionOne is a required field")]
        public string? DescriptionOne { get; set; }

        [Required(ErrorMessage = "DescriptionTwo is a required field")]
        public string? DescriptionTwo { get; set; }

        public string? Image { get; set; }
    }
}
