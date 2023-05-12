namespace trailblazers_api.DTOs.Eidolons
{
    /// <summary>
    /// Element DTO class
    /// </summary>
    public class EidolonDto
    {
        /// <summary>
        /// Id of the Eidolon
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Eidolon
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Eidolon
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Directory path of the Eidolon image
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Order of the Eidolon
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Id of the Eidolon's Trailblazer
        /// </summary>
        public int TrailblazerId { get; set; }
    }
}
