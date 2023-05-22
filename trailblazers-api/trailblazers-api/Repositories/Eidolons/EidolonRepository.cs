using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Eidolons
{
    public class EidolonRepository : IEidolonRepository
    {
        private readonly DapperContext _context;

        public EidolonRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateEidolon(Eidolon eidolon)
        {
            var sql = "INSERT INTO Eidolons (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { eidolon.Name, eidolon.Description, eidolon.Image });
            }
        }

        public async Task<IEnumerable<Eidolon>> GetAllEidolons()
        {
            var sql = @"SELECT e.*, t.*
                FROM Eidolon e
                LEFT JOIN Trailblazer t ON e.TrailblazerId = t.Id
                WHERE e.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var eidolonDict = new Dictionary<int, Eidolon>();
                return await con.QueryAsync<Eidolon, Trailblazer, Eidolon>(sql, (e, t) =>
                {
                    if (!eidolonDict.TryGetValue(e.Id, out var eidolon))
                    {
                        eidolon = e;
                        eidolon.Trailblazer = t;
                        eidolonDict.Add(e.Id, eidolon);
                    }
                    else if (eidolon.Trailblazer == null)
                    {
                        eidolon.Trailblazer = t;
                    }

                    return eidolon;
                }, splitOn: "Id");
            }
        }

        public async Task<IEnumerable<Eidolon>> GetEidolonsByTrailblazerId(int trailblazerId)
        {
            var sql = "SELECT e.*, t.* " +
                      "FROM Eidolon e " +
                      "LEFT JOIN Trailblazer t ON e.TrailblazerId = t.Id " +
                      "WHERE e.TrailblazerId = @TrailblazerId AND e.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var eidolonDict = new Dictionary<int, Eidolon>();

                return await con.QueryAsync<Eidolon, Trailblazer, Eidolon>(sql, (e, t) =>
                {
                    if (!eidolonDict.TryGetValue(e.Id, out var eidolon))
                    {
                        eidolon = e;
                        eidolon.Trailblazer = t;
                        eidolonDict.Add(e.Id, eidolon);
                    }
                    else if (eidolon.Trailblazer == null)
                    {
                        eidolon.Trailblazer = t;
                    }

                    return eidolon;
                }, new { TrailblazerId = trailblazerId }, splitOn: "Id");
            }
        }

        public async Task<Eidolon?> GetEidolonById(int id)
        {
            var sql = @"SELECT e.*, t.*
                FROM Eidolon e
                LEFT JOIN Trailblazer t ON e.TrailblazerId = t.Id
                WHERE e.IsDeleted = 0 AND e.Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                var eidolonDict = new Dictionary<int, Eidolon>();
                var eidolons = await con.QueryAsync<Eidolon, Trailblazer, Eidolon>(
                    sql,
                    (e, t) =>
                    {
                        if (!eidolonDict.TryGetValue(e.Id, out var eidolon))
                        {
                            eidolon = e;
                            eidolon.Trailblazer = t;
                            eidolonDict.Add(e.Id, eidolon);
                        }
                        else if (eidolon.Trailblazer == null)
                        {
                            eidolon.Trailblazer = t;
                        }
                        return eidolon;
                    },
                new { id },
                splitOn: "Id");

                return eidolons.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateEidolon(Eidolon eidolon)
        {
            var sql = "UPDATE Eidolon SET Name = @Name, " +
                "Description = @Description, Image = @Image, Order = @Order WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new 
                { 
                    eidolon.Name,
                    eidolon.Description, 
                    eidolon.Image, 
                    eidolon.Order,
                    eidolon.Id
                }) > 0;
            }
        }
        public async Task<bool> DeleteEidolon(int id)
        {
            var sql = "UPDATE Eidolon SET IsDeleted = 1 WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

    }
}
