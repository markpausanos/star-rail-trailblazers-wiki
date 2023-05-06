using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Traces
{
    public class TraceRepository : ITraceRepository
    {
        private readonly DapperContext _context;

        public TraceRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateTrace(Trace ascension)
        {
            var sql = "INSERT INTO Trace (Name, Description) VALUES (@Name, @Description); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { ascension.Name, ascension.Description });
            }
        }
        public async Task<IEnumerable<Trace>> GetAllTrace()
        {
            var sql = "SELECT * FROM Trace;";

            using (var con = _context.CreateConnection())
            {
                return await con.QueryAsync<Trace>(sql);
            }
        }
        public async Task<Trace?> GetTraceById(int id)
        {
            var sql = "SELECT * FROM Trace WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Trace>(sql, new { id });
            }
        }
        public async Task<Trace?> GetTraceByName(string name)
        {
            var sql = "SELECT * FROM Trace WHERE Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Trace>(sql, new { name });
            }
        }
        public async Task<bool> UpdateTrace(Trace ascension)
        {
            var sql = "UPDATE Trace SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { ascension.Description, ascension.Id }) > 0;
            }
        }
        public Task<bool> DeleteTrace(int id)
        {
            throw new NotImplementedException();
        }
    }
}
