using Dapper;
using System.Data;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Lightcones
{
    public class LightconeRepository : ILightconeRepository
    {
        private readonly DapperContext _context;

        public LightconeRepository(DapperContext context)
        {
            _context = context;
        }
        public async Task<int> CreateLightcone(Lightcone lightcone)
        {
            var sql = "INSERT INTO Lightcone (Title, Name, Description, Image, Rarity, BaseHp, BaseAtk, BaseDef, PathSRId) " +
                      "VALUES (@Title, @Name, @Description, @Image, @Rarity, @BaseHp, @BaseAtk, @BaseDef, @PathSRId);" +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new
                {
                    lightcone.Title,
                    lightcone.Name,
                    lightcone.Description,
                    lightcone.Image,
                    lightcone.Rarity,
                    lightcone.BaseHp,
                    lightcone.BaseAtk,
                    lightcone.BaseDef,
                    PathSRId = lightcone.PathSR?.Id
                });
            }
        }

        public async Task<IEnumerable<Lightcone>> GetAllLightcones()
        {
            var sql = "SELECT lc.*, ps.* FROM Lightcone lc LEFT JOIN PathSR ps ON lc.PathSRId = ps.Id " +
                "WHERE lc.IsDeleted = 0 AND ps.IsDeleted = 0;";

            using (var connection = _context.CreateConnection())
            {
                var lightcones = await connection.QueryAsync<Lightcone, PathSR, Lightcone>(sql, (lightcone, pathSR) =>
                {
                    lightcone.PathSR = pathSR;
                    return lightcone;
                });

                return lightcones;
            }
        }

        public async Task<Lightcone?> GetLightconeById(int id)
        {
            var sql = "SELECT lc.*, ps.* FROM Lightcone lc LEFT JOIN PathSR ps ON lc.PathSRId = ps.Id " +
                "WHERE lc.IsDeleted = 0 AND ps.IsDeleted = 0 AND lc.Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<Lightcone, PathSR, Lightcone>(sql, (lightcone, pathSR) =>
                {
                    lightcone.PathSR = pathSR;
                    return lightcone;
                }, new { id });

                return result.SingleOrDefault();
            }
        }

        public async Task<Lightcone?> GetLightconeByName(string name)
        {
            var sql = "SELECT lc.*, ps.* FROM Lightcone lc LEFT JOIN PathSR ps ON lc.PathSRId = ps.Id " +
               "WHERE lc.IsDeleted = 0 AND ps.IsDeleted = 0 AND lc.Name = @Name;";

            using (var con = _context.CreateConnection())
            {
                var result = await con.QueryAsync<Lightcone, PathSR, Lightcone>(sql, (lightcone, pathSR) =>
                {
                    lightcone.PathSR = pathSR;
                    return lightcone;
                }, new { name });

                return result.SingleOrDefault();
            }
        }
        public async Task<bool> UpdateLightcone(Lightcone lightcone)
        {
            var sql = "UPDATE Lightcone SET Description = @Description WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { lightcone.Description, lightcone.Id }) > 0;
            }
        }
        public async Task<bool> DeleteLightcone(int id)
        {
            var spName = "[spLightcone_DeleteLightcone]";

            using (var connection = _context.CreateConnection())
            {
                return await connection.ExecuteAsync(spName,
                    new { LightconeId = id },
                    commandType: CommandType.StoredProcedure) > 0;
            }
        }

    }
}
