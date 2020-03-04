using System;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Domains
{
    public class Customer
    {
        public Id<Customer> CustomerId { get; }
        public CustomerName CustomerName { get; }
        public CustomerAddress CustomerAddress { get; }
        public CustomerContact CustomerContact { get; }

        public Customer(Id<Customer> customerId,
            CustomerName customerName, 
            CustomerAddress customerAddress, 
            CustomerContact customerContact)
        {
            CustomerId = customerId;
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerContact = customerContact;
        }
    }
}