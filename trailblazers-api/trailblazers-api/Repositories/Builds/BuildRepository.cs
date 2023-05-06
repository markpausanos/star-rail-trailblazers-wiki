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
        public async Task<Build?> GetBuildById(int id)
        {
            var sql = "SELECT b.*, u.*, t.*, l.*, r.*, o.* " +
                        "FROM Builds b " +
                        "LEFT JOIN [User] u ON b.UserId = u.Id " +
                        "LEFT JOIN Trailblazer t ON b.TrailblazerId = t.Id " +
                        "LEFT JOIN Lightcone l ON b.LightconeId = l.Id " +
                        "LEFT JOIN BuildRelics br ON b.Id = br.BuildId " +
                        "LEFT JOIN Relics r ON br.RelicId = r.Id " +
                        "LEFT JOIN BuildOrnaments bo ON b.Id = bo.BuildId " +
                        "LEFT JOIN Ornaments o ON bo.OrnamentId = o.Id " +
                        "WHERE b.Id = @Id AND b.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var buildDict = new Dictionary<int, Build>();
                var build = await con.QueryAsync<Build, User, Trailblazer, Lightcone, Relic, Ornament, Build>(
                    sql,
                    (build, user, trailblazer, lightcone, relic, ornament) =>
                    {
                        if (!buildDict.TryGetValue(build.Id, out var currentBuild))
                        {
                            currentBuild = build;
                            currentBuild.User = user;
                            currentBuild.Trailblazer = trailblazer;
                            currentBuild.Lightcone = lightcone;
                            currentBuild.Relics = new List<Relic>();
                            currentBuild.Ornaments = new List<Ornament>();
                            buildDict.Add(currentBuild.Id, currentBuild);
                        }

                        if (relic != null && !currentBuild.Relics.Contains(relic))
                        {
                            currentBuild.Relics.Add(relic);
                        }

                        if (ornament != null && !currentBuild.Ornaments.Contains(ornament))
                        {
                            currentBuild.Ornaments.Add(ornament);
                        }

                        return currentBuild;
                    },
                    new { id });

                return build.FirstOrDefault();
            }
        }
    }
}
