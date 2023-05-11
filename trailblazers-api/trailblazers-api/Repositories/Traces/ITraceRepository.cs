using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Traces
{
    public interface ITraceRepository
    {
        /// <summary>
        /// Creates a new Trace in the database.
        /// </summary>
        /// <param name="trace">The Trace to be created.</param>
        /// <returns>The ID of the newly created Trace.</returns>
        Task<int> CreateTrace(Trace trace);

        /// <summary>
        /// Gets all Traces in the database.
        /// </summary>
        /// <returns>An IEnumerable of Trace objects.</returns>
        Task<IEnumerable<Trace>> GetAllTrace();

        /// <summary>
        /// Gets a Trace from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the Trace to retrieve.</param>
        /// <returns>The Trace object with the specified ID, or null if not found.</returns>
        Task<Trace?> GetTraceById(int id);

        /// <summary>
        /// Gets a Trace from the database by name.
        /// </summary>
        /// <param name="name">The name of the Trace to retrieve.</param>
        /// <returns>The Trace object with the specified name, or null if not found.</returns>
        Task<Trace?> GetTraceByName(string name);

        /// <summary>
        /// Updates a Trace in the database.
        /// </summary>
        /// <param name="trace">The updated Trace object.</param>
        /// <returns>
        ///     true: if the update was successful.
        ///     false: if the update was unsuccessful.
        /// </returns>
        Task<bool> UpdateTrace(Trace trace);

        /// <summary>
        /// Deletes a Trace from the database.
        /// </summary>
        /// <param name="id">The ID of the Trace to delete.</param>
        /// <returns>
        ///     true: if the delete was successful.
        ///     false: if the delete was unsuccessful.
        /// </returns>
        Task<bool> DeleteTrace(int id);
    }
}
