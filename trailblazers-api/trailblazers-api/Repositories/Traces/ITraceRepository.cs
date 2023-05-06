using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Traces
{
    public interface ITraceRepository
    {
        /// <summary>
        /// Create a new Trace in the Database.
        /// </summary>
        /// <param name="ascension">New Trace to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Trace</returns>
        Task<int> CreateTrace(Trace ascension);
        /// <summary>
        /// Gets all Trace in the databse.
        /// </summary>
        /// <returns><IEnumerable<Trace>></returns>
        Task<IEnumerable<Trace>> GetAllTrace();
        /// <summary>
        /// Gets Trace in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Trace to get in the database.</param>
        /// <returns>A nullable Trace</returns>
        Task<Trace?> GetTraceById(int id);
        /// <summary>
        /// Gets a Trace in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Trace to get.</param>
        /// <returns>A nullable Trace</returns>
        Task<Trace?> GetTraceByName(string name);
        /// <summary>
        /// Updates a Trace in the database.
        /// </summary>
        /// <param name="ascension">Updated Trace</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateTrace(Trace ascension);
        /// <summary>
        /// Deletes a Trace in the database.
        /// </summary>
        /// <param name="id">Id of the Trace to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteTrace(int id);
    }
}
