namespace trailblazers_api.DTOs.Lightcones
{
    /// <summary>
    /// Lightcone DTO class
    /// </summary>
    public class LightconeDto
    {
        /// <summary>
        /// Id of the Lightcone
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the Lightcone
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Name of the Lightcone
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Lightcone
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Directory path of the Lightcone image
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Rarity of the Lightcone
        /// </summary>
        public int Rarity { get; set; }

        /// <summary>
        /// BaseAtk stat of the Lightcone
        /// </summary>
        public int BaseHp { get; set; }

        /// <summary>
        /// BaseAtk stat of the Lightcone
        /// </summary>
        public int BaseAtk { get; set; }

        /// <summary>
        /// BaseDef stat of the Lightcone
        /// </summary>
        public int BaseDef { get; set; }

        /// <summary>
        /// Path Id of the Lightcone
        /// </summary>
        public int PathSRId { get; set; }
    }
}
