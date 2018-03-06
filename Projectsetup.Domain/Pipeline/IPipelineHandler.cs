namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineHandler<in TRequest, TResponse>
        : MediatR.IRequestHandler<TRequest, TResponse>
        where TRequest : IPipelineRequest<TResponse>
        where TResponse : IPipelineResponse { }
}
