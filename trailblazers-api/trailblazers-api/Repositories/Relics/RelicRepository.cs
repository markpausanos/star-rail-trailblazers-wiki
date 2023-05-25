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
            var sql = @"
                INSERT INTO Relic (Name, DescriptionOne, DescriptionTwo, Image) 
                VALUES (@Name, @DescriptionOne, @DescriptionTwo, @Image);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteScalarAsync<int>(sql, relic);
            }
        }

        public async Task<IEnumerable<Relic>> GetAllRelics()
        {
            var sql = "SELECT * FROM Relic WHERE IsDeleted = 0;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Relic>(sql);
            }
        }

        public async Task<Relic?> GetRelicById(int id)
        {
            var sql = "SELECT * FROM Relic WHERE Id = @Id AND IsDeleted = 0;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Relic>(sql, new { Id = id });
            }
        }

        public async Task<Relic?> GetRelicByName(string name)
        {
            var sql = "SELECT * FROM Relic WHERE Name = @Name AND IsDeleted = 0;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Relic>(sql, new { Name = name });
            }
        }

        public async Task<bool> UpdateRelic(Relic relic)
        {
            var sql = @"
                UPDATE Relic 
                SET DescriptionOne = @DescriptionOne, DescriptionTwo = @DescriptionTwo, Image = @Image 
                WHERE Id = @Id AND IsDeleted = 0;";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(sql, new
                {
                    DescriptionOne = relic.DescriptionOne,
                    DescriptionTwo = relic.DescriptionTwo,
                    Image = relic.Image,
                    Id = relic.Id
                }) > 0;
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
