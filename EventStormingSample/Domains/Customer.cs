namespace EventStormingSample.Domains
{
    public class Customer
    {
        public CustomerName CustomerName { get; }
        public CustomerAddress CustomerAddress { get; }
        public CustomerContact CustomerContact { get; }

        public Customer(CustomerName customerName, 
            CustomerAddress customerAddress, 
            CustomerContact customerContact)
        {
            CustomerName = customerName;
            CustomerAddress = customerAddress;
            CustomerContact = customerContact;
        }
    }
}