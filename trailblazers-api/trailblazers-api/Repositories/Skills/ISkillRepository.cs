using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Skills
{
    public interface ISkillRepository
    {
        /// <summary>
        /// Creates a new Skill in the database.
        /// </summary>
        /// <param name="skill">The new Skill to create.</param>
        /// <returns>The ID of the newly created Skill.</returns>
        Task<int> CreateSkill(Skill skill);

        /// <summary>
        /// Gets all Skills in the database.
        /// </summary>
        /// <returns>An enumerable collection of Skills.</returns>
        Task<IEnumerable<Skill>> GetAllSkills();

        /// <summary>
        /// Gets a Skill in the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the Skill to retrieve.</param>
        /// <returns>A nullable Skill object.</returns>
        Task<Skill?> GetSkillById(int id);

        /// <summary>
        /// Gets a Skill in the database by its name.
        /// </summary>
        /// <param name="name">The name of the Skill to retrieve.</param>
        /// <returns>A nullable Skill object.</returns>
        Task<Skill?> GetSkillByName(string name);

        /// <summary>
        /// Updates a Skill in the database.
        /// </summary>
        /// <param name="skill">The updated Skill object.</param>
        /// <returns>
        /// true if the update was successful; otherwise, false.
        /// </returns>
        Task<bool> UpdateSkill(Skill skill);

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
