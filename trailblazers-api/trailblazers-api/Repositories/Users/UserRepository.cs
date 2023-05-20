using Dapper;
using System.Data;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly DapperContext _context;

        public UserRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateUser(User user)
        {
            var sql = "INSERT INTO [User] ([Name], [Password]) VALUES (@Name, @Password); " +
                      "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { user.Name, user.Password });
            }
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var sql = "SELECT * FROM [User] WHERE IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<User>(sql);
            }
        }

        public async Task<User?> GetUserById(int id)
        {
            var sql = "SELECT * FROM [User] WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
            }
        }

        public async Task<User?> GetUserByName(string name)
        {
            var sql = "SELECT * FROM [User] WHERE [Name] = @Name AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<User>(sql, new { Name = name });
            }
        }

        public async Task<bool> UpdateUser(User user)
        {
            var sql = "UPDATE [User] SET [Password] = @Password WHERE [Name] = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { user.Password, user.Name }) > 0;
            }
        }

        public async Task<bool> DeleteUser(string name)
        {
            var user = await GetUserByName(name);

            if (user == null)
            {
                return false;
            }

            int id = user.Id;

            var sql = "SELECT [Id] FROM [Team] WHERE [UserId] = @Id";
            var spName = "[spUser_DeleteUser]";

            using (var con = _context.CreateConnection())
            {
                var ids = await con.QueryAsync<int>(sql, new { Id = id });
                foreach (var teamId in ids)
                {
                    await con.ExecuteAsync("[spTeam_DeleteTeam]", new { TeamId = teamId }, commandType: CommandType.StoredProcedure);
                }
                await con.ExecuteAsync(spName, new { UserId = id }, commandType: CommandType.StoredProcedure);
                return true;
            }
        }
    }
}
