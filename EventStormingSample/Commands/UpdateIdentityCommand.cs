using EventStormingSample.Domains;
using EventStormingSample.Infrastructure;
using MediatR;

namespace EventStormingSample.Commands
{
    public class UpdateIdentityCommand : IRequest<OpResult>
    {
        public CustomerIdentity Identity { get; }

        public UpdateIdentityCommand(CustomerIdentity identity)
        {
            Identity = identity;
        }
    }
}