using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.Dtos.Lightcones
{
    public class LightconeCreationDto
    {
        [Required(ErrorMessage = "Title is a required field")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }
        public string? Image { get; set; }

        [Required(ErrorMessage = "Rarity is a required field")]
        [Range(1, 5, ErrorMessage = "Rarity must be between 1 to 5")]
        public int Rarity { get; set; }

        [Required(ErrorMessage = "BaseHp is a required field")]
        public int BaseHp { get; set; }

        [Required(ErrorMessage = "BaseAtk is a required field")]
        public int BaseAtk { get; set; }

        [Required(ErrorMessage = "BaseDef is a required field")]
        public int BaseDef { get; set; }

        [Required(ErrorMessage = "Path ID is a required field")]
        public int PathId { get; set; }
    }
}
