using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace API.FantasyRealm.Controllers
{
    [ApiController]
    public class PersonalityTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
    }
}
