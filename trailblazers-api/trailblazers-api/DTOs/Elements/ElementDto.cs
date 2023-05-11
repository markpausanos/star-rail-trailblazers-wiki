namespace trailblazers_api.DTOs.Elements
{
    /// <summary>
    /// Element DTO class
    /// </summary>
    public class ElementDto
    {
        /// <summary>
        /// Id of the Element
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the Element
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Directory path of the Element image
        /// </summary>
        public string? Image { get; set; }
    }
}
