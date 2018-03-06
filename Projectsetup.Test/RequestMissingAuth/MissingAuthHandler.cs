using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Projectsetup.Test.RequestMissingAuth
{
    public class MissingAuthHandler : IRequestHandler<MissingAuthRequest, MissingAuthResponse>
    {
        public Task<MissingAuthResponse> Handle(MissingAuthRequest request, CancellationToken cancellationToken)
        {
            var missingAuthResult = new MissingAuthResponse(request);
            
            return Task.FromResult(missingAuthResult);
        }
    }
}
