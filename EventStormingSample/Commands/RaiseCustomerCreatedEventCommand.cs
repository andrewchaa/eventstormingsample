using System;
using EventStormingSample.Domains;
using MediatR;

namespace EventStormingSample.Commands
{
    public class RaiseCustomerCreatedEventCommand : IRequest
    {
        public Customer Customer { get; }

        public RaiseCustomerCreatedEventCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}