﻿
using App.FantasyRealm.Domain;
using App.FantasyRealm.Features;
using Core.App.Features;
using Core.App.Interfaces;
using Core.App.Processors;
using MediatR;

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


            //update the messages
            return (CommandResponse)Success("Successful", request.Id);
        }
    }
}
