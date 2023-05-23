using trailblazers_api.Dtos.Traces;

namespace trailblazers_api.Services.Traces
{
    public interface ITraceService
    {
        /// <summary>
        /// Creates a new Trace.
        /// </summary>
        /// <param name="trace">The Trace creation data.</param>
        /// <returns>The created Trace, or null if creation fails.</returns>
        Task<TraceDto?> CreateTrace(TraceCreationDto eidolon);

        /// <summary>
        /// Retrieves all Traces in the database.
        /// </summary>
        /// <returns>An enumerable collection of Trace DTOs.</returns>
        Task<IEnumerable<TraceDto>> GetAllTraces();

        /// <summary>
        /// Gets all Traces in the database associated with a specific trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the trailblazer to filter Traces by.</param>
        /// <returns>An enumerable collection of Trace DTOs.</returns>
        Task<IEnumerable<TraceDto>> GetTracesByTrailblazerId(int trailblazerId);

        /// <summary>
        /// Retrieves an Trace by its ID.
        /// </summary>
        /// <param name="id">The ID of the Trace to retrieve.</param>
        /// <returns>The retrieved Trace, or null if not found.</returns>
        Task<TraceDto?> GetTraceById(int id);

        /// <summary>
        /// Updates an Trace in the database.
        /// </summary>
        /// <param name="id">The ID of the Trace to update.</param>
        /// <param name="eidolon">The updated Trace data.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateTrace(int id, TraceUpdateDto eidolon);

        /// <summary>
        /// Deletes an Trace from the database.
        /// </summary>
        /// <param name="id">The ID of the Trace to delete.</param>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        Task<bool> DeleteTrace(int id);
    }
}
