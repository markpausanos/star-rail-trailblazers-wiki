using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Skills;
using trailblazers_api.Services.Skills;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ILogger<ISkillService> _logger;
        private readonly ISkillService _skillService;

        public SkillsController(ILogger<ISkillService> logger, ISkillService service)
        {
            _logger = logger;
            _skillService = service;
        }

        /// <summary>
        /// Create a new skill.
        /// </summary>
        /// <param name="skill">The skill creation DTO.</param>
        /// <returns>The created skill.</returns>
        [HttpPost(Name = "CreateSkill")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(SkillDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSkill(SkillCreationDto skill)
        {
            try
            {
                var newSkill = await _skillService.CreateSkill(skill);

                if (newSkill == null)
                {
                    return BadRequest("Trailblazer does not exist or Skill Type already exists.");
                }

                return CreatedAtRoute("GetSkillById", new { id = newSkill.Id }, newSkill);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the skill.");
            }
        }

        /// <summary>
        /// Get all skills or skills filtered by trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">Optional. The trailblazer ID to filter skills by.</param>
        /// <returns>A list of skills.</returns>
        [HttpGet(Name = "GetAllSkills")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<SkillDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSkills([FromQuery] int? trailblazerId)
        {
            try
            {
                var skills = trailblazerId == null ? await _skillService.GetAllSkills() :
                    await _skillService.GetSkillsByTrailblazerId((int)trailblazerId);

                if (skills.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(skills);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the skills.");
            }
        }

        /// <summary>
        /// Get a skill by ID.
        /// </summary>
        /// <param name="id">The skill ID.</param>
        /// <returns>The skill.</returns>
        [HttpGet("{id}", Name = "GetSkillById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SkillDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSkillById(int id)
        {
            try
            {
                var skill = await _skillService.GetSkillById(id);

                if (skill == null)
                {
                    return NoContent();
                }

                return Ok(skill);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the skill.");
            }
        }
        /// <summary>
        /// Update a skill.
        /// </summary>
        /// <param name="id">The skill ID.</param>
        /// <param name="newSkill">The updated skill DTO.</param>
        /// <returns>The updated skill.</returns>
        [HttpPut(Name = "UpdateSkill")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SkillDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSkill(int id, [FromBody] SkillUpdateDto newSkill)
        {
            try
            {
                var skill = await _skillService.GetSkillById(id);

                if (skill == null)
                {
                    return NotFound($"Skill with ID = {id} does not exist.");
                }

                newSkill.Name ??= skill.Name;
                newSkill.Description ??= skill.Description;
                newSkill.Image ??= skill.Image;

                if (await _skillService.UpdateSkill(id, newSkill))
                {
                    var updatedSkill = await _skillService.GetSkillById(id);

                    return Ok(updatedSkill);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the skill.");
            }
        }

        /// <summary>
        /// Delete a skill by ID.
        /// </summary>
        /// <param name="id">The skill ID.</param>
        /// <returns>A boolean indicating if the skill was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteSkill")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteSkill(int id)
        {
            try
            {
                if (await _skillService.DeleteSkill(id))
                {
                    return Ok($"Successfully deleted skill with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the skill.");
            }
        }
    }
}


