using MediatR.Pipeline;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineValidationHandler<in TRequest>
        : IRequestPreProcessor<TRequest>
        where TRequest : IPipelineRequest<IPipelineResponse> { }
}
