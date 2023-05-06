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
        /// Gets a Post in the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the Post to retrieve.</param>
        /// <returns>A nullable Post object.</returns>
        Task<Post?> GetPostById(int id);

        /// <summary>
        /// Gets a Post in the database by its name.
        /// </summary>
        /// <param name="name">The name of the Post to retrieve.</param>
        /// <returns>A nullable Post object.</returns>
        Task<Post?> GetPostByName(string name);

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
