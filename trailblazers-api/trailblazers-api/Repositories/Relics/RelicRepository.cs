using Dapper;
using System.Data;
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
            var sql = "INSERT INTO Relics (Name, DescriptionOne, DescriptionTwo, Image) " +
                      "VALUES (@Name, @DescriptionOne, @DescriptionTwo, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, relic);
            }
        }
        public async Task<IEnumerable<Relic>> GetAllRelics()
        {
            var sql = "SELECT * FROM Relics WHERE IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Relic>(sql);
            }
        }
        public async Task<Relic?> GetRelicById(int id)
        {
            var sql = "SELECT * FROM Relics WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Relic>(sql, new { id });
            }
        }
        public async Task<Relic?> GetRelicByName(string name)
        {
            var sql = "SELECT * FROM Relics WHERE Name = @Name AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Relic>(sql, new { name });
            }
        }
        public async Task<bool> UpdateRelic(Relic relic)
        {
            var sql = "UPDATE Relics SET DescriptionOne = @DescriptionOne, " +
                      "DescriptionTwo = @DescriptionTwo, Image = @Image WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, relic) > 0;
            }
        }
        public async Task<bool> DeleteRelic(int id)
        {
            var spName = "[spRelic_DeleteRelic]";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(spName,
                    new { RelicId = id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
