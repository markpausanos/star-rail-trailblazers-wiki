using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Eidolons
{
    public class EidolonRepository : IEidolonRepository
    {
        private readonly DapperContext _context;

        public EidolonRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEidolon(Eidolon eidolon)
        {
            var sql = "INSERT INTO Eidolons (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { eidolon.Name, eidolon.Description, eidolon.Image });
            }
        }
        public async Task<IEnumerable<Eidolon>> GetAllEidolonsByTrailblazerId(int trailblazerId)
        {
            var sql = "SELECT e.*, t.* " +
                      "FROM Eidolon e " +
                      "LEFT JOIN Trailblazer t ON e.TrailblazerId = t.Id " +
                      "WHERE e.TrailblazerId = @TrailblazerId AND e.IsDeleted = 0;";

            using (var connection = _context.CreateConnection())
            {
                var eidolons = await connection.QueryAsync<Eidolon, Trailblazer, Eidolon>(
                    sql,
                    (eidolon, trailblazer) =>
                    {
                        eidolon.Trailblazer = trailblazer;
                        return eidolon;
                    },
                    new { trailblazerId },
                    splitOn: "Id");

                return eidolons;
            }
        }

        public async Task<bool> UpdateEidolon(Eidolon eidolon)
        {
            var sql = "UPDATE Eidolons SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { eidolon.Description, eidolon.Id }) > 0;
            }
        }
        public async Task<bool> DeleteEidolon(int id)
        {
            var sql = "UPDATE Eidolons SET IsDeleted = 1 WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

    }
}
