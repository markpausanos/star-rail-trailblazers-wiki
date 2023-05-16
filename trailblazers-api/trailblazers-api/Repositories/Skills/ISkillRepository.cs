using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Skills
{
    public interface ISkillRepository
    {
        /// <summary>
        /// Creates a new skill in the database.
        /// </summary>
        /// <param name="skill">The new skill to create.</param>
        /// <returns>The ID of the newly created skill.</returns>
        Task<int> CreateSkill(Skill skill);

        /// <summary>
        /// Gets all skills in the database.
        /// </summary>
        /// <returns>An enumerable collection of skills.</returns>
        Task<IEnumerable<Skill>> GetAllSkills();

        /// <summary>
        /// Gets all skills in the database associated with a trailblazer.
        /// </summary>
        /// <param name="trailblazerId">The ID of the trailblazer whose skills to retrieve.</param>
        /// <returns>An enumerable collection of skill objects or an empty collection if no skills are found.</returns>
        Task<IEnumerable<Skill>> GetSkillsByTrailblazerId(int trailblazerId);

        /// <summary>
        /// Gets a skill in the database with the provided ID.
        /// </summary>
        /// <param name="id">The ID of the skill.</param>
        /// <returns>The retrieved skill.</returns>
        Task<Skill?> GetSkillById(int id);

        /// <summary>
        /// Updates a skill in the database.
        /// </summary>
        /// <param name="id">The ID of the skill to update.</param>
        /// <param name="skill">The updated skill object.</param>
        /// <returns>true if the update was successful; otherwise, false.</returns>
        Task<bool> UpdateSkill(int id, Skill skill);

        /// <summary>
        /// Deletes a skill from the database.
        /// </summary>
        /// <param name="id">The ID of the skill to delete.</param>
        /// <returns>true if the delete was successful; otherwise, false.</returns>
        Task<bool> DeleteSkill(int id);
    }
}
