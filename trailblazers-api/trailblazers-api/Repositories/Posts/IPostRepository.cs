using System.Collections.Generic;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Posts
{
    public interface IPostRepository
    {
        /// <summary>
        /// Creates a new Post in the database.
        /// </summary>
        /// <param name="post">The new Post to create.</param>
        /// <returns>The ID of the newly created Post.</returns>
        Task<int> CreatePost(Post post);

        /// <summary>
        /// Gets all Posts in the database.
        /// </summary>
        /// <returns>An enumerable collection of Posts.</returns>
        Task<IEnumerable<Post>> GetAllPosts();

        /// <summary>
        /// Gets all Posts in the database by userID.
        /// </summary>
        /// <param name="userId">The ID of the User whose Posts to retrieve.</param>
        /// <returns>An IEnumerable of Post objects or an empty collection if no Posts are found.</returns>
        Task<IEnumerable<Post>> GetPostsByUserId(int userId);

        /// <summary>
        /// Updates a Post in the database.
        /// </summary>
        /// <param name="post">The updated Post object.</param>
        /// <returns>
        /// true if the update was successful; otherwise, false.
        /// </returns>
        Task<bool> UpdatePost(Post post);

        /// <summary>
        /// Deletes a Post from the database.
        /// </summary>
        /// <param name="id">The ID of the Post to delete.</param>
        /// <returns>
        /// true if the delete was successful; otherwise, false.
        /// </returns>
        Task<bool> DeletePost(int id);
    }
}
