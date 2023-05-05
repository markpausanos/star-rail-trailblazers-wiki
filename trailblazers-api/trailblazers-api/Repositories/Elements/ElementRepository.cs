using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Elements
{
    public class ElementRepository : IElementRepository
    {
        private readonly DapperContext _context;

        public ElementRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateElement(Element element)
        {
            var sql = "INSERT INTO Elements (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { element.Name, element.Description, element.Image });
            }
        }
        public async Task<IEnumerable<Element>> GetAllElements()
        {
            var sql = "SELECT * FROM Elements;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Element>(sql);
            }
        }
        public async Task<Element?> GetElementById(int id)
        {
            var sql = "SELECT * FROM Elements WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Element>(sql, new { id });
            }
        }
        public async Task<Element?> GetElementByName(string name)
        {
            var sql = "SELECT * FROM Elements WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Element>(sql, new { name });
            }
        }
        public async Task<bool> UpdateElement(Element element)
        {
            var sql = "UPDATE Elements SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { element.Description, element.Id }) > 0;
            }
        }
        public Task<bool> DeleteElement(int id)
        {
            throw new NotImplementedException();
        }
    }
}
