using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Infrastructure.Pipeline
{
    public class MediatrPipeline : IPipeline
    {
        private readonly IMediator _mediator;

        public MediatrPipeline(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> Send<TResponse>(IPipelineRequest<TResponse> request)
            where TResponse : IPipelineResponse
        {
            return _mediator.Send(request, CancellationToken.None);
        }
    }
}
