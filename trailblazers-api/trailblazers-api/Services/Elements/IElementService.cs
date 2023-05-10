using trailblazers_api.Models;

namespace trailblazers_api.Services.Elements
{
    public interface IElementService
    {
        /// <summary>
        /// Create a new Element in the database.
        /// </summary>
        /// <param name="element">Element to be created</param>
        /// <returns>Newly created Element</returns>
        Task<Element> CreateElement(Element element);

        /// <summary>
        /// Gets All the Element in the Database.
        /// </summary>
        /// <returns>All Elements in the database></returns>
        Task<IEnumerable<Element>> GetAllElements();

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
