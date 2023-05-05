using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Relics
{
    public class RelicRepository : IRelicRepository
    {
        private readonly DapperContext _context;

        public RelicRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateRelic(Relic relic)
        {
            var sql = "INSERT INTO Relics (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { relic.Name, relic.Description, relic.Image });
            }
        }
        public async Task<IEnumerable<Relic>> GetAllRelics()
        {
            var sql = "SELECT * FROM Relics;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Relic>(sql);
            }
        }
        public async Task<Relic?> GetRelicById(int id)
        {
            var sql = "SELECT * FROM Relics WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Relic>(sql, new { id });
            }
        }
        public async Task<Relic?> GetRelicByName(string name)
        {
            var sql = "SELECT * FROM Relics WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Relic>(sql, new { name });
            }
        }
        public async Task<bool> UpdateRelic(Relic relic)
        {
            var sql = "UPDATE Relics SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { relic.Description, relic.Id }) > 0;
            }
        }
        public Task<bool> DeleteRelic(int id)
        {
            throw new NotImplementedException();
        }
    }
}
