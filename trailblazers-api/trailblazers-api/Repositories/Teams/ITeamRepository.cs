using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Teams
{
    public interface ITeamRepository
    {
        /// <summary>
        /// Create a new Team in the Database.
        /// </summary>
        /// <param name="team">New Team to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Team</returns>
        Task<int> CreateTeam(Team team);
        /// <summary>
        /// Gets all Team in the databse.
        /// </summary>
        /// <returns><IEnumerable<Team>></returns>
        Task<IEnumerable<Team>> GetAllTeams();
        /// <summary>
        /// Gets Team in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Team to get in the database.</param>
        /// <returns>A nullable Team</returns>
        Task<Team?> GetTeamById(int id);
        /// <summary>
        /// Gets a Team in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Team to get.</param>
        /// <returns>A nullable Team</returns>
        Task<Team?> GetTeamByName(string name);
        /// <summary>
        /// Updates a Team in the database.
        /// </summary>
        /// <param name="team">Updated Team</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateTeam(Team team);
        /// <summary>
        /// Deletes a Team in the database.
        /// </summary>
        /// <param name="id">Id of the Team to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteTeam(int id);
    }
}
