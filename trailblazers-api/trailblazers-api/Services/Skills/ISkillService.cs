using trailblazers_api.DTOs.Skills;

namespace trailblazers_api.Services.Skills
{
    public interface ISkillService
    {
        /// <summary>
        /// Creates a new Skill in the database.
        /// </summary>
        /// <param name="skill">The new Skill to create.</param>
        /// <returns>The ID of the newly created Skill.</returns>
        Task<int> CreateSkill(SkillCreationDto skill);

        /// <summary>
        /// Gets all Skills in the database.
        /// </summary>
        /// <returns>An enumerable collection of Skills.</returns>
        Task<IEnumerable<SkillDto>> GetAllSkills();

        /// <summary>
        /// Gets all Skills in the database associated with a Trailblazer.
        /// </summary>
        /// <param name="trailblazerId">The ID of the Trailblazer whose Skills to retrieve.</param>
        /// <returns>An IEnumerable of Skill objects or an empty collection if no Skills are found.</returns>
        Task<IEnumerable<SkillDto>> GetSkillsByTrailblazerId(int trailblazerId);

        /// <summary>
        /// Gets Skill in the database with the provided ID.
        /// </summary>
        /// <param name="id">The ID of the Skill</param>
        /// <returns>The retreived Skill</returns>
        Task<SkillDto> GetSkillById(int id);

        /// <summary>
        /// Updates a Skill in the database.
        /// </summary>
        /// <param name="skill">The updated Skill object.</param>
        /// <returns>
        /// true if the update was successful; otherwise, false.
        /// </returns>
        Task<bool> UpdateSkill(SkillUpdateDto skill);

        /// <summary>
        /// Deletes a Skill from the database.
        /// </summary>
        /// <param name="id">The ID of the Skill to delete.</param>
        /// <returns>
        /// true if the delete was successful; otherwise, false.
        /// </returns>
        Task<bool> DeleteSkill(int id);
    }
}
