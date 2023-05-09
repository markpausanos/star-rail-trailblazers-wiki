using Dapper;
using trailblazers_api.Context;
using trailblazers_api.Models;

namespace trailblazers_api.Repositories.Skills
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DapperContext _context;

        public SkillRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSkill(Skill skill)
        {
            var sql = "INSERT INTO Skill (Title, Name, Description, Image, Type, TrailblazerId) " +
                      "VALUES (@Title, @Name, @Description, @Image, @Type, @TrailblazerId);" +
                      "SELECT SCOPE_IDENTITY();";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteScalarAsync<int>(sql, new
                {
                    skill.Title,
                    skill.Name,
                    skill.Description,
                    skill.Image,
                    skill.Type,
                    TrailblazerId = skill.Trailblazer?.Id
                });
            }
        }

        public async Task<IEnumerable<Skill>> GetAllSkills()
        {
            var sql = @"SELECT s.*, t.*
                FROM Skill s
                LEFT JOIN Trailblazer t ON s.TrailblazerId = t.Id
                WHERE s.IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                var skillDict = new Dictionary<int, Skill>();
                return await con.QueryAsync<Skill, Trailblazer, Skill>(sql, (s, t) =>
                {
                    if (!skillDict.TryGetValue(s.Id, out var skill))
                    {
                        skill = s;
                        skill.Trailblazer = t;
                        skillDict.Add(s.Id, skill);
                    }
                    else if (skill.Trailblazer == null)
                    {
                        skill.Trailblazer = t;
                    }

                    return skill;
                }, splitOn: "Id");
            }
        }

        public async Task<IEnumerable<Skill>> GetSkillsByTrailblazerId(int trailblazerId)
        {
            var sql = @"SELECT s.*, t.*
                FROM Skill s
                LEFT JOIN Trailblazer t ON s.TrailblazerId = t.Id
                WHERE s.IsDeleted = 0 AND s.TrailblazerId = @TrailblazerId;";

            using (var con = _context.CreateConnection())
            {
                var skillDict = new Dictionary<int, Skill>();
                return await con.QueryAsync<Skill, Trailblazer, Skill>(sql, (s, t) =>
                {
                    if (!skillDict.TryGetValue(s.Id, out var skill))
                    {
                        skill = s;
                        skill.Trailblazer = t;
                        skillDict.Add(s.Id, skill);
                    }
                    else if (skill.Trailblazer == null)
                    {
                        skill.Trailblazer = t;
                    }

                    return skill;
                }, new { TrailblazerId = trailblazerId }, splitOn: "Id");
            }
        }


        public async Task<Skill?> GetSkillByName(string name)
        {
            var sql = "SELECT * FROM Skill WHERE Name = @Name AND IsDeleted = 0;";

            using (var con = _context.CreateConnection())
            {
                return await con.QuerySingleOrDefaultAsync<Skill>(sql, new { name });
            }
        }

        public async Task<bool> UpdateSkill(Skill skill)
        {
            var sql = "UPDATE Skill SET Title = @Title, Name = @Name, Description = @Description, " +
                      "Image = @Image, Type = @Type, TrailblazerId = @TrailblazerId WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new
                {
                    skill.Title,
                    skill.Name,
                    skill.Description,
                    skill.Image,
                    skill.Type,
                    TrailblazerId = skill.Trailblazer?.Id,
                    skill.Id
                }) > 0;
            }
        }

        public async Task<bool> DeleteSkill(int id)
        {
            var sql = "UPDATE Skill SET IsDeleted = 1 WHERE Id = @Id;";

            using (var con = _context.CreateConnection())
            {
                return await con.ExecuteAsync(sql, new { id }) > 0;
            }
        }
    }
}
