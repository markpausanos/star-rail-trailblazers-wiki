using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Users
{
    public interface IUserRepository
    {
        /// <summary>
        /// Creates a new user in the database.
        /// </summary>
        /// <param name="user">The user object to be created.</param>
        /// <returns>The ID of the newly created user.</returns>
        Task<int> CreateUser(User user);

        /// <summary>
        /// Gets all users in the database.
        /// </summary>
        /// <returns>An IEnumerable of all users in the database.</returns>
        Task<IEnumerable<User>> GetAllUsers();

        /// <summary>
        /// Gets a user from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user object with the specified ID, or null if not found.</returns>
        Task<User?> GetUserById(int id);

        /// <summary>
        /// Gets a user from the database by name.
        /// </summary>
        /// <param name="name">The name of the user to retrieve.</param>
        /// <returns>The user object with the specified name, or null if not found.</returns>
        Task<User?> GetUserByName(string name);

        /// <summary>
        /// Updates a user in the database.
        /// </summary>
        /// <param name="user">The user object with updated values.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateUser(User user);

        /// <summary>
        /// Deletes a user from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteUser(int id);
    }
}
