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
            var sql = @"INSERT INTO Trailblazer (Name, Image, Rarity, BaseHp, BaseAtk, BaseDef, BaseSpeed, ElementId, PathSRId) 
            VALUES (@Name, @Image, @Rarity, @BaseHp, @BaseAtk, @BaseDef, @BaseSpeed, @ElementId, @PathSRId); 
            SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql,
                    new
                    {
                        trailblazer.Name,
                        trailblazer.Image,
                        trailblazer.Rarity,
                        trailblazer.BaseHp,
                        trailblazer.BaseAtk,
                        trailblazer.BaseDef,
                        trailblazer.BaseSpeed,
                        ElementId = trailblazer.Element?.Id,
                        PathSRId = trailblazer.PathSR?.Id
                    });
            }
        }

        public async Task<IEnumerable<Trailblazer>> GetAllTrailblazers()
        {
            var sql = @"
                SELECT t.*, e.*, p.*, ed.*, tr.*, s.* 
                FROM Trailblazer t 
                LEFT JOIN Element e ON e.Id = t.ElementId
                LEFT JOIN PathSR p ON p.Id = t.PathSRId
                LEFT JOIN Eidolon ed ON ed.TrailblazerId = t.Id
                LEFT JOIN Trace tr ON tr.TrailblazerId = t.Id
                LEFT JOIN Skill s ON s.TrailblazerId = t.Id
                WHERE t.IsDeleted = 0";

            using (var con = _context.CreateConnection())
            {
                var trailblazerDict = new Dictionary<int, Trailblazer>();
                var result = await con.QueryAsync<Trailblazer, Element, PathSR, Eidolon, Trace, Skill, Trailblazer>(
                    sql,
                    (trailblazer, element, pathSR, eidolon, trace, skill) =>
                    {
                        if (!trailblazerDict.TryGetValue(trailblazer.Id, out var currentTrailblazer))
                        {
                            currentTrailblazer = trailblazer;
                            trailblazerDict.Add(currentTrailblazer.Id, currentTrailblazer);
                        }

                        currentTrailblazer.Element = element;
                        currentTrailblazer.PathSR = pathSR;

                        if (eidolon != null)
                        {
                            currentTrailblazer.Eidolons.Add(eidolon);
                            currentTrailblazer.Eidolons = currentTrailblazer.Eidolons.OrderBy(al => al.Id).GroupBy(eidolon => eidolon.Id).Select(eidolon => eidolon.First()).ToList();
                        }

                        if (trace != null)
                        {
                            currentTrailblazer.Traces.Add(trace);
                            currentTrailblazer.Traces = currentTrailblazer.Traces.OrderBy(al => al.Id).GroupBy(trace => trace.Id).Select(trace => trace.First()).ToList();
                        }

                        if (skill != null)
                        {
                            currentTrailblazer.Skills.Add(skill);
                            currentTrailblazer.Skills.OrderBy(al => al.Id).GroupBy(skill => skill.Id).Select(skill => skill.First()).ToList();
                        }

                        return currentTrailblazer;
                    }
                );

                return result.Distinct().ToList();
            }
        }

        public async Task<Trailblazer?> GetTrailblazerById(int id)
        {
            var sql = @"
                SELECT t.*, e.*, p.*, ed.*, tr.*, s.* 
                FROM Trailblazer t 
                LEFT JOIN Element e ON e.Id = t.ElementId
                LEFT JOIN PathSR p ON p.Id = t.PathSRId
                LEFT JOIN Eidolon ed ON ed.TrailblazerId = t.Id
                LEFT JOIN Trace tr ON tr.TrailblazerId = t.Id
                LEFT JOIN Skill s ON s.TrailblazerId = t.Id
                WHERE t.IsDeleted = 0 AND t.Id = @id";

            using (var con = _context.CreateConnection())
            {
                var trailblazerDict = new Dictionary<int, Trailblazer>();
                var result = await con.QueryAsync<Trailblazer, Element, PathSR, Eidolon, Trace, Skill, Trailblazer>(
                    sql,
                    (trailblazer, element, pathSR, eidolon, trace, skill) =>
                    {
                        if (!trailblazerDict.TryGetValue(trailblazer.Id, out var currentTrailblazer))
                        {
                            currentTrailblazer = trailblazer;
                            trailblazerDict.Add(currentTrailblazer.Id, currentTrailblazer);
                        }

                        currentTrailblazer.Element = element;
                        currentTrailblazer.PathSR = pathSR;

                        if (eidolon != null)
                        {
                            currentTrailblazer.Eidolons.Add(eidolon);
                            currentTrailblazer.Eidolons = currentTrailblazer.Eidolons.OrderBy(al => al.Id).GroupBy(eidolon => eidolon.Id).Select(eidolon => eidolon.First()).ToList();
                        }

                        if (trace != null)
                        {
                            currentTrailblazer.Traces.Add(trace);
                            currentTrailblazer.Traces = currentTrailblazer.Traces.OrderBy(al => al.Id).GroupBy(trace => trace.Id).Select(trace => trace.First()).ToList();
                        }

                        if (skill != null)
                        {
                            currentTrailblazer.Skills.Add(skill);
                            currentTrailblazer.Skills.OrderBy(al => al.Id).GroupBy(skill => skill.Id).Select(skill => skill.First()).ToList();
                        }

                        return currentTrailblazer;
                    },
                    new { id });

                return result.Distinct().FirstOrDefault();
            }
        }

        public async Task<bool> UpdateTrailblazer(Trailblazer trailblazer)
        {
            var sql = @"
                    UPDATE Trailblazer
                    SET Name = @Name,
                        Image = @Image,
                        BaseHp = @BaseHp,
                        BaseAtk = @BaseAtk,
                        BaseDef = @BaseDef,
                        BaseSpeed = @BaseSpeed
                    WHERE Id = @Id";

            using (var con = _context.CreateConnection())
            {
                var affectedRows = await con.ExecuteAsync(sql, trailblazer);

                return affectedRows > 0;
            }
        }
    }
}
