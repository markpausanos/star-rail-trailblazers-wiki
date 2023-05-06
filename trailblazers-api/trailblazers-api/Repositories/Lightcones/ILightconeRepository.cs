using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Lightcones
{
    public interface ILightconeRepository
    {
        /// <summary>
        /// Creates a new Lightcone in the database.
        /// </summary>
        /// <param name="lightcone">The Lightcone to be created.</param>
        /// <returns>The ID of the newly created Lightcone.</returns>
        Task<int> CreateLightcone(Lightcone lightcone);

        /// <summary>
        /// Gets all Lightcones in the database.
        /// </summary>
        /// <returns>An IEnumerable of Lightcones.</returns>
        Task<IEnumerable<Lightcone>> GetAllLightcones();

        /// <summary>
        /// Gets a Lightcone from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to retrieve.</param>
        /// <returns>The Lightcone with the specified ID, or null if it does not exist.</returns>
        Task<Lightcone?> GetLightconeById(int id);

        /// <summary>
        /// Gets a Lightcone from the database by its name.
        /// </summary>
        /// <param name="name">The name of the Lightcone to retrieve.</param>
        /// <returns>The Lightcone with the specified name, or null if it does not exist.</returns>
        Task<Lightcone?> GetLightconeByName(string name);

        /// <summary>
        /// Updates an existing Lightcone in the database.
        /// </summary>
        /// <param name="lightcone">The Lightcone to be updated.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateLightcone(Lightcone lightcone);

        /// <summary>
        /// Deletes a Lightcone from the database.
        /// </summary>
        /// <param name="id">The ID of the Lightcone to be deleted.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteLightcone(int id);
    }
}
