using System;
using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;
using MediatR;

namespace EventStormingSample.Commands
{
    public class CreateCustomerCommand : IRequest<OpResult<Id<Customer>>>
    {
        public Customer Customer { get; }

        public CreateCustomerCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}