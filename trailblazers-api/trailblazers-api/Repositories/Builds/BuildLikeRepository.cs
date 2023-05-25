using Dapper;
using trailblazers_api.Context;

namespace trailblazers_api.Repositories.Builds
{
    public class BuildLikeRepository : IBuildLikeRepository
    {
        private readonly DapperContext _context;

        public BuildLikeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> GetTotalLikesByBuild(int buildId)
        {
            var sql = "SELECT COUNT(*) FROM [Like] WHERE BuildId = @BuildId";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { BuildId = buildId });
            }
        }

        public async Task<IEnumerable<int>> GetLikesByUser(int userId)
        {
            var sql = "SELECT BuildId FROM [Like] WHERE UserId = @UserId";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<int>(sql, new { UserId = userId });
            }
        }

        public async Task<bool> AddLike(int userId, int buildId)
        {
            var sql = "INSERT INTO [Like] (UserId, BuildId) VALUES (@UserId, @BuildId)";

            using (var con = _context.CreateConnection())
            {
                var affectedRows = await con.ExecuteAsync(sql, new { UserId = userId, BuildId = buildId });
                return affectedRows > 0;
            }
        }

        public async Task<bool> RemoveLike(int userId, int buildId)
        {
            var sql = "DELETE FROM [Like] WHERE UserId = @UserId AND BuildId = @BuildId";

            using (var con = _context.CreateConnection())
            {
                var affectedRows = await con.ExecuteAsync(sql, new { UserId = userId, BuildId = buildId });
                return affectedRows > 0;
            }
        }

        public async Task<bool> IsLikedByUser(int userId, int buildId)
        {
            var sql = "SELECT COUNT(*) FROM [Like] WHERE UserId = @UserId AND BuildId = @BuildId";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { UserId = userId, BuildId = buildId }) > 0;
            }
        }
    }
}
