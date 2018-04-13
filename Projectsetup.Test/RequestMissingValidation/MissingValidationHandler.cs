using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Projectsetup.Test.RequestMissingValidation
{
    public class MissingValidationHandler : IRequestHandler<MissingValidationRequest, MissingValidationResponse>
    {
        public Task<MissingValidationResponse> Handle(
            MissingValidationRequest request,
            CancellationToken cancellationToken)
        {
            var response = new MissingValidationResponse(request);
            return Task.FromResult(response);
        }
    }
}
