using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Builds
{
    public interface IBuildRepository
    {
        /// <summary>
        /// Create a new Build in the Database.
        /// </summary>
        /// <param name="build">New Build to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Build</returns>
        Task<int> CreateBuild(Build build);
        /// <summary>
        /// Gets all Build in the databse.
        /// </summary>
        /// <returns><IEnumerable<Build>></returns>
        Task<IEnumerable<Build>> GetAllBuilds();
        /// <summary>
        /// Gets Build in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Build to get in the database.</param>
        /// <returns>A nullable Build</returns>
        Task<Build?> GetBuildById(int id);
        /// <summary>
        /// Gets a Build in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Build to get.</param>
        /// <returns>A nullable Build</returns>
        Task<Build?> GetBuildByName(string name);
        /// <summary>
        /// Updates a Build in the database.
        /// </summary>
        /// <param name="build">Updated Build</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateBuild(Build build);
        /// <summary>
        /// Deletes a Build in the database.
        /// </summary>
        /// <param name="id">Id of the Build to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteBuild(int id);
    }
}
