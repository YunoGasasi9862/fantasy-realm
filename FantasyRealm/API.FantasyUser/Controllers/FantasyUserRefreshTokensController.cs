#nullable disable
using Microsoft.AspNetCore.Mvc;
using MediatR;
using App.FantasyUser.Authorization.FantasyRealmRefreshToken.Create;
using Core.App.Features;
using Microsoft.AspNetCore.Authorization;
using App.FantasyUser.Authorization.FantasyRealmAccessToken.Create;

//Generated from Custom Template.
namespace API.FantasyUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FantasyUserAccessTokenController : ControllerBase
    {
        private readonly ILogger<FantasyUserAccessTokenController> _logger;
        private readonly IMediator _mediator;

        public FantasyUserAccessTokenController(ILogger<FantasyUserAccessTokenController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        // POST: api/FantasyUserAccessToken
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(FantasyUserAccessTokenRequest request)
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
                    ModelState.AddModelError("FantasyUserAccessTokenPost", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserAccessTokenPost Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserRefreshTokensPost.")); 
            }
        }

        // PUT: api/FantasyUserAccessToken
        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> Put(FantasyUserAccessTokenRequest request)
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
                    ModelState.AddModelError("FantasyUserAccessTokenPut", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserAccessTokenPut Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserRefreshTokensPut.")); 
            }
        }
	}
}
