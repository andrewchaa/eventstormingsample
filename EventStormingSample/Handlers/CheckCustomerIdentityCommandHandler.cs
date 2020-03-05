using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.Infrastructure;
using EventStormingSample.Repositories;
using MediatR;

namespace EventStormingSample.Handlers
{
    public class CheckCustomerIdentityCommandHandler : IRequestHandler<CheckCustomerIdentityCommand,
        OpResult<Unit>>
    {
        private readonly IIdentityRepository _identityRepository;
        private readonly Mediator _mediator;

        public CheckCustomerIdentityCommandHandler(IIdentityRepository identityRepository, 
            Mediator mediator)
        {
            _identityRepository = identityRepository;
            _mediator = mediator;
        }
        
        public async Task<OpResult<Unit>> Handle(CheckCustomerIdentityCommand command, 
            CancellationToken cancellationToken)
        {
            var identityExists = await _identityRepository.IdentityExists(command.Customer);
            if (identityExists)
            {
                await _mediator.Send(new UpdateIdentityCommand(command.Customer));
            }
            else
            {
                await _mediator.Send(new CreateIdentityCommand(command.Customer));
            }
            
            return new OpResult<Unit>(Unit.Value);
        }
    }
}