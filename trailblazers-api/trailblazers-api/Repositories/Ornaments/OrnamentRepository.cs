using Dapper;
using System.Data;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Ornaments
{
    public class OrnamentRepository : IOrnamentRepository
    {
        private readonly DapperContext _context;

        public OrnamentRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateOrnament(Ornament ornament)
        {
            var sql = "INSERT INTO Ornaments (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { ornament.Name, ornament.Description, ornament.Image });
            }
        }
        public async Task<IEnumerable<Ornament>> GetAllOrnaments()
        {
            var sql = "SELECT * FROM Ornaments;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Ornament>(sql);
            }
        }
        public async Task<Ornament?> GetOrnamentById(int id)
        {
            var sql = "SELECT * FROM Ornaments WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Ornament>(sql, new { id });
            }
        }
        public async Task<Ornament?> GetOrnamentByName(string name)
        {
            var sql = "SELECT * FROM Ornaments WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Ornament>(sql, new { name });
            }
        }
        public async Task<bool> UpdateOrnament(Ornament ornament)
        {
            var sql = "UPDATE Ornaments SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { ornament.Description, ornament.Id }) > 0;
            }
        }
        public async Task<bool> DeleteOrnament(int id)
        {
            var spName = "[dbo].[spOrnament_DeleteOrnament]";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(spName,
                    new { OrnamentId = id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
