using trailblazers_api.Models;

namespace trailblazers_api.Services.Elements
{
    public interface IElementService
    {
        /// <summary>
        /// Create a new Element in the database.
        /// </summary>
        /// <param name="gib">Element to be created</param>
        /// <returns>Newly created Element</returns>
        Task<Element> CreateElement(Element element);

        /// <summary>
        /// Gets All the Element in the Database.
        /// </summary>
        /// <returns>All Elements in the database></returns>
        Task<IEnumerable<Element>> GetAllElements();
    }
}
