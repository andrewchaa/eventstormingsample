using System;
using System.Threading;
using System.Threading.Tasks;
using EventStormingSample.Commands;
using EventStormingSample.DomainEvents;
using EventStormingSample.IntegrationEvents;
using MediatR;

namespace EventStormingSample.Handlers
{
    public class CustomerCreatedHandler : INotificationHandler<CustomerCreated>
    {
        private readonly IMediator _mediator;

        public CustomerCreatedHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        public async Task Handle(CustomerCreated @event, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RaiseCustomerCreatedEventCommand(@event.Customer));
            
            await _mediator.Send(new CheckCustomerIdentityCommand(@event.Customer));
        }
    }
}