using trailblazers_api.Dtos.Lightcones;

namespace trailblazers_api.Services.Lightcones
{
    public interface ILightconeService
    {
        /// <summary>
        /// Creates a new Lightcone in the database.
        /// </summary>
        /// <param name="lightcone">The Lightcone to be created.</param>
        /// <returns>The ID of the newly created Lightcone.</returns>
        Task<LightconeDto?> CreateLightcone(LightconeCreationDto lightcone);

        /// <summary>
        /// Gets all Lightcones in the database.
        /// </summary>
        /// <returns>An IEnumerable of Lightcones.</returns>
        Task<IEnumerable<LightconeDto>> GetAllLightcones();

        /// <summary>
        /// Gets a Lightcone from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to retrieve.</param>
        /// <returns>The Lightcone with the specified ID, or null if it does not exist.</returns>
        Task<LightconeDto?> GetLightconeById(int id);

        /// <summary>
        /// Gets a Lightcone from the database by its name.
        /// </summary>
        /// <param name="name">The name of the Lightcone to retrieve.</param>
        /// <returns>The Lightcone with the specified name, or null if it does not exist.</returns>
        Task<LightconeDto?> GetLightconeByName(string name);

        /// <summary>
        /// Updates an existing Lightcone in the database.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to update.</param>
        /// <param name="lightcone">The updated Lightcone data.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateLightcone(int id, LightconeUpdateDto lightcone);

        /// <summary>
        /// Deletes a Lightcone from the database.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to be deleted.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteLightcone(int id);
    }
}
