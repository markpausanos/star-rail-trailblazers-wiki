using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Paths
{
    public interface IPathSRRepository
    {
        /// <summary>
        /// Creates a new PathSR in the database.
        /// </summary>
        /// <param name="path">The new PathSR to create.</param>
        /// <returns>The ID of the newly created PathSR.</returns>
        Task<int> CreatePathSR(PathSR path);

        /// <summary>
        /// Gets all PathSRs in the database.
        /// </summary>
        /// <returns>An enumerable collection of PathSRs.</returns>
        Task<IEnumerable<PathSR>> GetAllPathSRs();

        /// <summary>
        /// Gets a PathSR in the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the PathSR to retrieve.</param>
        /// <returns>A nullable PathSR object.</returns>
        Task<PathSR?> GetPathSRById(int id);

        /// <summary>
        /// Gets a PathSR in the database by its name.
        /// </summary>
        /// <param name="name">The name of the PathSR to retrieve.</param>
        /// <returns>A nullable PathSR object.</returns>
        Task<PathSR?> GetPathSRByName(string name);

        /// <summary>
        /// Updates a PathSR in the database.
        /// </summary>
        /// <param name="path">The updated PathSR object.</param>
        /// <returns>
        /// true if the update was successful; otherwise, false.
        /// </returns>
        Task<bool> UpdatePathSR(PathSR path);

        /// <summary>
        /// Deletes a PathSR from the database.
        /// </summary>
        /// <param name="id">The ID of the PathSR to delete.</param>
        /// <returns>
        /// true if the delete was successful; otherwise, false.
        /// </returns>
        Task<bool> DeletePathSR(int id);
    }
}
