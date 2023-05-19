using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Trailblazers
{
    public class TrailblazerCreationDto
    {
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }
        public string? Image { get; set; }

        [Required(ErrorMessage = "Rarity is a required field")]
        public int Rarity { get; set; }

        [Required(ErrorMessage = "Base HP is a required field")]
        public int BaseHp { get; set; }

        [Required(ErrorMessage = "Base ATK is a required field")]
        public int BaseAtk { get; set; }

        [Required(ErrorMessage = "Base DEF is a required field")]
        public int BaseDef { get; set; }

        [Required(ErrorMessage = "Base Speed is a required field")]
        public int BaseSpeed { get; set; }

        [Required(ErrorMessage = "Element ID is a required field")]
        public int ElementId { get; set; }

        [Required(ErrorMessage = "Path ID is a required field")]
        public int PathId { get; set; }
    }
}
