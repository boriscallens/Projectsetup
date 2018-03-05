using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Projectsetup.Test.RequestMissingAuth
{
    public class MissingAuthHandler : IRequestHandler<MissingAuthRequest, MissingAuthResult>
    {
        public Task<MissingAuthResult> Handle(MissingAuthRequest request, CancellationToken cancellationToken)
        {
            var missingAuthResult = new MissingAuthResult
            {
                AuthenticationResult = request.AuthenticationResult
            };

            return Task.FromResult(missingAuthResult);
        }
    }
}
