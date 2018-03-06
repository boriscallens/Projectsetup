using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Pipeline
{
    public abstract class BasePipelineRequest<TResponse> : IPipelineRequest<TResponse>
        where TResponse : IPipelineResponse
    {
        public IUser User { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
    }
}
