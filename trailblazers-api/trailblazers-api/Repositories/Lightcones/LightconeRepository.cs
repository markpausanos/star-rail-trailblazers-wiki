using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Lightcones
{
    public class LightconeRepository : ILightconeRepository
    {
        private readonly DapperContext _context;

        public LightconeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateLightcone(Lightcone lightcone)
        {
            var sql = "INSERT INTO Lightcones (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { lightcone.Name, lightcone.Description, lightcone.Image });
            }
        }
        public async Task<IEnumerable<Lightcone>> GetAllLightcones()
        {
            var sql = "SELECT * FROM Lightcones;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Lightcone>(sql);
            }
        }
        public async Task<Lightcone?> GetLightconeById(int id)
        {
            var sql = "SELECT * FROM Lightcones WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Lightcone>(sql, new { id });
            }
        }
        public async Task<Lightcone?> GetLightconeByName(string name)
        {
            var sql = "SELECT * FROM Lightcones WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Lightcone>(sql, new { name });
            }
        }
        public async Task<bool> UpdateLightcone(Lightcone lightcone)
        {
            var sql = "UPDATE Lightcones SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { lightcone.Description, lightcone.Id }) > 0;
            }
        }
        public Task<bool> DeleteLightcone(int id)
        {
            throw new NotImplementedException();
        }
    }
}
