﻿using trailblazers_api.Dtos.Ornaments;

namespace trailblazers_api.Services.Ornaments
{
    public interface IOrnamentService
    {
        /// <summary>
        /// Creates a new Ornament in the database.
        /// </summary>
        /// <param name="ornament">The Ornament object to be created.</param>
        /// <returns>A nullable OrnamentDto object representing the newly created Ornament.</returns>
        Task<OrnamentDto?> CreateOrnament(OrnamentCreationDto ornament);

        /// <summary>
        /// Retrieves all Ornament objects from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of OrnamentDto objects.</returns>
        Task<IEnumerable<OrnamentDto>> GetAllOrnaments();

        /// <summary>
        /// Retrieves an Ornament object from the database by its Id.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be retrieved.</param>
        /// <returns>A nullable OrnamentDto object.</returns>
        Task<OrnamentDto?> GetOrnamentById(int id);

        /// <summary>
        /// Retrieves an Ornament object from the database by its Name.
        /// </summary>
        /// <param name="name">The Name of the Ornament to be retrieved.</param>
        /// <returns>A nullable OrnamentDto object.</returns>
        Task<OrnamentDto?> GetOrnamentByName(string name);

        /// <summary>
        /// Updates an Ornament object in the database.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be updated.</param>
        /// <param name="ornament">The updated Ornament object.</param>
        /// <returns>A boolean value indicating whether the operation was successful.</returns>
        Task<bool> UpdateOrnament(int id, OrnamentUpdateDto ornament);

        /// <summary>
        /// Deletes an Ornament object from the database.
        /// </summary>
        /// <param name="id">The Id of the Ornament to be deleted.</param>
        /// <returns>A boolean value indicating whether the operation was successful.</returns>
        Task<bool> DeleteOrnament(int id);
    }
}
