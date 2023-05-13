namespace trailblazers_api.DTOs.Relics
{
    /// <summary>
    /// Relic DTO class
    /// </summary>
    public class RelicDto
    {
        /// <summary>
        /// Id of the Relic
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Relic
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// DescriptionOne of the Relic
        /// </summary>
        public string? DescriptionOne { get; set; }

        /// <summary>
        /// DescriptionTwo of the Relic
        /// </summary>
        public string? DescriptionTwo { get; set; }

        /// <summary>
        /// Directory path of the Relic image
        /// </summary>
        public string? Image { get; set; }
    }
}
