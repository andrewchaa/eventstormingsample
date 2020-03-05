using EventStormingSample.Domains;

namespace EventStormingSample.Commands
{
    public class CreateIdentityCommand
    {
        public Customer Customer { get; }

        public CreateIdentityCommand(Customer customer)
        {
            Customer = customer;
        }
    }
}