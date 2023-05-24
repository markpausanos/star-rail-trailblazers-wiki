using Dapper;
using System.Data;
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
            var sql = "INSERT INTO Element (Name, Image) VALUES (@Name, @Image);" +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { element.Name, element.Image });
            }
        }

        public async Task<IEnumerable<Element>> GetAllElements()
        {
            var sql = "SELECT * FROM Element WHERE IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Element>(sql);
            }
        }

        public async Task<Element?> GetElementById(int id)
        {
            var sql = "SELECT * FROM Element WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Element>(sql, new { id });
            }
        }

        public async Task<Element?> GetElementByName(string name)
        {
            var sql = "SELECT * FROM Element WHERE Name = @Name AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Element>(sql, new { name });
            }
        }

        public async Task<bool> UpdateElement(Element element)
        {
            var sql = "UPDATE Element SET Name = @Name, Image = @Image WHERE Id = @Id AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { element.Name, element.Image, element.Id }) > 0;
            }
        }

        public async Task<bool> DeleteElement(int id)
        {
            var spName = "[spElement_DeleteElement]";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(spName,
                    new { ElementId = id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

    }
}
