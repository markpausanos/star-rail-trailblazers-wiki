using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Trailblazers
{
    public interface ITrailblazersRepository
    {
        /// <summary>
        /// Creates a new Trailblazer in the database.
        /// </summary>
        /// <param name="trailblazer">The Trailblazer to create.</param>
        /// <returns>The Id of the newly created Trailblazer.</returns>
        Task<int> CreateTrailblazer(Trailblazer trailblazer);

        /// <summary>
        /// Gets all Trailblazers in the database.
        /// </summary>
        /// <returns>An IEnumerable of all Trailblazers.</returns>
        Task<IEnumerable<Trailblazer>> GetAllTrailblazers();

        /// <summary>
        /// Gets a Trailblazer from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Trailblazer to retrieve.</param>
        /// <returns>The Trailblazer with the specified Id, or null if not found.</returns>
        Task<Trailblazer?> GetTrailblazerById(int id);

        /// <summary>
        /// Gets a Trailblazer from the database by its name.
        /// </summary>
        /// <param name="name">The name of the Trailblazer to retrieve.</param>
        /// <returns>The Trailblazer with the specified name, or null if not found.</returns>
        Task<bool> UpdateTrailblazer(Trailblazer trailblazer);
    }
}
