using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Relics
{
    public class RelicUpdateDto
    {
        public string? Name { get; set; }
        public string? DescriptionOne { get; set; }
        public string? DescriptionTwo { get; set; }
        public string? Image { get; set; }
    }
}
