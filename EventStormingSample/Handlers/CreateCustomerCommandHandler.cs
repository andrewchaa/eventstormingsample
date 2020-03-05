using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.DomainEvents;
using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;
using EventStormingSample.Repositories;
using MediatR;

namespace EventStormingSample.Handlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, OpResult<Id<Customer>>>
    {
        private readonly ICustomerReposiory _repository;
        private readonly IMediator _mediator;

        public CreateCustomerCommandHandler(ICustomerReposiory repository, 
            IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }
        
        public async Task<OpResult<Id<Customer>>> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customerResult = await _repository.GetCustomer(command.Customer.CustomerId);
            if (customerResult.Status != OpStatus.NotFound)
            {
                return new OpResult<Id<Customer>>(customerResult.Value.CustomerId);
            }
            
            await _repository.Create(command.Customer);
            await _mediator.Publish(new CustomerCreated(command.Customer));
            
            return new OpResult<Id<Customer>>(command.Customer.CustomerId);
        }
    }
}