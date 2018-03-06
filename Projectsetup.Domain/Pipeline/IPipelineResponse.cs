using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineResponse
    {
        AuthenticationResult AuthenticationResult { get; set; }
    }
}
