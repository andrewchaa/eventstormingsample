using System;
using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.Infrastructure;
using MediatR;

namespace EventStormingSample.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, OpResult<Guid>>
    {
        public CreateCustomerCommandHandler()
        {
            
        }
        
        public async Task<OpResult<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            return new OpResult<Guid>(Guid.NewGuid());
            
            
        }
    }
}