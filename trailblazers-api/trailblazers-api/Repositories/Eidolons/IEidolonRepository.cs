using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Eidolons
{
    /// <summary>
    /// Provides methods to interact with the Eidolons table in the database.
    /// </summary>
    public interface IEidolonRepository
    {
        /// <summary>
        /// Creates a new Eidolon in the database.
        /// </summary>
        /// <param name="eidolon">The Eidolon to be created.</param>
        /// <returns>The Id of the newly created Eidolon.</returns>
        Task<int> CreateEidolon(Eidolon eidolon);

        /// <summary>
        /// Gets all Eidolons in the database.
        /// </summary>
        /// <returns>An IEnumerable of Eidolon objects.</returns>
        Task<IEnumerable<Eidolon>> GetAllEidolons();

        /// <summary>
        /// Gets an Eidolon from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Eidolon to retrieve.</param>
        /// <returns>A nullable Eidolon object.</returns>
        Task<Eidolon?> GetEidolonById(int id);

        /// <summary>
        /// Gets an Eidolon from the database by its name.
        /// </summary>
        /// <param name="name">The name of the Eidolon to retrieve.</param>
        /// <returns>A nullable Eidolon object.</returns>
        Task<Eidolon?> GetEidolonByName(string name);

        /// <summary>
        /// Updates an Eidolon in the database.
        /// </summary>
        /// <param name="eidolon">The updated Eidolon object.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateEidolon(Eidolon eidolon);

        /// <summary>
        /// Deletes an Eidolon from the database.
        /// </summary>
        /// <param name="id">The Id of the Eidolon to delete.</param>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        Task<bool> DeleteEidolon(int id);
    }
}
