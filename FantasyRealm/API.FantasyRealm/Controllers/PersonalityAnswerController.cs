using App.FantasyRealm.PersonalityAnswer.Create;
using App.FantasyRealm.PersonalityAnswer.Delete;
using App.FantasyRealm.PersonalityAnswer.Query;
using App.FantasyRealm.PersonalityAnswer.Update;
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
    public class PersonalityAnswerController : Controller
    {
        private readonly ILogger<PersonalityAnswerController> _logger;
        private readonly IMediator _mediator;

        public PersonalityAnswerController(ILogger<PersonalityAnswerController> logger, IMediator mediator)
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
                var response = await _mediator.Send(new PersonalityAnswerQueryRequest());
                var list = await response.ToListAsync();
                if (list.Any())
                    return Ok(list);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError("PersonalityAnswerGet Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during PersonalityAnswerGet."));
            }
        }

        //GET: api/PersonalityAnswer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = await _mediator.Send(new PersonalityAnswerQueryRequest());
                var item = await response.SingleOrDefaultAsync(r => r.Id == id);
                if (item is not null)
                    return Ok(item);
                return NoContent();
            }
            catch (Exception exception)
            {
                _logger.LogError("PersonalityAnsweGetById Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during PersonalityAnsweGetById."));
            }
        }

        // POST: api/PersonalityAnswer
        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(PersonalityAnswerCreateRequest request)
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
                    ModelState.AddModelError("PersonalityAnswerPost", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("PersonalityAnswerPost Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during PersonalityAnswerPost."));
            }
        }

        // PUT: api/PersonalityAnswer
        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(PersonalityAnswerUpdateRequest request)
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
                    ModelState.AddModelError("PersonalityAnswerPut", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("PersonalityAnswerPut Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during PersonalityAnswerPut."));
            }
        }

        // DELETE: api/PersonalityAnswer/5
        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _mediator.Send(new PersonalityAnswerDeleteRequest() { Id = id });
                if (response.IsSuccessful)
                {
                    //return NoContent();
                    return Ok(response);
                }
                ModelState.AddModelError("PersonalityAnswerDelete", response.Message);
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("PersonalityAnswerDelete Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during PersonalityAnswerDelete."));
            }
        }
    }
}
