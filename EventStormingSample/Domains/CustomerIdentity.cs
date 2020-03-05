using System.Collections.Generic;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Domains
{
    public class CustomerIdentity
    {
        public Id<CustomerIdentity> IdentityId { get; }
        public IList<Customer> Customers { get; }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }
    }
}