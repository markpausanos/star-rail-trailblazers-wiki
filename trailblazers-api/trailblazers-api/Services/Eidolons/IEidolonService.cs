using trailblazers_api.Dtos.Eidolons;

namespace trailblazers_api.Services.Eidolons
{
    public interface IEidolonService
    {
        Task<EidolonDto?> CreateEidolon(EidolonCreationDto eidolon);

        Task<IEnumerable<EidolonDto>> GetAllEidolons();
        /// <summary>
        /// Gets all Eidolons in the database associated with a specific trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">The ID of the trailblazer to filter Eidolons by.</param>
        /// <returns>An asynchronous operation that yields an IEnumerable of Eidolon objects.</returns>
        Task<IEnumerable<EidolonDto>> GetEidolonsByTrailblazerId(int trailblazerId);

        Task<EidolonDto?> GetEidolonById(int id);
        /// <summary>
        /// Updates an Eidolon in the database.
        /// </summary>
        /// <param name="eidolon">The updated Eidolon object.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateEidolon(int id, EidolonUpdateDto eidolon);

        /// <summary>
        /// Deletes an Eidolon from the database.
        /// </summary>
        /// <param name="id">The Id of the Eidolon to delete.</param>
        /// <returns>True if the delete was successful, false otherwise.</returns>
        Task<bool> DeleteEidolon(int id);
    }
}
