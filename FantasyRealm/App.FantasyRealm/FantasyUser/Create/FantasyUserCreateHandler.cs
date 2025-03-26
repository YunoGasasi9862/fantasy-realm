
using App.FantasyRealm.Domain;
using App.FantasyRealm.FantasyUser.Contants;
using App.FantasyRealm.Features;
using Core.App.Domain;
using Core.App.Features;
using Core.App.Interfaces;
using MediatR;
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
            RabbitMqProcessorPackage rabbitMqProcessorPackage = await RabbitMqProcessor.EstablishConnectionOnQueue(FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME);

            //rum the processor - also change the type later, for now its string
            await RabbitMqProcessor.ProcessQueue<string>(rabbitMqProcessorPackage.Channel, FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME);

            //update the messages
            return (CommandResponse)Success("Successful", request.Id);
        }
    }
}
