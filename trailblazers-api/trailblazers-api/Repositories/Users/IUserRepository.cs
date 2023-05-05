using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Users
{
    public interface IUserRepository
    {
        /// <summary>
        /// Create a new User in the Database.
        /// </summary>
        /// <param name="user">New User to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created User</returns>
        Task<int> CreateUser(User user);
        /// <summary>
        /// Gets all User in the databse.
        /// </summary>
        /// <returns><IEnumerable<User>></returns>
        Task<IEnumerable<User>> GetAllUsers();
        /// <summary>
        /// Gets User in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the User to get in the database.</param>
        /// <returns>A nullable User</returns>
        Task<User?> GetUserById(int id);
        /// <summary>
        /// Gets a User in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the User to get.</param>
        /// <returns>A nullable User</returns>
        Task<User?> GetUserByName(string name);
        /// <summary>
        /// Updates a User in the database.
        /// </summary>
        /// <param name="user">Updated User</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateUser(User user);
        /// <summary>
        /// Deletes a User in the database.
        /// </summary>
        /// <param name="id">Id of the User to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteUser(int id);
    }
}
