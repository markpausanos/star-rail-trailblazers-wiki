using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Trailblazers
{
    public interface ITrailblazersRepository
    {
        /// <summary>
        /// Create a new Trailblazer in the Database.
        /// </summary>
        /// <param name="trailblazer">New Trailblazer to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created Trailblazer</returns>
        Task<int> CreateTrailblazer(Trailblazer trailblazer);
        /// <summary>
        /// Gets all Trailblazer in the databse.
        /// </summary>
        /// <returns><IEnumerable<Trailblazer>></returns>
        Task<IEnumerable<Trailblazer>> GetAllTrailblazers();
        /// <summary>
        /// Gets Trailblazer in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the Trailblazer to get in the database.</param>
        /// <returns>A nullable Trailblazer</returns>
        Task<Trailblazer?> GetTrailblazerById(int id);
        /// <summary>
        /// Gets a Trailblazer in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the Trailblazer to get.</param>
        /// <returns>A nullable Trailblazer</returns>
        Task<Trailblazer?> GetTrailblazerByName(string name);
        /// <summary>
        /// Updates a Trailblazer in the database.
        /// </summary>
        /// <param name="trailblazer">Updated Trailblazer</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateTrailblazer(Trailblazer trailblazer);
        /// <summary>
        /// Deletes a Trailblazer in the database.
        /// </summary>
        /// <param name="id">Id of the Trailblazer to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteTrailblazer(int id);
    }
}
