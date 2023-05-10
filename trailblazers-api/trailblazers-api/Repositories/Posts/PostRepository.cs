using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Posts
{
    public class PostRepository : IPostRepository
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
            var sql = @"SELECT p.*, u.*, t.*, b.*
                FROM Post p
                LEFT JOIN User u ON p.UserId = u.Id
                LEFT JOIN Team t ON p.TeamId = t.Id
                LEFT JOIN TeamBuild tb ON t.Id = tb.TeamId
                LEFT JOIN Build b ON tb.BuildId = b.Id
                WHERE p.IsDeleted = 0 AND u.IsDeleted = 0 AND t.IsDeleted = 0 AND b.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var posts = new Dictionary<int, Post>();

                await con.QueryAsync<Post, User, Team, Build, Post>(sql, (post, user, team, build) =>
                {
                    if (!posts.TryGetValue(post.Id, out var postEntry))
                    {
                        postEntry = post;
                        postEntry.User = user;
                        postEntry.Team = team != null ? new Team { Id = team.Id, Name = team.Name, User = team.User, Builds = new List<Build>() } : null;
                        posts.Add(postEntry.Id, postEntry);
                    }

                    if (build != null && postEntry.Team != null)
                    {
                        postEntry.Team.Builds.Add(build);
                    }

                    return postEntry;
                });

                return posts.Values;
            }
        }

        public async Task<IEnumerable<Post>> GetPostsByUserId(int userId)
        {
            var sql = @"SELECT p.*, u.*, t.*, b.*
                FROM Post p
                LEFT JOIN User u ON p.UserId = u.Id
                LEFT JOIN Team t ON p.TeamId = t.Id
                LEFT JOIN TeamBuild tb ON t.Id = tb.TeamId
                LEFT JOIN Build b ON tb.BuildId = b.Id
                WHERE p.UserId = @UserId AND p.IsDeleted = 0 AND u.IsDeleted = 0 AND t.IsDeleted = 0 AND b.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var posts = new Dictionary<int, Post>();

                await con.QueryAsync<Post, User, Team, Build, Post>(sql, (post, user, team, build) =>
                {
                    if (!posts.TryGetValue(post.Id, out var postEntry))
                    {
                        postEntry = post;
                        postEntry.User = user;
                        postEntry.Team = team != null ? new Team { Id = team.Id, Name = team.Name, User = team.User, Builds = new List<Build>() } : null;
                        posts.Add(postEntry.Id, postEntry);
                    }

                    if (build != null && postEntry.Team != null)
                    {
                        postEntry.Team.Builds.Add(build);
                    }

                    return postEntry;
                });

                return posts.Values;
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
