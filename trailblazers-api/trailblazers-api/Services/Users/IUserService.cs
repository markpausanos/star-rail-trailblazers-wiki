using trailblazers_api.Dtos.Users;

namespace trailblazers_api.Services.Users
{
    public interface IUserService
    {
        /// <summary>
        /// Authenticates a user based on their name and password.
        /// </summary>
        /// <param name="userDto">The user credentials.</param>
        /// <returns>A boolean indicating whether the user is authenticated.</returns>
        Task<bool> Authenticate(UserCreationLoginDto userDto);

        /// <summary>
        /// Generates a JWT token for the given user.
        /// </summary>
        /// <param name="userDto">The user to generate a token for.</param>
        /// <returns>The generated token, or null if the token generation fails.</returns>
        Task<string?> GenerateToken(UserCreationLoginDto userDto);

        /// <summary>
        /// Gets the currently authenticated user.
        /// </summary>
        /// <param name="context">The HTTP context.</param>
        /// <returns>The currently authenticated user, or null if not authenticated.</returns>
        Task<UserAccessDto?> GetCurrentUser(HttpContext context);

        /// <summary>
        /// Creates a new user with the given details.
        /// </summary>
        /// <param name="userDto">The user details.</param>
        /// <returns>The generated JWT token for the new user, or null if user creation fails.</returns>
        Task<string?> CreateUser(UserCreationLoginDto userDto);

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user with the given ID, or null if not found.</returns>
        Task<UserAccessDto?> GetUserById(int id);

        /// <summary>
        /// Retrieves a user by their name.
        /// </summary>
        /// <param name="name">The name of the user to retrieve.</param>
        /// <returns>The user with the given name, or null if not found.</returns>
        Task<UserAccessDto?> GetUserByName(string name);

        /// <summary>
        /// Updates a user with the given details.
        /// </summary>
        /// <param name="userUpdateDto">The new details for the user.</param>
        /// <returns>A boolean indicating whether the user update was successful.</returns>
        Task<bool> UpdateUserByName(UserUpdateDto userUpdateDto);

        /// <summary>
        /// Deletes a user with the given name.
        /// </summary>
        /// <param name="name">The name of the user to delete.</param>
        /// <returns>A boolean indicating whether the user was deleted.</returns>
        Task<bool> DeleteUser(string name);
    }
}
