using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Builds
{
    public interface IBuildRepository
    {
        /// <summary>
        /// Creates a new Build in the database.
        /// </summary>
        /// <param name="build">The new Build to be created.</param>
        /// <returns>An integer representing the Id of the newly created Build.</returns>
        Task<int> CreateBuild(Build build);

        /// <summary>
        /// Retrieves all Builds from the database.
        /// </summary>
        /// <returns>An enumerable collection of Build objects.</returns>
        Task<IEnumerable<Build>> GetAllBuilds();

        /// <summary>
        /// Retrieves a Build from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Build to retrieve.</param>
        /// <returns>A nullable Build object.</returns>
        Task<Build?> GetBuildById(int id);

        /// <summary>
        /// Updates a Build in the database.
        /// </summary>
        /// <param name="build">The Build object to update.</param>
        /// <returns>A boolean indicating whether the update operation was successful.</returns>
        Task<bool> UpdateBuild(Build build);

        /// <summary>
        /// Deletes a Build from the database.
        /// </summary>
        /// <param name="id">The Id of the Build to delete.</param>
        /// <returns>A boolean indicating whether the delete operation was successful.</returns>
        Task<bool> DeleteBuild(int id);
    }
}
