using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.Infrastructure;
using EventStormingSample.Repositories;
using MediatR;

namespace EventStormingSample.Handlers
{
    public class UpdateIdentityCommandHandler : IRequestHandler<UpdateIdentityCommand, OpResult>
    {
        private readonly IIdentityRepository _repository;
        private readonly IMediator _mediator;

        public UpdateIdentityCommandHandler(IIdentityRepository repository, 
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        
        public async Task<OpResult> Handle(UpdateIdentityCommand command, CancellationToken cancellationToken)
        {
            await _repository.Update(command.Identity);
            
            return new OpResult();
        }
    }
}