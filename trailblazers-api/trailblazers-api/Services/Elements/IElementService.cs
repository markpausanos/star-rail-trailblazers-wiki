using trailblazers_api.Dtos.Elements;

namespace trailblazers_api.Services.Elements
{
    public interface IElementService
    {
        /// <summary>
        /// Create a new Element in the database.
        /// </summary>
        /// <param name="element">Element to be created</param>
        /// <returns>Newly created Element</returns>
        Task<ElementDto?> CreateElement(ElementCreationDto element);

        /// <summary>
        /// Gets all the Elements in the Database.
        /// </summary>
        /// <returns>All Elements in the database.</returns>
        Task<IEnumerable<ElementDto>> GetAllElements();

        /// <summary>
        /// Gets the Element with the given ID.
        /// </summary>
        /// <param name="id">ID of the Element to be retrieved.</param>
        /// <returns>The Element with the given ID, or null if not found.</returns>
        Task<ElementDto?> GetElementById(int id);

        /// <summary>
        /// Gets the Element with the given name.
        /// </summary>
        /// <param name="name">Name of the Element to be retrieved.</param>
        /// <returns>The Element with the given name, or null if not found.</returns>
        Task<ElementDto?> GetElementByName(string name);

        /// <summary>
        /// Updates an existing Element in the database.
        /// </summary>
        /// <param name="id">ID of the Element to be updated.</param>
        /// <param name="element">The updated Element object.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateElement(int id, ElementUpdateDto element);

        /// <summary>
        /// Deletes an Element from the database.
        /// </summary>
        /// <param name="id">The ID of the Element to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteElement(int id);
    }
}
