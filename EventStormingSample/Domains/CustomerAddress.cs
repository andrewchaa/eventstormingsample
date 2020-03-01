using System.Collections.Generic;
using System.Linq;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Domains
{
    public class CustomerAddress
    {
        public string HouseNoOrName { get; }
        public string Street { get; }
        public string City { get; }
        public string County { get; }
        public string PostCode { get; }

        public static OpResult<CustomerAddress> Create(string houseNoName, 
            string street, 
            string city, 
            string county, 
            string postCode)
        {
            var errors = new List<string>();
            if (string.IsNullOrEmpty(houseNoName)) errors.Add($"{nameof(houseNoName)} cannot be empty.");
            if (string.IsNullOrEmpty(street)) errors.Add($"{nameof(street)} cannot be empty.");
            if (string.IsNullOrEmpty(city) && string.IsNullOrEmpty(county)) 
                errors.Add($"Both {nameof(city)} and {nameof(county)} cannot be empty.");

            if (string.IsNullOrEmpty(postCode)) errors.Add($"{nameof(postCode)} cannot be empty.");


            if (errors.Any())
            {
                return new OpResult<CustomerAddress>(errors);
            }
            
            return new OpResult<CustomerAddress>(new CustomerAddress(houseNoName,
                street,
                city,
                county,
                postCode));
        }

        public CustomerAddress(string houseNoOrName, 
            string street, 
            string city, 
            string county, 
            string postCode)
        {
            HouseNoOrName = houseNoOrName;
            Street = street;
            City = city;
            County = county;
            PostCode = postCode;
        }
    }
}