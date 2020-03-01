using System.Collections.Generic;
using System.Linq;
using EventStormingSample.Controllers;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Domains
{
    public class CustomerName
    {
        public string Title { get; }
        public string FirstName { get; }
        public string LastName { get; }

        public static OpResult<CustomerName> Craete(string title, string firstName, string lastName)
        {
            var errors = new List<string>();
            
            if (string.IsNullOrEmpty(title)) errors.Add($"{nameof(title)} cannot be empty");
            if (string.IsNullOrEmpty(firstName)) errors.Add($"{nameof(firstName)} cannot be empty");
            if (string.IsNullOrEmpty(lastName)) errors.Add($"{nameof(lastName)} cannot be empty");
            
            return errors.Any() 
                ? new OpResult<CustomerName>(errors) 
                : new OpResult<CustomerName>(new CustomerName(title, firstName, lastName));
        }

        public CustomerName(string title, string firstName, string lastName)
        {
            Title = title;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}