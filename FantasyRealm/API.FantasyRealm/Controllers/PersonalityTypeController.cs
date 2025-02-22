using App.FantasyRealm.PersonalityType.Delete;
using App.FantasyRealm.PersonalityType.Query;
using App.FantasyRealm.PersonalityType.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.App.Features;
using App.FantasyRealm.PersonalityType.Create;

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
        public async Task<IActionResult> Post(PersonalityTypeCreateRequest personalityTypeCreateRequest)
        {
            if (ModelState.IsValid)
            {
                CommandResponse response = await _mediator.Send(personalityTypeCreateRequest);

                if (response.IsSuccessful)
                {
                    return Ok(response);
                }

                return BadRequest(response);
            }

            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Put(PersonalityTypeUpdateRequest request)
        {
            if (ModelState.IsValid)
            {
                CommandResponse response = await _mediator.Send(request);

                if (response.IsSuccessful)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                CommandResponse response = await _mediator.Send(new PersonalityTypeDeleteRequest() { Id = id });

                if (response.IsSuccessful)
                {
                    return Ok(response);
                }

                return BadRequest(response);
            }
            return BadRequest(ModelState);
        }
    }
}
