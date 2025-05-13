using App.FantasyRealm.FantasyUserPersonalityAssociation.Create;
using App.FantasyRealm.FantasyUserPersonalityAssociation.Delete;
using App.FantasyRealm.FantasyUserPersonalityAssociation.Query;
using App.FantasyRealm.FantasyUserPersonalityAssociation.Update;
using Core.App.Features;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.FantasyRealm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FantasyUserPersonalityAssociationController : Controller
    {        
        private readonly ILogger<FantasyUserPersonalityAssociationController> _logger;
        private readonly IMediator _mediator;

        public FantasyUserPersonalityAssociationController(ILogger<FantasyUserPersonalityAssociationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        //GET: api/PersonalityAnswer
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = await _mediator.Send(new FantasyUserPersonalityAssociationQueryRequest());
                var list = await response.ToListAsync();
                if (list.Any())
                    return Ok(list);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserPersonalityAssociationGet Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserPersonalityAssociationGet."));
            }
        }

        //GET: api/FantasyUserPersonalityAssociation/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _mediator.Send(new FantasyUserPersonalityAssociationQueryRequest());
                var item = await response.SingleOrDefaultAsync(r => r.Id == id);
                if (item is not null)
                    return Ok(item);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserPersonalityAssociationGetById Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserPersonalityAssociationGetById."));
            }
        }

        // POST: api/FantasyUserPersonalityAssociation
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(FantasyUserPersonalityAssociationCreateRequest request)
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
                    ModelState.AddModelError("FantasyUserPersonalityAssociationPost", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserPersonalityAssociationPost Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserPersonalityAssociationPost."));
            }
        }

        // POST: api/FantasyUserPersonalityAssociation/calculate
        [HttpPost("calculate")]
        public async Task<IActionResult> CalculatePersonality([FromBody] CalculateUserPersonalityQuery request)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _mediator.Send(request);
                    return Ok(result);
                }
                return BadRequest(new CommandResponse(false, "Invalid model state"));
            }
            catch (Exception exception)
            {
                _logger.LogError("CalculatePersonality Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occurred during personality calculation."));
            }
        }


        // PUT: api/FantasyUserPersonalityAssociation
        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(FantasyUserPersonalityAssociationUpdateRequest request)
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
                    ModelState.AddModelError("FantasyUserPersonalityAssociationPut", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserPersonalityAssociationPut Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserPersonalityAssociationPut."));
            }
        }

        // DELETE: api/FantasyUserPersonalityAssociation/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _mediator.Send(new FantasyUserPersonalityAssociationDeleteRequest() { Id = id });
                if (response.IsSuccessful)
                {
                    //return NoContent();
                    return Ok(response);
                }
                ModelState.AddModelError("FantasyUserPersonalityAssociationDelete", response.Message);
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserPersonalityAssociationDelete Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserPersonalityAssociationDelete."));
            }
        }

    }
}
