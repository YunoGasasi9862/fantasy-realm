

using App.FantasyUser.Domain;
using App.FantasyUser.FantasyUser.Contants;
using App.FantasyUser.Features;
using Core.App.Domain;
using Core.App.Features;
using Core.App.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.FantasyUser.FantasyUser.Create
{
    public class FantasyUserCreateHandler : FantasyUserDbHandler, IRequestHandler<FantasyUserCreateRequest, CommandResponse>
    {
        //inject RabbitMQ Publisher pocessor here
        private IRabbitMqPublisher RabbitMqPublisher { get; set; }
        private CancellationToken CancellationToken { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }
        public FantasyUserCreateHandler(FantasyUserDbContext fantasyUserDbContext, IRabbitMqPublisher rabbitMqPublisher) : base(fantasyUserDbContext)
        {
            RabbitMqPublisher = rabbitMqPublisher;

            CancellationTokenSource = new CancellationTokenSource();

            CancellationToken = CancellationTokenSource.Token;
        }

        public async Task<CommandResponse> Handle(FantasyUserCreateRequest request, CancellationToken cancellationToken)
        {
            if (await fantasyUserDbContext.FantasyUsers.AnyAsync(fu => fu.Email == request.Email.Trim(), cancellationToken))
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

            fantasyUserDbContext.FantasyUsers.Add(fantasyUser);

            await fantasyUserDbContext.SaveChangesAsync(cancellationToken);

            //queuing the object for later use by the consumer/processor
            RabbitMqDataPackage rabbitMqProcessorPackage = await RabbitMqPublisher.EstablishConnectionOnQueue(FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME);
            await RabbitMqPublisher.PublishMessage(rabbitMqProcessorPackage.Channel, FantasyUserConstants.CREATE_USER_NOTIFICAITON_QUEUE_NAME, fantasyUser, CancellationToken);

            return (CommandResponse)Success($"{request.ToString()} successfully created in the database!", fantasyUser.Id);
        }
    }
}
