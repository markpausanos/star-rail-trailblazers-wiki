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
        public async Task<int> CreateTrace(Trace trace)
        {
            var sql = "INSERT INTO Traces (Name, Description, Image) VALUES (@Name, @Description, @Image); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new { trace.Name, trace.Description, trace.Image });
            }
        }

        public async Task<IEnumerable<Trace>> GetAllTraces()
        {
            var sql = @"SELECT tr.*, t.*
                FROM Trace tr
                LEFT JOIN Trailblazer t ON tr.TrailblazerId = t.Id
                WHERE tr.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var traceDict = new Dictionary<int, Trace>();
                return await con.QueryAsync<Trace, Trailblazer, Trace>(sql, (tr, t) =>
                {
                    if (!traceDict.TryGetValue(tr.Id, out var trace))
                    {
                        trace = tr;
                        trace.Trailblazer = t;
                        traceDict.Add(tr.Id, trace);
                    }
                    else if (trace.Trailblazer == null)
                    {
                        trace.Trailblazer = t;
                    }

                    return trace;
                }, splitOn: "Id");
            }
        }

        public async Task<IEnumerable<Trace>> GetTracesByTrailblazerId(int trailblazerId)
        {
            var sql = "SELECT tr.*, t.* " +
                      "FROM Trace tr " +
                      "LEFT JOIN Trailblazer t ON tr.TrailblazerId = t.Id " +
                      "WHERE tr.TrailblazerId = @TrailblazerId AND tr.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var traceDict = new Dictionary<int, Trace>();

                return await con.QueryAsync<Trace, Trailblazer, Trace>(sql, (tr, t) =>
                {
                    if (!traceDict.TryGetValue(tr.Id, out var trace))
                    {
                        trace = tr;
                        trace.Trailblazer = t;
                        traceDict.Add(tr.Id, trace);
                    }
                    else if (trace.Trailblazer == null)
                    {
                        trace.Trailblazer = t;
                    }

                    return trace;
                }, new { TrailblazerId = trailblazerId }, splitOn: "Id");
            }
        }

        public async Task<Trace?> GetTraceById(int id)
        {
            var sql = @"SELECT tr.*, t.*
                FROM Trace tr
                LEFT JOIN Trailblazer t ON tr.TrailblazerId = t.Id
                WHERE tr.IsDeleted = 0 AND e.Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                var traceDict = new Dictionary<int, Trace>();
                var traces = await con.QueryAsync<Trace, Trailblazer, Trace>(
                    sql,
                    (tr, t) =>
                    {
                        if (!traceDict.TryGetValue(tr.Id, out var trace))
                        {
                            trace = tr;
                            trace.Trailblazer = t;
                            traceDict.Add(tr.Id, trace);
                        }
                        else if (trace.Trailblazer == null)
                        {
                            trace.Trailblazer = t;
                        }
                        return trace;
                    },
                new { id },
                splitOn: "Id");

                return traces.FirstOrDefault();
            }
        }

        public async Task<bool> UpdateTrace(Trace trace)
        {
            var sql = "UPDATE Trace SET Name = @Name, " +
                "Description = @Description, Image = @Image, Order = @Order WHERE Id = @Id;";


            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new
                {
                    trace.Name,
                    trace.Description,
                    trace.Image,
                    trace.Order,
                    trace.Id
                }) > 0;
            }
        }
        public async Task<bool> DeleteTrace(int id)
        {
            var sql = "UPDATE Trace SET IsDeleted = 1 WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }

    }
}
