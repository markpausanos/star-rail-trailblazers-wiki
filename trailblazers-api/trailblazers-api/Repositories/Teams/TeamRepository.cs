using Dapper;
using System.Data;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Teams
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DapperContext _context;

        public TeamRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateTeam(Team team)
        {
            var sql = "INSERT INTO Teams (Name, UserId) VALUES (@Name, @UserId); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { team.Name, team.User!.Id });
            }
        }

        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            var sql = @"
                    SELECT t.Id, t.Name, t.UserId, b.Id AS BuildId, b.Name AS BuildName 
                    FROM Teams t 
                    LEFT JOIN TeamBuilds tb ON tb.TeamId = t.Id 
                    LEFT JOIN Builds b ON b.Id = tb.BuildId
                    WHERE t.IsDeleted = 0";

            using (var con = _context.CreateConnection())
            {
                var teamDict = new Dictionary<int, Team>();
                var result = await con.QueryAsync<Team, Build, Team>(
                    sql,
                    (team, build) =>
                    {
                        if (!teamDict.TryGetValue(team.Id, out var currentTeam))
                        {
                            currentTeam = team;
                            teamDict.Add(currentTeam.Id, currentTeam);
                        }

                        if (build != null)
                        {
                            currentTeam.Builds.Add(build);
                        }

                        return currentTeam;
                    },
                    splitOn: "BuildId"
                );

                return result.GroupBy(t => t.Id)
                             .Select(g => g.First());
            }
        }


        public async Task<IEnumerable<Team>> GetAllTeamsByUserId(int userId)
        {
            var sql = @"
                    SELECT t.Id, t.Name, t.UserId, b.Id AS BuildId, b.Name AS BuildName
                    FROM Teams t
                    LEFT JOIN TeamBuilds tb ON tb.TeamId = t.Id
                    LEFT JOIN Builds b ON b.Id = tb.BuildId
                    WHERE t.IsDeleted = 0 AND t.UserId = @UserId";

            using (var con = _context.CreateConnection())
            {
                var teams = await con.QueryAsync<Team, Build, Team>(
                    sql,
                    (team, build) =>
                    {
                        if (team.Builds == null)
                        {
                            team.Builds = new List<Build>();
                        }

                        if (build != null)
                        {
                            team.Builds.Add(build);
                        }

                        return team;
                    },
                    new { UserId = userId },
                    splitOn: "BuildId"
                );

                return teams.Distinct();
            }
        }

        public async Task<bool> UpdateTeam(Team team)
        {
            var sql = "UPDATE Teams SET Name = @Name WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { team.Name, team.Id }) > 0;
            }
        }

        public async Task<bool> DeleteTeam(int id)
        {
            var spName = "[dbo].[spTeam_DeleteTeam]";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(spName, new { TeamId = id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

    }
}