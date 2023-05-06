using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Elements
{
    public interface IElementRepository
    {
        /// <summary>
        /// Creates a new element in the database.
        /// </summary>
        /// <param name="element">The new element to create.</param>
        /// <returns>The ID of the newly created element.</returns>
        Task<int> CreateElement(Element element);

        /// <summary>
        /// Retrieves all elements in the database.
        /// </summary>
        /// <returns>An enumerable collection of elements.</returns>
        Task<IEnumerable<Element>> GetAllElements();

        /// <summary>
        /// Retrieves an element from the database by ID.
        /// </summary>
        /// <param name="id">The ID of the element to retrieve.</param>
        /// <returns>The element with the specified ID, or null if not found.</returns>
        Task<Element?> GetElementById(int id);

        /// <summary>
        /// Retrieves an element from the database by name.
        /// </summary>
        /// <param name="name">The name of the element to retrieve.</param>
        /// <returns>The element with the specified name, or null if not found.</returns>
        Task<Element?> GetElementByName(string name);

        /// <summary>
        /// Updates an existing element in the database.
        /// </summary>
        /// <param name="element">The updated element.</param>
        /// <returns>True if the update was successful, false otherwise.</returns>
        Task<bool> UpdateElement(Element element);

        /// <summary>
        /// Deletes an element from the database.
        /// </summary>
        /// <param name="id">The ID of the element to delete.</param>
        /// <returns>True if the deletion was successful, false otherwise.</returns>
        Task<bool> DeleteElement(int id);
    }
}
