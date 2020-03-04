using System;
using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
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
            await _repository.Create(command.Customer);
            await _mediator.Send(new CustomerCreated(command.Customer));
            
            return new OpResult<Id<Customer>>(command.Customer.CustomerId);
        }
    }

    public class CustomerCreated : INotification
    {
        public Customer Customer { get; }

        public CustomerCreated(Customer customer)
        {
            Customer = customer;
        }
    }
}