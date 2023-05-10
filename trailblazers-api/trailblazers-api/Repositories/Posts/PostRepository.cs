using Dapper;
using System.Data;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Posts
{
    public class PostRepository
    {
        private readonly DapperContext _context;

        public PostRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreatePost(Post post)
        {
            var sql = "INSERT INTO Post (Description, UserId, TeamId) " +
                      "VALUES (@Description, @UserId, @TeamId);" +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new
                {
                    post.Description,
                    UserId = post.User?.Id,
                    TeamId = post.Team?.Id
                });
            }
        }

        public async Task<IEnumerable<Post>> GetAllPosts()
        {
            var sql = "SELECT * FROM Post WHERE IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Post>(sql);
            }
        }

        public async Task<Post?> GetPostById(int id)
        {
            var sql = "SELECT * FROM Post WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Post>(sql, new { id });
            }
        }

        public async Task<bool> UpdatePost(Post post)
        {
            var sql = "UPDATE Post SET Description = @Description " +
                      "WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new
                {
                    post.Description,
                    post.Id
                }) > 0;
            }
        }

        public async Task<bool> DeletePost(int id)
        {
            var sql = "UPDATE Post SET IsDeleted = 1 WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { Id = id }) > 0;
            }
        }
    }
}
