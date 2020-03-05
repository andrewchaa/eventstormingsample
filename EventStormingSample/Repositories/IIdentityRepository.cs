using System.Threading.Tasks;
using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;

namespace EventStormingSample.Repositories
{
    public interface IIdentityRepository
    {
        Task<OpResult<CustomerIdentity>> GetIdentity(Customer customer);
        Task Update(CustomerIdentity identity);
    }
}