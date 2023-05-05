using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Relics
{
    public interface IRelicRepository
    {
        /// <summary>
        /// Create a new Relic in the Database.
        /// </summary>
        /// <param name="relic">New Relic to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Relic</returns>
        Task<int> CreateRelic(Relic relic);
        /// <summary>
        /// Gets all Relic in the databse.
        /// </summary>
        /// <returns><IEnumerable<Relic>></returns>
        Task<IEnumerable<Relic>> GetAllRelics();
        /// <summary>
        /// Gets Relic in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Relic to get in the database.</param>
        /// <returns>A nullable Relic</returns>
        Task<Relic?> GetRelicById(int id);
        /// <summary>
        /// Gets a Relic in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Relic to get.</param>
        /// <returns>A nullable Relic</returns>
        Task<Relic?> GetRelicByName(string name);
        /// <summary>
        /// Updates a Relic in the database.
        /// </summary>
        /// <param name="relic">Updated Relic</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateRelic(Relic relic);
        /// <summary>
        /// Deletes a Relic in the database.
        /// </summary>
        /// <param name="id">Id of the Relic to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteRelic(int id);
    }
}
