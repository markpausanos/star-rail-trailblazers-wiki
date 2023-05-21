using trailblazers_api.Dtos.Trailblazers;

namespace trailblazers_api.Services.Trailblazers
{
    public interface ITrailblazerService
    {
        /// <summary>
        /// Creates a new Trailblazer.
        /// </summary>
        /// <param name="newTrailblazer">The Trailblazer object to create.</param>
        /// <returns>The created Trailblazer, or null if the creation fails.</returns>
        Task<TrailblazerDto?> CreateTrailblazer(TrailblazerCreationDto newTrailblazer);

        /// <summary>
        /// Gets all Trailblazers.
        /// </summary>
        /// <returns>An IEnumerable collection of all Trailblazers.</returns>
        Task<IEnumerable<TrailblazerDto>> GetAllTrailblazers();

        /// <summary>
        /// Gets a Trailblazer by its Id.
        /// </summary>
        /// <param name="id">The Id of the Trailblazer to retrieve.</param>
        /// <returns>The Trailblazer with the specified Id, or null if not found.</returns>
        Task<TrailblazerDto?> GetTrailblazerById(int id);

        /// <summary>
        /// Updates a Trailblazer.
        /// </summary>
        /// <param name="id">The Id of the Trailblazer to update.</param>
        /// <param name="updatedTrailblazer">The updated Trailblazer object.</param>
        /// <returns>A boolean value indicating whether the operation was successful.</returns>
        Task<bool> UpdateTrailblazer(int id, TrailblazerUpdateDto updatedTrailblazer);
    }
}
