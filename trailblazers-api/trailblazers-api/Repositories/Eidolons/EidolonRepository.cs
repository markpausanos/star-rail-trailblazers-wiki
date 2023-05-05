using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Eidolons
{
    public class EidolonRepository
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
        public async Task<IEnumerable<Eidolon>> GetAllEidolons()
        {
            var sql = "SELECT * FROM Eidolons;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Eidolon>(sql);
            }
        }
        public async Task<Eidolon?> GetEidolonById(int id)
        {
            var sql = "SELECT * FROM Eidolons WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Eidolon>(sql, new { id });
            }
        }
        public async Task<Eidolon?> GetEidolonByName(string name)
        {
            var sql = "SELECT * FROM Eidolons WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Eidolon>(sql, new { name });
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
        public Task<bool> DeleteEidolon(int id)
        {
            throw new NotImplementedException();
        }
    }
}
