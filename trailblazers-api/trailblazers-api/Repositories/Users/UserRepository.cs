using Dapper;
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
            var sql = "INSERT INTO Users (Name, Password) VALUES (@Name, @Password); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { user.Name, user.Password });
            }
        }
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var sql = "SELECT * FROM Users;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<User>(sql);
            }
        }
        public async Task<User?> GetUserById(int id)
        {
            var sql = "SELECT * FROM Users WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<User>(sql, new { id });
            }
        }
        public async Task<User?> GetUserByName(string name)
        {
            var sql = "SELECT * FROM Users WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<User>(sql, new { name });
            }
        }
        public async Task<bool> UpdateUser(User user)
        {
            var sql = "UPDATE Users SET Password = @Password WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { user.Password, user.Id }) > 0;
            }
        }
        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
