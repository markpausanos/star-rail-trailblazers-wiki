using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Teams
{
    public class TeamRepository
    {
        private readonly DapperContext _context;

        public TeamRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateTeam(Team team)
        {
            var sql = "INSERT INTO Teams (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { team.Name, team.Description, team.Image });
            }
        }
        public async Task<IEnumerable<Team>> GetAllTeams()
        {
            var sql = "SELECT * FROM Teams;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Team>(sql);
            }
        }
        public async Task<Team?> GetTeamById(int id)
        {
            var sql = "SELECT * FROM Teams WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Team>(sql, new { id });
            }
        }
        public async Task<Team?> GetTeamByName(string name)
        {
            var sql = "SELECT * FROM Teams WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Team>(sql, new { name });
            }
        }
        public async Task<bool> UpdateTeam(Team team)
        {
            var sql = "UPDATE Teams SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { team.Description, team.Id }) > 0;
            }
        }
        public Task<bool> DeleteTeam(int id)
        {
            throw new NotImplementedException();
        }
    }
}
