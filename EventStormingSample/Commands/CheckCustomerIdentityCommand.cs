using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;
using MediatR;

namespace EventStormingSample.Commands
{
    public class CheckCustomerIdentityCommand : IRequest<OpResult<Unit>>
    {
        public Customer Customer { get; }

        public CheckCustomerIdentityCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}