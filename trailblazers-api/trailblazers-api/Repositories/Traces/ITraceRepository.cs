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
        /// Gets all traces from the database for a given Trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the Trailblazer to retrieve traces for.</param>
        /// <returns>An enumerable collection of Trace objects for the specified Trailblazer ID.</returns>
        Task<IEnumerable<Trace>> GetTraceByTrailblazerId(int trailblazerId);

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
