using EventStormingSample.Domains;
using MediatR;

namespace EventStormingSample.DomainEvents
{
    public class CustomerCreated : INotification
    {
        public Customer Customer { get; }

        public CustomerCreated(Customer customer)
        {
            Customer = customer;
        }
    }
}