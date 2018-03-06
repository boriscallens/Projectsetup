using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineRequest<out TResponse>
        : MediatR.IRequest<TResponse>
        where TResponse : IPipelineResponse
    {
        AuthenticationResult AuthenticationResult { get; set; }
    }
}
