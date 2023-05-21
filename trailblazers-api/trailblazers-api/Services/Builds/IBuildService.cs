using trailblazers_api.Dtos.Builds;

namespace trailblazers_api.Services.Builds
{
    public interface IBuildService
    {
        /// <summary>
        /// Creates a new build.
        /// </summary>
        /// <param name="newBuild">The build creation data.</param>
        /// <returns>The created build, or null if creation fails.</returns>
        Task<BuildDto?> CreateBuild(BuildCreationDto newBuild);

        /// <summary>
        /// Retrieves all builds for a specific user.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <returns>An enumerable collection of build DTOs.</returns>
        Task<IEnumerable<BuildDto>> GetAllBuilds(int userID);

        /// <summary>
        /// Adds a like to a build.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="buildId">The ID of the build.</param>
        /// <returns>True if the like is added successfully, otherwise false.</returns>
        Task<bool> AddLike(int userId, int buildId);

        /// <summary>
        /// Removes a like from a build.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="buildId">The ID of the build.</param>
        /// <returns>True if the like is removed successfully, otherwise false.</returns>
        Task<bool> RemoveLike(int userId, int buildId);

        /// <summary>
        /// Retrieves a build by its ID.
        /// </summary>
        /// <param name="id">The ID of the build.</param>
        /// <returns>The build DTO if found, otherwise null.</returns>
        Task<BuildDto?> GetBuildById(int id);

        /// <summary>
        /// Updates a build.
        /// </summary>
        /// <param name="id">The ID of the build to update.</param>
        /// <param name="build">The updated build data.</param>
        /// <returns>True if the build is updated successfully, otherwise false.</returns>
        Task<bool> UpdateBuild(int id, BuildUpdateDto build);

        /// <summary>
        /// Deletes a build.
        /// </summary>
        /// <param name="id">The ID of the build to delete.</param>
        /// <returns>True if the build is deleted successfully, otherwise false.</returns>
        Task<bool> DeleteBuild(int id);
    }
}
