namespace trailblazers_api.DTOs.Paths
{
    /// <summary>
    /// Path DTO class
    /// </summary>
    public class PathSRDto
    {
        /// <summary>
        /// Id of the Path
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the Path
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Directory path of the Path image
        /// </summary>
        public string? Image { get; set; }
    }
}
