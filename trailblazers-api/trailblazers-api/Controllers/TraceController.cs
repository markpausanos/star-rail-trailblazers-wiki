using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using trailblazers_api.Dtos.Traces;
using trailblazers_api.Services.Traces;

namespace trailblazers_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TracesController : ControllerBase
    {
        private readonly ILogger<TracesController> _logger;
        private readonly ITraceService _traceService;

        public TracesController(ILogger<TracesController> logger, ITraceService service)
        {
            _logger = logger;
            _traceService = service;
        }

        /// <summary>
        /// Create a new trace.
        /// </summary>
        /// <param name="trace">The trace creation DTO.</param>
        /// <returns>The created trace.</returns>
        [HttpPost(Name = "CreateTrace")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Authorize(Roles = "A")]
        [ProducesResponseType(typeof(TraceDto), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateTrace(TraceCreationDto trace)
        {
            try
            {
                var newTrace = await _traceService.CreateTrace(trace);

                if (newTrace == null)
                {
                    return BadRequest("Trailblazer does not exist or Trace Type already exists.");
                }

                return CreatedAtRoute("GetTraceById", new { id = newTrace.Id }, newTrace);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while creating the trace.");
            }
        }

        /// <summary>
        /// Get all traces or traces filtered by trailblazer ID.
        /// </summary>
        /// <param name="trailblazerId">Optional. The trailblazer ID to filter traces by.</param>
        /// <returns>A list of traces.</returns>
        [HttpGet(Name = "GetAllTraces")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<TraceDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllTraces([FromQuery] int? trailblazerId)
        {
            try
            {
                var traces = trailblazerId == null ? await _traceService.GetAllTraces() :
                    await _traceService.GetTracesByTrailblazerId((int)trailblazerId);

                if (traces.IsNullOrEmpty())
                {
                    return NoContent();
                }

                return Ok(traces);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the traces.");
            }
        }

        /// <summary>
        /// Get a trace by ID.
        /// </summary>
        /// <param name="id">The trace ID.</param>
        /// <returns>The trace.</returns>
        [HttpGet("{id}", Name = "GetTraceById")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TraceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTraceById(int id)
        {
            try
            {
                var trace = await _traceService.GetTraceById(id);

                if (trace == null)
                {
                    return NoContent();
                }

                return Ok(trace);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while retrieving the trace.");
            }
        }
        /// <summary>
        /// Update a trace.
        /// </summary>
        /// <param name="id">The trace ID.</param>
        /// <param name="newTrace">The updated trace DTO.</param>
        /// <returns>The updated trace.</returns>
        [HttpPut(Name = "UpdateTrace")]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(TraceDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateTrace(int id, [FromBody] TraceUpdateDto newTrace)
        {
            try
            {
                var trace = await _traceService.GetTraceById(id);

                if (trace == null)
                {
                    return NotFound($"Trace with ID = {id} does not exist.");
                }

                newTrace.Name ??= trace.Name;
                newTrace.Description ??= trace.Description;
                newTrace.Image ??= trace.Image;

                if (await _traceService.UpdateTrace(id, newTrace))
                {
                    var updatedTrace = await _traceService.GetTraceById(id);

                    return Ok(updatedTrace);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the trace.");
            }
        }

        /// <summary>
        /// Delete a trace by ID.
        /// </summary>
        /// <param name="id">The trace ID.</param>
        /// <returns>A boolean indicating if the trace was successfully deleted.</returns>
        [HttpDelete("{id}", Name = "DeleteTrace")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteTrace(int id)
        {
            try
            {
                if (await _traceService.DeleteTrace(id))
                {
                    return Ok($"Successfully deleted trace with ID {id}.");
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, "An error occurred while updating the trace.");
            }
        }
    }
}
