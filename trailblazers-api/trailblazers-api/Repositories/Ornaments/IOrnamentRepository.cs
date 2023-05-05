using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Ornaments
{
    public interface IOrnamentRepository
    {
        /// <summary>
        /// Create a new Ornament in the Database.
        /// </summary>
        /// <param name="ornament">New Ornament to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Ornament</returns>
        Task<int> CreateOrnament(Ornament ornament);
        /// <summary>
        /// Gets all Ornament in the databse.
        /// </summary>
        /// <returns><IEnumerable<Ornament>></returns>
        Task<IEnumerable<Ornament>> GetAllOrnaments();
        /// <summary>
        /// Gets Ornament in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Ornament to get in the database.</param>
        /// <returns>A nullable Ornament</returns>
        Task<Ornament?> GetOrnamentById(int id);
        /// <summary>
        /// Gets a Ornament in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Ornament to get.</param>
        /// <returns>A nullable Ornament</returns>
        Task<Ornament?> GetOrnamentByName(string name);
        /// <summary>
        /// Updates a Ornament in the database.
        /// </summary>
        /// <param name="ornament">Updated Ornament</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateOrnament(Ornament ornament);
        /// <summary>
        /// Deletes a Ornament in the database.
        /// </summary>
        /// <param name="id">Id of the Ornament to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteOrnament(int id);
    }
}
