using System.Threading.Tasks;
using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Repositories
{
    public interface ICustomerReposiory
    {
        Task<Id<Customer>> Create(Customer customer);
    }
}