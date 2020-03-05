using EventStormingSample.Domains;
using MediatR;

namespace EventStormingSample.Commands
{
    public class UpdateIdentityCommand : IRequest
    {
        public Customer Customer { get; }

        public UpdateIdentityCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}