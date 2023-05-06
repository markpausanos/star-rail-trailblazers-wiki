using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Builds
{
    public class BuildRepository : IBuildRepository
    {
        private readonly DapperContext _context;

        public BuildRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateBuild(Build build)
        {
            var sql = "INSERT INTO Builds (UserId, TrailblazerId) VALUES (@UserId, @TrailblazerId); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { UserId = build.User!.Id, TrailblazerId = build.Trailblazer!.Id });
            }
        }
        public async Task<IEnumerable<Build>> GetAllBuilds()
        {
            var sql = "SELECT * FROM Builds;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Build>(sql);
            }
        }
        public async Task<Build?> GetBuildById(int id)
        {
            var sql = "SELECT * FROM Builds WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Build>(sql, new { id });
            }
        }
        public async Task<Build?> GetBuildByName(string name)
        {
            var sql = "SELECT * FROM Builds WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Build>(sql, new { name });
            }
        }
        public Task<bool> UpdateBuild(Build build)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteBuild(int id)
        {
            throw new NotImplementedException();
        }
    }
}
