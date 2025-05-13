#nullable disable
using Microsoft.AspNetCore.Mvc;
using MediatR;
using App.FantasyUser.Authorization.FantasyRealmRefreshToken.Create;
using Core.App.Features;
using Microsoft.AspNetCore.Authorization;

//Generated from Custom Template.
namespace API.FantasyUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FantasyUserRefreshTokensController : ControllerBase
    {
        private readonly ILogger<FantasyUserRefreshTokensController> _logger;
        private readonly IMediator _mediator;

        public FantasyUserRefreshTokensController(ILogger<FantasyUserRefreshTokensController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

		// POST: api/FantasyUserRefreshTokens
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post(FantasyUserRefreshTokenRequest request)
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
                    ModelState.AddModelError("FantasyUserRefreshTokensPost", response.Message);
                }
                return BadRequest(new CommandResponse(false, string.Join("|", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage))));
            }
            catch (Exception exception)
            {
                _logger.LogError("FantasyUserRefreshTokensPost Exception: " + exception.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new CommandResponse(false, "An exception occured during FantasyUserRefreshTokensPost.")); 
            }
        }
    }
}
