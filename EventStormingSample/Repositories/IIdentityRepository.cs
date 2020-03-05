using System.Threading.Tasks;
using EventStormingSample.Domains;

namespace EventStormingSample.Repositories
{
    public interface IIdentityRepository
    {
        Task<bool> IdentityExists(Customer customer);
    }
}