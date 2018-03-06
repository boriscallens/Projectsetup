using MediatR.Pipeline;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineAuthenticationHandler<in TRequest> 
        : IRequestPreProcessor<TRequest>
        where TRequest : IPipelineRequest<IPipelineResponse> { }
}
