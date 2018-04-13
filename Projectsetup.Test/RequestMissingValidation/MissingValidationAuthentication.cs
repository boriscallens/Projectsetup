using System.Threading;
using System.Threading.Tasks;
using Projectsetup.Domain.Pipeline;
using Projectsetup.Domain.Services.Authentication;

namespace Projectsetup.Test.RequestMissingValidation
{
    public class MissingValidationAuthentication: IPipelineAuthenticationHandler<MissingValidationRequest>
    {
        public Task Process(MissingValidationRequest request, CancellationToken cancellationToken)
        {
            request.AuthenticationResult = new AuthenticationResult();
            return Task.FromResult(request);
        }
    }
}
