using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.Infrastructure;
using EventStormingSample.Repositories;
using MediatR;

namespace EventStormingSample.Handlers
{
    public class CheckCustomerIdentityCommandHandler : IRequestHandler<CheckCustomerIdentityCommand,
        OpResult>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly Mediator _mediator;

        public CheckCustomerIdentityCommandHandler(IIdentityRepository identityRepository, 
            Mediator mediator)
        {
            _identityRepository = identityRepository;
            _mediator = mediator;
        }
        
        public async Task<OpResult> Handle(CheckCustomerIdentityCommand command, 
            CancellationToken cancellationToken)
        {
            var identityResult = await _identityRepository.GetIdentity(command.Customer);
            if (identityResult.Status == OpStatus.NotFound)
            {
                await _mediator.Send(new CreateIdentityCommand(command.Customer));
            }
            else
            {
                var identity = identityResult.Value;
                identity.AddCustomer(command.Customer);
                
                await _mediator.Send(new UpdateIdentityCommand(identity));
            }
            
            return new OpResult();
        }
    }
}