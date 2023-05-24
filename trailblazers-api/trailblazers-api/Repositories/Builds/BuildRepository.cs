using Dapper;
using System.Data;
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
                SELECT b.*, u.*, t.*, ele.*, p.*, l.*, r.*, o.* 
                FROM Build b
                LEFT JOIN [User] u ON b.UserId = u.Id
                LEFT JOIN Trailblazer t ON b.TrailblazerId = t.Id
                LEFT JOIN Element ele ON t.ElementId = ele.Id
                LEFT JOIN PathSR p ON t.PathSRId = p.Id
                LEFT JOIN Lightcone l ON b.LightconeId = l.Id
                LEFT JOIN Relic r ON b.RelicId = r.Id
                LEFT JOIN Ornament o ON b.OrnamentId = o.Id
                WHERE b.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var buildDict = new Dictionary<int, Build>();

                var builds = await con.QueryAsync(
                    sql,
                    types: new[]
                    {
                        typeof(Build),
                        typeof(User),
                        typeof(Trailblazer),
                        typeof(Element),
                        typeof(PathSR),
                        typeof(Lightcone),
                        typeof(Relic),
                        typeof(Ornament)
                    },
                    map: (objects) =>
                    {
                        var build = (Build)objects[0];
                        var user = (User)objects[1];
                        var trailblazer = (Trailblazer)objects[2];
                        var element = (Element)objects[3];
                        var pathSR = (PathSR)objects[4];
                        var lightcone = (Lightcone)objects[5];
                        var relic = (Relic)objects[6];
                        var ornament = (Ornament)objects[7];

                        if (!buildDict.TryGetValue(build.Id, out var currentBuild))
                        {
                            currentBuild = build;
                            currentBuild.User = user;
                            currentBuild.Trailblazer = trailblazer;
                            currentBuild.Trailblazer.Element = element;
                            currentBuild.Trailblazer.PathSR = pathSR;
                            currentBuild.Lightcone = lightcone;
                            currentBuild.Relic = relic;
                            currentBuild.Ornament = ornament;
                            buildDict.Add(currentBuild.Id, currentBuild);
                        }
                        else
                        {
                            // Merge the subsequent rows into existing Build entity
                            if (user != null)
                                currentBuild.User ??= user;

                            if (trailblazer != null)
                            {
                                currentBuild.Trailblazer ??= trailblazer;

                                if (element != null)
                                    currentBuild.Trailblazer.Element ??= element;

                                if (pathSR != null)
                                    currentBuild.Trailblazer.PathSR ??= pathSR;
                            }

                            if (lightcone != null)
                                currentBuild.Lightcone ??= lightcone;

                            if (relic != null)
                                currentBuild.Relic ??= relic;

                            if (ornament != null)
                                currentBuild.Ornament ??= ornament;
                        }

                        return currentBuild;
                    },
                    splitOn: "Id,Id,Id,Id,Id,Id,Id",
                    param: null,
                    transaction: null,
                    buffered: true,
                    commandTimeout: null,
                    commandType: null
                );

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
