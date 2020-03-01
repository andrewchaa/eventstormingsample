namespace EventStormingSample.Requests
{
    public class CreateCustomerRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HouseNoName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Mobile { get; set; } 
        public string Email { get; set; }
    }
}