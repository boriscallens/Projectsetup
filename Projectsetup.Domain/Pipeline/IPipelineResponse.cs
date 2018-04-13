using Projectsetup.Domain.Services.Authentication;
using Projectsetup.Domain.Services.Validation;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineResponse
    {
        AuthenticationResult AuthenticationResult { get; set; }
        ValidationResult ValidationResult { get; set; }
    }
}
