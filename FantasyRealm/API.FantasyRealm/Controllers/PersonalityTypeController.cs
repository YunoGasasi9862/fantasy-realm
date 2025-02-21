using App.FantasyRealm.PersonalityType.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API.FantasyRealm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalityTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonalityTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _mediator.Send(new PersonalityTypeQueryRequest());
            Debug.WriteLine(response);
            return Ok(response);
        }

        [HttpPost]
        public Task<IActionResult> Post()
        {
            return null;
        }


        [HttpPut]
        public Task<IActionResult> Put()
        {
            return null;
        }


        [HttpDelete]
        public Task<IActionResult> Delete()
        {
            return null;
        }
    }
}
