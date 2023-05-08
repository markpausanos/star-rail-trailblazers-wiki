using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Teams
{
    public interface ITeamRepository
    {
        /// <summary>
        /// Creates a new Team in the database.
        /// </summary>
        /// <param name="team">The Team object to be created.</param>
        /// <returns>The Id of the newly created Team.</returns>
        Task<int> CreateTeam(Team team);

        /// <summary>
        /// Retrieves all Teams in the database.
        /// </summary>
        /// <returns>An IEnumerable of all Teams.</returns>
        Task<IEnumerable<Team>> GetAllTeams();

        /// <summary>
        /// Retrieves a Team from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Team to retrieve.</param>
        /// <returns>A nullable Team object.</returns>

        Task<IEnumerable<Team>> GetAllTeamsByUserId(int id);
        /// <summary>
        /// Updates a Team in the database.
        /// </summary>
        /// <param name="team">The updated Team object.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>

        Task<bool> UpdateTeam(Team team);

        /// <summary>
        /// Deletes a Team from the database.
        /// </summary>
        /// <param name="id">The Id of the Team to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteTeam(int id);
    }
}
