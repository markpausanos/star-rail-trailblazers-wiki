using trailblazers_api.Dtos.Eidolons;

namespace trailblazers_api.Services.Eidolons
{
    public interface IEidolonService
    {
        /// <summary>
        /// Creates a new Eidolon in the database.
        /// </summary>
        /// <param name="eidolon">The Eidolon to be created.</param>
        /// <returns>The Id of the newly created Eidolon.</returns>
        Task<int> CreateEidolon(EidolonCreationDto eidolon);

        /// <summary>
        /// Gets all Eidolons in the database associated with a specific trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the trailblazer to filter Eidolons by.</param>
        /// <returns>An asynchronous operation that yields an IEnumerable of Eidolon objects.</returns>
        Task<IEnumerable<EidolonDto>> GetAllEidolonsByTrailblazerId(int trailblazerId);

        /// <summary>
        /// Updates an Eidolon in the database.
        /// </summary>
        /// <param name="eidolon">The updated Eidolon object.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateEidolon(EidolonUpdateDto eidolon);

        /// <summary>
        /// Deletes an Eidolon from the database.
        /// </summary>
        /// <param name="id">The Id of the Eidolon to delete.</param>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        Task<bool> DeleteEidolon(int id);
    }
}
