using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Paths
{
    public class PathSRRepository : IPathSRRepository
    {
        private readonly DapperContext _context;

        public PathSRRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreatePathSR(PathSR path)
        {
            var sql = "INSERT INTO Paths (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { path.Name, path.Description, path.Image });
            }
        }
        public async Task<IEnumerable<PathSR>> GetAllPathSRs()
        {
            var sql = "SELECT * FROM Paths;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<PathSR>(sql);
            }
        }
        public async Task<PathSR?> GetPathSRById(int id)
        {
            var sql = "SELECT * FROM Paths WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<PathSR>(sql, new { id });
            }
        }
        public async Task<PathSR?> GetPathSRByName(string name)
        {
            var sql = "SELECT * FROM Paths WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<PathSR>(sql, new { name });
            }
        }
        public async Task<bool> UpdatePathSR(PathSR path)
        {
            var sql = "UPDATE Paths SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { path.Description, path.Id }) > 0;
            }
        }
        public Task<bool> DeletePathSR(int id)
        {
            throw new NotImplementedException();
        }
    }
}
