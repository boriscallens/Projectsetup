using System.Threading;
using System.Threading.Tasks;
using Projectsetup.Domain.Pipeline;
using Projectsetup.Domain.Services.Validation;

namespace Projectsetup.Domain.Usecases.Ping
{
    public class PingValidator : IPipelineValidationHandler<PingRequest>
    {
        public Task Process(PingRequest request, CancellationToken cancellationToken)
        {
            request.ValidationResult = new ValidationResult();
            return Task.FromResult(request);
        }
    }
}
