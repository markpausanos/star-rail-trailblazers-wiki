using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Paths
{
    public interface IPathSRRepository
    {
        /// <summary>
        /// Create a new PathSR in the Database.
        /// </summary>
        /// <param name="path">New PathSR to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created PathSR</returns>
        Task<int> CreatePathSR(PathSR path);
        /// <summary>
        /// Gets all PathSR in the databse.
        /// </summary>
        /// <returns><IEnumerable<PathSR>></returns>
        Task<IEnumerable<PathSR>> GetAllPathSRs();
        /// <summary>
        /// Gets PathSR in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the PathSR to get in the database.</param>
        /// <returns>A nullable PathSR</returns>
        Task<PathSR?> GetPathSRById(int id);
        /// <summary>
        /// Gets a PathSR in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the PathSR to get.</param>
        /// <returns>A nullable PathSR</returns>
        Task<PathSR?> GetPathSRByName(string name);
        /// <summary>
        /// Updates a PathSR in the database.
        /// </summary>
        /// <param name="path">Updated PathSR</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdatePathSR(PathSR path);
        /// <summary>
        /// Deletes a PathSR in the database.
        /// </summary>
        /// <param name="id">Id of the PathSR to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeletePathSR(int id);
    }
}
