using trailblazers_api.Dtos.Users;
using trailblazers_api.Models;

namespace trailblazers_api.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user based on their name and password.
        /// </summary>
        /// <param name="userDto">The user credentials.</param>
        /// <returns>The authenticated user.</returns>
        Task<UserCreationLoginDto?> Authenticate(UserCreationLoginDto userDto);

        /// <summary>
        /// Generates a JWT token for the given user.
        /// </summary>
        /// <param name="userDto">The user to generate a token for.</param>
        /// <returns>The generated token.</returns>
        Task<string?> GenerateToken(UserCreationLoginDto userDto);

        /// <summary>
        /// Creates a new user with the given details.
        /// </summary>
        /// <param name="userDto">The user details.</param>
        /// <returns>The generated JWT token for the new user.</returns>
        Task<string?> CreateUser(UserCreationLoginDto userDto);

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the given ID, or null if not found.</returns>
        Task<User?> GetUserById(int id);

        /// <summary>
        /// Updates a user with the given ID and details.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userUpdateDto">The new details for the user.</param>
        /// <returns>The updated user.</returns>
        Task<bool> UpdateUserById(int id, UserUpdateDto userUpdateDto);

        /// <summary>
        /// Deletes a user with the given ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the user was deleted, false otherwise.</returns>
        Task<bool> DeleteUserById(int id);
    }
}