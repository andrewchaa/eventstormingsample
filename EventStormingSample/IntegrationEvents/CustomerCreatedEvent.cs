using System;
using MediatR;

namespace EventStormingSample.IntegrationEvents
{
    public class CustomerCreatedEvent : IRequest
    {
        public Guid CustomerId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HouseNoOrName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}