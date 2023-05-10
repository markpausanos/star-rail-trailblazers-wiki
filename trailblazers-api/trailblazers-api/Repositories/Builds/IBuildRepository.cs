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
        /// Gets Build in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Build to get in the database.</param>
        /// <returns>A nullable Build</returns>
        Task<Build?> GetBuildById(int id);
    }
}
