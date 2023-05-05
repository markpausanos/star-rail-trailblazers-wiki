using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Elements
{
    public interface IElementRepository
    {
        /// <summary>
        /// Create a new Element in the Database.
        /// </summary>
        /// <param name="element">New Element to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Element</returns>
        Task<int> CreateElement(Element element);
        /// <summary>
        /// Gets all Element in the databse.
        /// </summary>
        /// <returns><IEnumerable<Element>></returns>
        Task<IEnumerable<Element>> GetAllElements();
        /// <summary>
        /// Gets Element in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Element to get in the database.</param>
        /// <returns>A nullable Element</returns>
        Task<Element?> GetElementById(int id);
        /// <summary>
        /// Gets a Role in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Role to get.</param>
        /// <returns>A nullable Role</returns>
        Task<Element?> GetElementByName(string name);
        /// <summary>
        /// Updates a Element in the database.
        /// </summary>
        /// <param name="element">Updated Element</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateElement(Element element);
        /// <summary>
        /// Deletes a Element in the database.
        /// </summary>
        /// <param name="id">Id of the Element to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteElement(int id);
    }
}
