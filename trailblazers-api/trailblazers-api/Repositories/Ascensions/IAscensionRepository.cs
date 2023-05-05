using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Ascensions
{
    public interface IAscensionRepository
    {
        /// <summary>
        /// Create a new Ascension in the Database.
        /// </summary>
        /// <param name="ascension">New Ascension to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Ascension</returns>
        Task<int> CreateAscension(Ascension ascension);
        /// <summary>
        /// Gets all Ascension in the databse.
        /// </summary>
        /// <returns><IEnumerable<Ascension>></returns>
        Task<IEnumerable<Ascension>> GetAllAscensions();
        /// <summary>
        /// Gets Ascension in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Ascension to get in the database.</param>
        /// <returns>A nullable Ascension</returns>
        Task<Ascension?> GetAscensionById(int id);
        /// <summary>
        /// Gets a Ascension in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Ascension to get.</param>
        /// <returns>A nullable Ascension</returns>
        Task<Ascension?> GetAscensionByName(string name);
        /// <summary>
        /// Updates a Ascension in the database.
        /// </summary>
        /// <param name="ascension">Updated Ascension</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateAscension(Ascension ascension);
        /// <summary>
        /// Deletes a Ascension in the database.
        /// </summary>
        /// <param name="id">Id of the Ascension to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteAscension(int id);
    }
}
