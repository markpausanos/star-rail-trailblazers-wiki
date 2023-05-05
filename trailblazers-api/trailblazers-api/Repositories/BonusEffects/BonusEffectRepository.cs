using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.BonusEffects
{
    public class BonusEffectRepository : IBonusEffectRepository
    {
        private readonly DapperContext _context;

        public BonusEffectRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateBonusEffect(BonusEffect element)
        {
            var sql = "INSERT INTO BonusEffects (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { element.Name, element.Description, element.Image });
            }
        }
        public async Task<IEnumerable<BonusEffect>> GetAllBonusEffects()
        {
            var sql = "SELECT * FROM BonusEffects;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<BonusEffect>(sql);
            }
        }
        public async Task<BonusEffect?> GetBonusEffectById(int id)
        {
            var sql = "SELECT * FROM BonusEffects WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<BonusEffect>(sql, new { id });
            }
        }
        public async Task<BonusEffect?> GetBonusEffectByName(string name)
        {
            var sql = "SELECT * FROM BonusEffects WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<BonusEffect>(sql, new { name });
            }
        }
        public async Task<bool> UpdateBonusEffect(BonusEffect element)
        {
            var sql = "UPDATE BonusEffects SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { element.Description, element.Id }) > 0;
            }
        }
        public Task<bool> DeleteBonusEffect(int id)
        {
            throw new NotImplementedException();
        }
    }
}
