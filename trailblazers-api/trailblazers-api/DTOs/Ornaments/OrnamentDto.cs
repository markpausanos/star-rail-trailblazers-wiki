namespace trailblazers_api.DTOs.Ornaments
{
    /// <summary>
    /// Ornament DTO class
    /// </summary>
    public class OrnamentDto
    {
        /// <summary>
        /// Id of the Ornament
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Ornament
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Ornament
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Directory path of the Ornament image
        /// </summary>
        public string? Image { get; set; }
    }
}
