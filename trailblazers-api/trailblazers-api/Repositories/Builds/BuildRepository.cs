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
            var sql = @"
                INSERT INTO Build (Name, UserId, TrailblazerId, LightconeId, RelicId, OrnamentId) 
                VALUES (@Name, @UserId, @TrailblazerId, @LightconeId, @RelicId, @OrnamentId);
                SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                var parameters = new
                {
                    Name = build.Name,
                    UserId = build.User?.Id,
                    TrailblazerId = build.Trailblazer?.Id,
                    LightconeId = build.Lightcone?.Id,
                    RelicId = build.Relic?.Id,
                    OrnamentId = build.Ornament?.Id
                };

                return await con.ExecuteScalarAsync<int>(sql, parameters);
            }
        }

        public async Task<IEnumerable<Build>> GetAllBuilds()
        {
            var sql = @"
                SELECT b.*, u.*, t.*, l.*, r.*, o.* 
                FROM Build b
                LEFT JOIN [User] u ON b.UserId = u.Id
                LEFT JOIN Trailblazer t ON b.TrailblazerId = t.Id
                LEFT JOIN Lightcone l ON b.LightconeId = l.Id
                LEFT JOIN Relic r ON b.RelicId = r.Id
                LEFT JOIN Ornament o ON b.OrnamentId = o.Id
                WHERE b.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var buildDict = new Dictionary<int, Build>();

                var builds = await con.QueryAsync<Build, User, Trailblazer, Lightcone, Relic, Ornament, Build>(
                    sql,
                    (build, user, trailblazer, lightcone, relic, ornament) =>
                    {
                        if (!buildDict.TryGetValue(build.Id, out var currentBuild))
                        {
                            currentBuild = build;
                            currentBuild.User = user;
                            currentBuild.Trailblazer = trailblazer;
                            currentBuild.Lightcone = lightcone;
                            currentBuild.Relic = relic;
                            currentBuild.Ornament = ornament;
                            buildDict.Add(currentBuild.Id, currentBuild);
                        }

                        return currentBuild;
                    });

                return builds;
            }
        }

        public async Task<Build?> GetBuildById(int id)
        {
            var sql = @"
                SELECT b.*, u.*, t.*, l.*, r.*, o.*
                FROM Build b
                LEFT JOIN [User] u ON b.UserId = u.Id
                LEFT JOIN Trailblazer t ON b.TrailblazerId = t.Id
                LEFT JOIN Lightcone l ON b.LightconeId = l.Id
                LEFT JOIN Relic r ON b.RelicId = r.Id
                LEFT JOIN Ornament o ON b.OrnamentId = o.Id
                WHERE b.Id = @Id AND b.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var buildDict = new Dictionary<int, Build>();

                var builds = await con.QueryAsync<Build, User, Trailblazer, Lightcone, Relic, Ornament, Build>(
                    sql,
                    (build, user, trailblazer, lightcone, relic, ornament) =>
                    {
                        if (!buildDict.TryGetValue(build.Id, out var currentBuild))
                        {
                            currentBuild = build;
                            currentBuild.User = user;
                            currentBuild.Trailblazer = trailblazer;
                            currentBuild.Lightcone = lightcone;
                            currentBuild.Relic = relic;
                            currentBuild.Ornament = ornament;
                            buildDict.Add(currentBuild.Id, currentBuild);
                        }

                        return currentBuild;
                    },
                    new { Id = id });

                return builds.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateBuild(Build build)
        {
            var sql = @"
                UPDATE Build
                SET LightconeId = @LightconeId, RelicId = @RelicId, OrnamentId = @OrnamentId
                WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                var parameters = new
                {
                    Id = build.Id,
                    LightconeId = build.Lightcone?.Id,
                    RelicId = build.Relic?.Id,
                    OrnamentId = build.Ornament?.Id
                };

                var affectedRows = await con.ExecuteAsync(sql, parameters);

                return affectedRows > 0;
            }
        }

        public async Task<bool> DeleteBuild(int id)
        {
            var sql = "UPDATE Build SET IsDeleted = 1 WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                var affectedRows = await con.ExecuteAsync(sql, new { Id = id });

                return affectedRows > 0;
            }
        }

    }
}
