using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Projectsetup.Test.RequestMissingAuth
{
    public class MissingAuthHandler : IRequestHandler<MissingAuthRequest, MissingAuthResult>
    {
        public Task<MissingAuthResult> Handle(MissingAuthRequest request, CancellationToken cancellationToken)
        {
            var missingAuthResult = new MissingAuthResult(request);
            
            return Task.FromResult(missingAuthResult);
        }
    }
}
