using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Lightcones
{
    public interface ILightconeRepository
    {
        /// <summary>
        /// Create a new Lightcone in the Database.
        /// </summary>
        /// <param name="lightcone">New Lightcone to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Lightcone</returns>
        Task<int> CreateLightcone(Lightcone lightcone);
        /// <summary>
        /// Gets all Lightcone in the databse.
        /// </summary>
        /// <returns><IEnumerable<Lightcone>></returns>
        Task<IEnumerable<Lightcone>> GetAllLightcones();
        /// <summary>
        /// Gets Lightcone in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Lightcone to get in the database.</param>
        /// <returns>A nullable Lightcone</returns>
        Task<Lightcone?> GetLightconeById(int id);
        /// <summary>
        /// Gets a Lightcone in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Lightcone to get.</param>
        /// <returns>A nullable Lightcone</returns>
        Task<Lightcone?> GetLightconeByName(string name);
        /// <summary>
        /// Updates a Lightcone in the database.
        /// </summary>
        /// <param name="lightcone">Updated Lightcone</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateLightcone(Lightcone lightcone);
        /// <summary>
        /// Deletes a Lightcone in the database.
        /// </summary>
        /// <param name="id">Id of the Lightcone to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteLightcone(int id);
    }
}
