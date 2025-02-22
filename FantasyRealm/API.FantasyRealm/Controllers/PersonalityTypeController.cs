using App.FantasyRealm.PersonalityType.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            IQueryable<PersonalityTypeQueryResponse> personalityTypeQueryResponseIQ = await _mediator.Send(new PersonalityTypeQueryRequest());
            List<PersonalityTypeQueryResponse> personalityTypeQueryResponseList = personalityTypeQueryResponseIQ.ToList();

            if (personalityTypeQueryResponseList.Count > 0)
            {
                return Ok(personalityTypeQueryResponseList);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            IQueryable<PersonalityTypeQueryResponse> personalityTypeQueryResponseIQ = await _mediator.Send(new PersonalityTypeQueryRequest());
            PersonalityTypeQueryResponse personalityTypeQuery = await personalityTypeQueryResponseIQ.SingleOrDefaultAsync(pt => pt.Id == id);

            if (personalityTypeQueryResponseIQ == null)
            {
                return NotFound();
            }

            return Ok(personalityTypeQuery);
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
