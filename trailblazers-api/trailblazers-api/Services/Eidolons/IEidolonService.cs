using trailblazers_api.Dtos.Eidolons;

namespace trailblazers_api.Services.Eidolons
{
    public interface IEidolonService
    {
        /// <summary>
        /// Creates a new Eidolon.
        /// </summary>
        /// <param name="eidolon">The Eidolon creation data.</param>
        /// <returns>The created Eidolon, or null if creation fails.</returns>
        Task<EidolonDto?> CreateEidolon(EidolonCreationDto eidolon);

        /// <summary>
        /// Retrieves all Eidolons in the database.
        /// </summary>
        /// <returns>An enumerable collection of Eidolon DTOs.</returns>
        Task<IEnumerable<EidolonDto>> GetAllEidolons();

        /// <summary>
        /// Gets all Eidolons in the database associated with a specific trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the trailblazer to filter Eidolons by.</param>
        /// <returns>An enumerable collection of Eidolon DTOs.</returns>
        Task<IEnumerable<EidolonDto>> GetEidolonsByTrailblazerId(int trailblazerId);

        /// <summary>
        /// Retrieves an Eidolon by its ID.
        /// </summary>
        /// <param name="id">The ID of the Eidolon to retrieve.</param>
        /// <returns>The retrieved Eidolon, or null if not found.</returns>
        Task<EidolonDto?> GetEidolonById(int id);

        /// <summary>
        /// Updates an Eidolon in the database.
        /// </summary>
        /// <param name="id">The ID of the Eidolon to update.</param>
        /// <param name="eidolon">The updated Eidolon data.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateEidolon(int id, EidolonUpdateDto eidolon);

        /// <summary>
        /// Deletes an Eidolon from the database.
        /// </summary>
        /// <param name="id">The ID of the Eidolon to delete.</param>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        Task<bool> DeleteEidolon(int id);
    }
}
