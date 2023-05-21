namespace trailblazers_api.Repositories.Builds
{
    public interface IBuildLikeRepository
    {
        /// <summary>
        /// Gets the total number of likes for a specific build.
        /// </summary>
        /// <param name="buildId">The ID of the build.</param>
        /// <returns>An integer representing the total number of likes.</returns>
        Task<int> GetTotalLikesByBuild(int buildId);

        /// <summary>
        /// Gets the build IDs liked by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An enumerable collection of build IDs.</returns>
        Task<IEnumerable<int>> GetLikesByUser(int userId);

        /// <summary>
        /// Adds a like to a build by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="buildId">The ID of the build.</param>
        /// <returns>A boolean value indicating whether the like was added successfully.</returns>
        Task<bool> AddLike(int userId, int buildId);

        /// <summary>
        /// Removes a like from a build by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="buildId">The ID of the build.</param>
        /// <returns>A boolean value indicating whether the like was removed successfully.</returns>
        Task<bool> RemoveLike(int userId, int buildId);

        /// <summary>
        /// Checks if a build is liked by a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="buildId">The ID of the build.</param>
        /// <returns>A boolean value indicating whether the build is liked by the user.</returns>
        Task<bool> IsLikedByUser(int userId, int buildId);
    }
}
