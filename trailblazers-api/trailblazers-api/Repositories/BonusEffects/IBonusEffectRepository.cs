using trailblazers_api.Models;

namespace trailblazers_api.Repositories.BonusEffects
{
    public interface IBonusEffectRepository
    {
        /// <summary>
        /// Create a new BonusEffect in the Database.
        /// </summary>
        /// <param name="bonusEffect">New BonusEffect to be created.</param>
        /// <returns>A int Data type which is the Id of the newly created BonusEffect</returns>
        Task<int> CreateBonusEffect(BonusEffect bonusEffect);
        /// <summary>
        /// Gets all BonusEffect in the databse.
        /// </summary>
        /// <returns><IEnumerable<BonusEffect>></returns>
        Task<IEnumerable<BonusEffect>> GetAllBonusEffects();
        /// <summary>
        /// Gets BonusEffect in the database by the Id.
        /// </summary>
        /// <param name="id">Id of the BonusEffect to get in the database.</param>
        /// <returns>A nullable BonusEffect</returns>
        Task<BonusEffect?> GetBonusEffectById(int id);
        /// <summary>
        /// Gets a BonusEffect in the databse by Name.
        /// </summary>
        /// <param name="name">Name of the BonusEffect to get.</param>
        /// <returns>A nullable BonusEffect</returns>
        Task<BonusEffect?> GetBonusEffectByName(string name);
        /// <summary>
        /// Updates a BonusEffect in the database.
        /// </summary>
        /// <param name="bonusEffect">Updated BonusEffect</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> UpdateBonusEffect(BonusEffect bonusEffect);
        /// <summary>
        /// Deletes a BonusEffect in the database.
        /// </summary>
        /// <param name="id">Id of the BonusEffect to be Deleted.</param>
        /// <returns>
        ///     true : If succesfully.
        ///     false : If unsuccessful.
        /// </returns>
        Task<bool> DeleteBonusEffect(int id);
    }
}
