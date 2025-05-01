using Core.App.Features;
using MediatR;

namespace App.FantasyUser.FantasyUserRole.Update
{
    public class FantasyUserRoleUpdateRequest: CommandRequest, IRequest<CommandResponse>
    {
        public FantasyUserRoleUpdateRequest() { }

        public string Name { get; set; }

        public static Domain.FantasyUserRole Copy(FantasyUserRoleUpdateRequest fantasyUserRoleUpdateRequest, Domain.FantasyUserRole fantasyUserRole)
        {
            fantasyUserRole.Name = fantasyUserRoleUpdateRequest.Name.Trim();
            fantasyUserRole.Id = fantasyUserRoleUpdateRequest.Id;

            return fantasyUserRole;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name},";
        }
    }
}
