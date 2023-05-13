namespace trailblazers_api.DTOs.Skills
{
    /// <summary>
    /// Skill DTO class
    /// </summary>
    public class SkillDto
    {
        /// <summary>
        /// Id of the Skill
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title of the Skill
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Name of the Skill
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description of the Skill
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Image of the Skill
        /// </summary>
        public string? Image { get; set; }

        /// <summary>
        /// Type of the Skill
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// Id of Trailblazer of the Skill
        /// </summary>
        public int TrailblazerId { get; set; }
    }
}
