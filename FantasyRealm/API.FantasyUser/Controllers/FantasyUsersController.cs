using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Core.App.Features;
using App.FantasyUser.FantasyUser.Query;
using App.FantasyUser.FantasyUser.Create;
using App.FantasyUser.FantasyUser.Delete;
using App.FantasyUser.FantasyUser.Update;

//Generated from Custom Template.
namespace API.FantasyUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FantasyUsersController : ControllerBase
    {
        private readonly ILogger<FantasyUsersController> _logger;
        private readonly IMediator _mediator;

        public FantasyUsersController(ILogger<FantasyUsersController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // GET: api/FantasyUsers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Send(new FantasyUserQueryRequest());
                var list = await response.ToListAsync();
                if (list.Any())
                    return Ok(list);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUsersGet Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUsersGet.")); 
            }
        }

        // GET: api/FantasyUsers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _mediator.Send(new FantasyUserQueryRequest());
                var item = await response.SingleOrDefaultAsync(r => r.Id == id);
                if (item is not null)
                    return Ok(item);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUsersGetById Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUsersGetById.")); 
            }
        }

		// POST: api/FantasyUsers
        [HttpPost]
        public async Task<IActionResult> Post(FantasyUserCreateRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(request);
                    if (response.IsSuccessful)
                    {
                        //return CreatedAtAction(nameof(Get), new { id = response.Id }, response);
                        return Ok(response);
                    }
                    ModelState.AddModelError("FantasyUsersPost", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUsersPost Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUsersPost.")); 
            }
        }

        // PUT: api/FantasyUsers
        [HttpPut]
        public async Task<IActionResult> Put(FantasyUserUpdateRequest request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await _mediator.Send(request);
                    if (response.IsSuccessful)
                    {
                        //return NoContent();
                        return Ok(response);
                    }
                    ModelState.AddModelError("FantasyUsersPut", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUsersPut Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUsersPut.")); 
            }
        }

        // DELETE: api/FantasyUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _mediator.Send(new FantasyUserDeleteRequest() { Id = id });
                if (response.IsSuccessful)
                {
                    //return NoContent();
                    return Ok(response);
                }
                ModelState.AddModelError("FantasyUsersDelete", response.Message);
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUsersDelete Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUsersDelete.")); 
            }
        }
	}
}
