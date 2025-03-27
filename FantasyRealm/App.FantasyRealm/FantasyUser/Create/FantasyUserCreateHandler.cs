
using App.FantasyRealm.Domain;
using App.FantasyRealm.FantasyUser.Contants;
using App.FantasyRealm.Features;
using Core.App.Domain;
using Core.App.Features;
using Core.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace App.FantasyRealm.FantasyUser.Create
{
    public class FantasyUserCreateHandler : FantasyRealmDBHandler, IRequestHandler<FantasyUserCreateRequest, CommandResponse>
    {
        //inject RabbitMQ Processor here
        private IRabbitMqProcessor RabbitMqProcessor { get; set; }
        public FantasyUserCreateHandler(FantasyRealmDBContext fantasyRealmDBContext, IRabbitMqProcessor rabbitMqProcessor) : base(fantasyRealmDBContext)
        {
            RabbitMqProcessor = rabbitMqProcessor;
        }

        public async Task<CommandResponse> Handle(FantasyUserCreateRequest request, CancellationToken cancellationToken)
        {
            //here create the FantasyUser and then use the RabbitMqs processor to delegate it to another API, or a class
            //that needs to do some sort of preprocessing, or executes a subsequent action

            if (await fantasyRealmDBContext.FantasyUsers.AnyAsync(fu => fu.Email == request.Email.Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"A user already Exists with the email {request.Email}");
            }

            fantasyRealmDBContext.FantasyUsers.Add(new Domain.FantasyUser()
            {
                Password = request.Password.Trim(), //use encryption if possible
                profilePicture = request.profilePicture,
                Surname = request.Surname.Trim(),
                Name = request.Name.Trim(),
                Username = request.Username.Trim(),
                DateOfBirth = DateTime.Parse(request.DateOfBirth.ToString()),
                Email = request.Email.Trim(),
            });

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);
            //once done, use rabbitMq
            RabbitMqProcessorPackage rabbitMqProcessorPackage = await RabbitMqProcessor.EstablishConnectionOnQueue(FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME);

            //rum the processor - also change the type later, for now its string
            ///await RabbitMqProcessor.ProcessQueue<string>(rabbitMqProcessorPackage.Channel, FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME);

            //update the messages
            return (CommandResponse)Success("Successful", request.Id);
        }
    }
}
