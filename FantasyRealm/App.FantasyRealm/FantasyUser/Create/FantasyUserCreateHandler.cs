
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
        //inject RabbitMQ Publisher pocessor here
        private IRabbitMqPublisher RabbitMqPublisher { get; set; }
        private CancellationToken CancellationToken { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        public FantasyUserCreateHandler(FantasyRealmDBContext fantasyRealmDBContext, IRabbitMqPublisher rabbitMqPublisher) : base(fantasyRealmDBContext)
        {
            RabbitMqPublisher = rabbitMqPublisher;

            CancellationTokenSource = new CancellationTokenSource();

            CancellationToken = CancellationTokenSource.Token;
        }

        public async Task<CommandResponse> Handle(FantasyUserCreateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyRealmDBContext.FantasyUsers.AnyAsync(fu => fu.Email == request.Email.Trim(), cancellationToken))
            {
                return (CommandResponse)Error($"A user already Exists with the email {request.Email}");
            }

            Domain.FantasyUser fantasyUser = new Domain.FantasyUser()
            {
                Password = request.Password.Trim(), //use encryption if possible
                ProfilePicturePath = request.ProfilePicturePath,
                Surname = request.Surname.Trim(),
                Name = request.Name.Trim(),
                Username = request.Username.Trim(),
                DateOfBirth = DateTime.Parse(request.DateOfBirth.ToString()),
                Email = request.Email.Trim(),

            };

            fantasyRealmDBContext.FantasyUsers.Add(fantasyUser);

            await fantasyRealmDBContext.SaveChangesAsync(cancellationToken);

            //queuing the object for later use by the consumer/processor
            RabbitMqDataPackage rabbitMqProcessorPackage = await RabbitMqPublisher.EstablishConnectionOnQueue(FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME);
            await RabbitMqPublisher.PublishMessage(rabbitMqProcessorPackage.Channel, FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME, fantasyUser, CancellationToken);

            return (CommandResponse)Success($"{request.ToString()} successfully created in the database!", fantasyUser.Id);
        }
    }
}
