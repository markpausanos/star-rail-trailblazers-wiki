namespace trailblazers_api.Dtos.Builds
{
    /// <summary>
    /// Build DTO class
    /// </summary>
    public class BuildDto
    {
        /// <summary>
        /// Id of the Build
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UserId of the Build
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// TrailblazerId of the Build
        /// </summary>
        public int TrailblazerId { get; set; }

        /// <summary>
        /// LightconeId of the Build
        /// </summary>
        public int LightconeId { get; set; }

        /// <summary>
        /// List of RelicIds in the Build
        /// </summary>
        public List<int> RelicIds { get; set; } = new List<int>();

        /// <summary>
        /// List of OrnamentIds in the Build
        /// </summary>
        public List<int> OrnamentIds { get; set; } = new List<int>();
    }
}
