using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Relics
{
    public interface IRelicRepository
    {
        /// <summary>
        /// Creates a new Relic in the database.
        /// </summary>
        /// <param name="relic">The new Relic to be created.</param>
        /// <returns>The ID of the newly created Relic as an integer.</returns>
        Task<int> CreateRelic(Relic relic);

        /// <summary>
        /// Gets all Relics in the database.
        /// </summary>
        /// <returns>An IEnumerable of Relic objects.</returns>
        Task<IEnumerable<Relic>> GetAllRelics();

        /// <summary>
        /// Gets a Relic from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the Relic to get.</param>
        /// <returns>A nullable Relic object.</returns>
        Task<Relic?> GetRelicById(int id);

        /// <summary>
        /// Gets a Relic from the database by name.
        /// </summary>
        /// <param name="name">The name of the Relic to get.</param>
        /// <returns>A nullable Relic object.</returns>
        Task<Relic?> GetRelicByName(string name);

        /// <summary>
        /// Updates a Relic in the database.
        /// </summary>
        /// <param name="id">The ID of the Relic to update.</param>
        /// <param name="relic">The updated Relic object.</param>
        /// <returns>
        ///     true: If the update was successful.
        ///     false: If the update was unsuccessful.
        /// </returns>
        Task<bool> UpdateRelic(int id, Relic relic);

        /// <summary>
        /// Soft deletes a Relic in the database.
        /// </summary>
        /// <param name="id">The ID of the Relic to be deleted.</param>
        /// <returns>
        ///     true: If the soft delete was successful.
        ///     false: If the soft delete was unsuccessful.
        /// </returns>
        Task<bool> DeleteRelic(int id);
    }
}
