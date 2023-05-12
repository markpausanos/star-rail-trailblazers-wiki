using System.ComponentModel.DataAnnotations;

namespace trailblazers_api.DTOs.Lightcones
{
    /// <summary>
    /// Lightcone DTO class
    /// </summary>
    public class LightconeUpdateDto
    {
        /// <summary>
        /// Id of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "Id is a required field")]
        public int Id { get; set; }

        /// <summary>
        /// Title of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "Title is a required field")]
        public string? Title { get; set; }

        /// <summary>
        /// Name of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "Name is a required field")]
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "Description is a required field")]
        public string? Description { get; set; }

        /// <summary>
        /// Directory path of the Lightcone image
        /// </summary>
        [Required(ErrorMessage = "Image is a required field")]
        public string? Image { get; set; }

        /// <summary>
        /// Rarity of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "Rarity is a required field")]
        public int Rarity { get; set; }

        /// <summary>
        /// BaseAtk stat of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "BaseHp is a required field")]
        public int BaseHp { get; set; }

        /// <summary>
        /// BaseAtk stat of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "BaseAtk is a required field")]
        public int BaseAtk { get; set; }

        /// <summary>
        /// BaseDef stat of the Lightcone
        /// </summary>
        [Required(ErrorMessage = "BaseDef is a required field")]
        public int BaseDef { get; set; }
    }
}
