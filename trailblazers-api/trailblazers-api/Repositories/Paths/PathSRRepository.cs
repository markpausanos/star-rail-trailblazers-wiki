using Dapper;
using System.Data;
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
            var sql = "INSERT INTO PathSR (Name, Image) VALUES (@Name, @Image); SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { path.Name, path.Image });
            }
        }

        public async Task<IEnumerable<PathSR>> GetAllPathSRs()
        {
            var sql = "SELECT * FROM PathSR WHERE IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<PathSR>(sql);
            }
        }

        public async Task<PathSR?> GetPathSRById(int id)
        {
            var sql = "SELECT * FROM PathSR WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<PathSR>(sql, new { id });
            }
        }

        public async Task<PathSR?> GetPathSRByName(string name)
        {
            var sql = "SELECT * FROM PathSR WHERE Name = @Name AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<PathSR>(sql, new { name });
            }
        }

        public async Task<bool> UpdatePathSR(PathSR path)
        {
            var sql = "UPDATE PathSR SET Name = @Name, Image = @Image WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { path.Name, path.Image, path.Id }) > 0;
            }
        }

        public async Task<bool> DeletePathSR(int id)
        {
            var spName = "[spPathSR_DeletePathSR]";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(spName, new { PathSRId = id }, commandType: CommandType.StoredProcedure) > 0;
            }
        }
    }
}
