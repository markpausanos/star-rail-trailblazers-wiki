using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Eidolons
{
    public interface IEidolonRepository
    {
        /// <summary>
        /// Create a new Eidolon in the Database.
        /// </summary>
        /// <param name="eidolon">New Eidolon to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Eidolon</returns>
        Task<int> CreateEidolon(Eidolon eidolon);
        /// <summary>
        /// Gets all Eidolon in the databse.
        /// </summary>
        /// <returns><IEnumerable<Eidolon>></returns>
        Task<IEnumerable<Eidolon>> GetAllEidolons();
        /// <summary>
        /// Gets Eidolon in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Eidolon to get in the database.</param>
        /// <returns>A nullable Eidolon</returns>
        Task<Eidolon?> GetEidolonById(int id);
        /// <summary>
        /// Gets a Eidolon in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Eidolon to get.</param>
        /// <returns>A nullable Eidolon</returns>
        Task<Eidolon?> GetEidolonByName(string name);
        /// <summary>
        /// Updates a Eidolon in the database.
        /// </summary>
        /// <param name="eidolon">Updated Eidolon</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateEidolon(Eidolon eidolon);
        /// <summary>
        /// Deletes a Eidolon in the database.
        /// </summary>
        /// <param name="id">Id of the Eidolon to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteEidolon(int id);
    }
}
