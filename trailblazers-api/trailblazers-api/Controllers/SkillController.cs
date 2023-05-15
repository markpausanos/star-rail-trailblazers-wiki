using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IO;
using trailblazers_api.DTOs.Paths;
using trailblazers_api.DTOs.Skills;
using trailblazers_api.Services.Skills;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly ILogger<ISkillService> _logger;
        private readonly ISkillService _service;

        public SkillController(ILogger<ISkillService> logger, ISkillService service)
        {
            _logger = logger;
            _service = service;
        }

        /// <summary>
        /// Creates a new Skill.
        /// </summary>
        /// <param name="skill">The new Skill to create.</param>
        /// <returns>The ID of the newly created Skill.</returns>
        /// <remarks>
        /// Sample request:
        ///
        /// POST /api/Skills
        /// {
        /// "title": "Sample Title",
        /// "name": "Sample Name",
        /// "description": "sample text",
        /// "image": "https://example.com/sample.png",
        /// "type": "sample skill type",
        /// "trailblazerid": 3
        /// }
        ///
        /// </remarks>
        /// <response code="201">The Skill was successfully created.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPost(Name = "CreateSkill")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateSkill(SkillCreationDto skill)
        {
            try
            {
                var newSkillId = await _service.CreateSkill(skill);
                var newSkill = await _service.GetSkillById(newSkillId);

                return CreatedAtRoute("GetSkillById", new { id = newSkill.Id }, newSkill);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the Skill.");
            }
        }

        /// <summary>
        /// Gets all Skills in the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Skills.</returns>
        /// <response code="200">The Skills were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet(Name = "GetAllSkills")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<SkillDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllSkills()
        {
            try
            {
                var skills = await _service.GetAllSkills();

                if (skills.IsNullOrEmpty())
                {
                    return NoContent();
                }
                return Ok(skills);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Skills.");
            }
        }

        /// <summary>
        /// Gets all Skills in the database associated with a Trailblazer.
        /// </summary>
        /// <param name="trailblazerId">The ID of the Trailblazer whose Skills to retrieve.</param>
        /// <returns>An IEnumerable of Skill objects or an empty collection if no Skills are found.</returns>
        /// <response code="200">The Skills were successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{trailblazerid}", Name = "GetAllSkillsByTrailblazerId")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<SkillDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSkillsByTrailblazerId(int trailblazerId)
        {
            try
            {
                var skill = await _service.GetSkillsByTrailblazerId(trailblazerId);

                if (skill == null)
                {
                    return NoContent();
                }
                return Ok(skill);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Skill.");
            }
        }

        /// <summary>
        /// Gets Skill in the database with the provided ID.
        /// </summary>
        /// <param name="id">The ID of the Skill</param>
        /// <returns>The retreived Skill</returns>
        /// <response code="200">The Skill was successfully retrieved.</response>
        /// <response code="204">No content.</response>
        /// <response code="400">The Skill details are invalid.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpGet("{id}", Name = "GetSkillById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(SkillDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSkillById(int id)
        {
            try
            {
                var skill = await _service.GetSkillById(id);

                if (skill == null)
                {
                    return NoContent();
                }
                return Ok(skill);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the Skill.");
            }
        }

        /// <summary>
        /// Updates a Skill in the database.
        /// </summary>
        /// <param name="updateSkill">The updated Skill object.</param>
        /// <returns>
        /// true if the update was successful; otherwise, false.
        /// </returns>
        /// <remarks>
        /// Sample request:
        ///
        /// PUT /api/Skills
        /// {
        /// "id": 2,
        /// "title": "Sample Title",
        /// "name": "Sample Name",
        /// "image": "https://example.com/sample.png",
        /// "type": "sample skill type",
        /// "trailblazerid": 3
        /// }
        /// </remarks>
        /// <response code="200">The Skill was successfully updated.</response>
        /// <response code="404">The Skill was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
        [HttpPut(Name = "UpdateSkill")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateSkill(SkillUpdateDto updateSkill)
        {
            try
            {
                int id = updateSkill.Id;
                var skill = await _service.GetSkillById(id);
                if (skill == null)
                {
                    return NotFound($"Skill with ID = {id} does not exist.");
                }

                var updatedSkill = await _service.UpdateSkill(updateSkill);
                return Ok(updatedSkill);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the Skill.");
            }
        }

        /// <summary>
        /// Deletes a Skill from the database.
        /// </summary>
        /// <param name="id">The ID of the Skill to delete.</param>
        /// <returns>
        /// true if the delete was successful; otherwise, false.
        /// </returns>
        /// <response code="200">The Skill was successfully deleted.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="404">The Skill was not found.</response>
        /// <response code="500">An internal server error occurred.</response>
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
                var path = await _service.GetSkillById(id);
                if (path == null)
                {
                    return NotFound($"Skill with ID = {id} not found.");
                }

                var isDeleted = await _service.DeleteSkill(id);
                if (isDeleted)
                {
                    return Ok("Successfully deleted.");
                }
                return BadRequest($"Skill with ID = {id} could not be deleted.");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while deleting the Skill.");
            }
        }
    }
}
