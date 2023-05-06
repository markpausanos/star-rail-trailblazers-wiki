    using Dapper;
    using trailblazers_api.Context;
    using trailblazers_api.Models;

    namespace trailblazers_api.Repositories.Trailblazers
    {
        public class TrailblazerRepository : ITrailblazersRepository
        {
            private readonly DapperContext _context;

            public TrailblazerRepository(DapperContext context)
            {
                _context = context;
            }
            public async Task<int> CreateTrailblazer(Trailblazer trailblazer)
            {
                var sql = "INSERT INTO Trailblazers (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                          "SELECT SCOPE_IDENTITY();";

                using (var con = _context.CreateConnection())
                {
                    return await con.ExecuteScalarAsync<int>(sql, new { trailblazer.Name, trailblazer.Description, trailblazer.Image });
                }
            }
            public async Task<IEnumerable<Trailblazer>> GetAllTrailblazers()
            {
                var sql = "SELECT * FROM Trailblazers;";

                using (var con = _context.CreateConnection())
                {
                    return await con.QueryAsync<Trailblazer>(sql);
                }
            }
            public async Task<Trailblazer?> GetTrailblazerById(int id)
            {
                var sql = "SELECT * FROM Trailblazers WHERE Id = @Id;";

                using (var con = _context.CreateConnection())
                {
                    return await con.QuerySingleOrDefaultAsync<Trailblazer>(sql, new { id });
                }
            }
            public async Task<Trailblazer?> GetTrailblazerByName(string name)
            {
                var sql = "SELECT * FROM Trailblazers WHERE Name = @Name;";

                using (var con = _context.CreateConnection())
                {
                    return await con.QuerySingleOrDefaultAsync<Trailblazer>(sql, new { name });
                }
            }
            public async Task<bool> UpdateTrailblazer(Trailblazer trailblazer)
            {
                var sql = "UPDATE Trailblazers SET Description = @Description WHERE Id = @Id;";


                using (var con = _context.CreateConnection())
                {
                    return await con.ExecuteAsync(sql, new { trailblazer.Description, trailblazer.Id }) > 0;
                }
            }
            public Task<bool> DeleteTrailblazer(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
