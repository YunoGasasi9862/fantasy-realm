using Core.App.Features;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace App.FantasyUser.FantasyUserRole.Create
{
    public class FantasyUserRoleCreateRequest: CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserRoleCreateRequest() { }

        [Required]
        public string Name { get; set; }
    }
}
