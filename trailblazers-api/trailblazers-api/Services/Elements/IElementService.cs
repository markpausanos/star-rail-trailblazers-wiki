using trailblazers_api.DTOs.Elements;

namespace trailblazers_api.Services.Elements
{
    public interface IElementService
    {
        /// <summary>
        /// Create a new Element in the database.
        /// </summary>
        /// <param name="element">Element to be created</param>
        /// <returns>Newly created Element</returns>
        Task<ElementDto> CreateElement(ElementCreationDto element);

        /// <summary>
        /// Gets All the Element in the Database.
        /// </summary>
        /// <returns>All Elements in the database></returns>
        Task<IEnumerable<ElementDto>> GetAllElements();

        /// <summary>
        /// Gets the first Element with the given id
        /// </summary>
        /// <param name="id">Id of Element to be retrieved</param>
        /// <returns>Element with given id</returns>
        Task<ElementDto> GetElementById(int id);

        /// <summary>
        /// Updates an existing element in the database.
        /// </summary>
        /// <param name="element">The updated element.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateElement(ElementUpdateDto element);

        /// <summary>
        /// Deletes an element from the database.
        /// </summary>
        /// <param name="id">The ID of the element to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteElement(int id);
    }
}
