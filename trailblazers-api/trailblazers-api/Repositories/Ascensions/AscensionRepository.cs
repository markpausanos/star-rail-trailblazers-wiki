using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Ascensions
{
    public class AscensionRepository : IAscensionRepository
    {
        private readonly DapperContext _context;

        public AscensionRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateAscension(Ascension ascension)
        {
            var sql = "INSERT INTO Ascensions (Name, Description) VALUES (@Name, @Description); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { ascension.Name, ascension.Description });
            }
        }
        public async Task<IEnumerable<Ascension>> GetAllAscensions()
        {
            var sql = "SELECT * FROM Ascensions;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Ascension>(sql);
            }
        }
        public async Task<Ascension?> GetAscensionById(int id)
        {
            var sql = "SELECT * FROM Ascensions WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Ascension>(sql, new { id });
            }
        }
        public async Task<Ascension?> GetAscensionByName(string name)
        {
            var sql = "SELECT * FROM Ascensions WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Ascension>(sql, new { name });
            }
        }
        public async Task<bool> UpdateAscension(Ascension ascension)
        {
            var sql = "UPDATE Ascensions SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { ascension.Description, ascension.Id }) > 0;
            }
        }
        public Task<bool> DeleteAscension(int id)
        {
            throw new NotImplementedException();
        }
    }
}
