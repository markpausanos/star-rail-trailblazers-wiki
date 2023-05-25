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
        /// Retrieves all Traces in the database.
        /// </summary>
        /// <returns>An enumerable collection of Trace objects.</returns>
        Task<IEnumerable<Trace>> GetAllTraces();

        /// <summary>
        /// Gets all Traces in the database associated with a specific trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the trailblazer to filter Traces by.</param>
        /// <returns>An enumerable collection of Trace objects.</returns>
        Task<IEnumerable<Trace>> GetTracesByTrailblazerId(int trailblazerId);

        /// <summary>
        /// Retrieves an Trace by its ID.
        /// </summary>
        /// <param name="id">The ID of the Trace to retrieve.</param>
        /// <returns>The retrieved Trace, or null if not found.</returns>
        Task<Trace?> GetTraceById(int id);

        /// <summary>
        /// Updates an Trace in the database.
        /// </summary>
        /// <param name="trace">The updated Trace object.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateTrace(Trace trace);

        /// <summary>
        /// Deletes an Trace from the database.
        /// </summary>
        /// <param name="id">The ID of the Trace to delete.</param>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        Task<bool> DeleteTrace(int id);
    }
}
