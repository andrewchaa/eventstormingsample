using System.Collections.Generic;
using System.Linq;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Domains
{
    public class CustomerContact
    {
        public string Mobile { get; }
        public string Email { get; }

        private CustomerContact(string mobile, string email)
        {
            Mobile = mobile;
            Email = email;
        }

        public static OpResult<CustomerContact> Create(string mobile,
            string email)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(mobile)) errors.Add($"{nameof(mobile)} cannot be empty");
            if (string.IsNullOrEmpty(email)) errors.Add($"{nameof(email)} cannot be empty");

            return errors.Any() 
                ? new OpResult<CustomerContact>(errors) 
                : new OpResult<CustomerContact>(new CustomerContact(mobile, email));
        }
    }
}