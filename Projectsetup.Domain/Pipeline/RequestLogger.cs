using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Projectsetup.Domain.Logging;

namespace Projectsetup.Domain.Pipeline
{
    public class RequestLogger<TRequest>
        : IRequestPreProcessor<TRequest>
        where TRequest : class, IPipelineRequest<IPipelineResponse>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            _logger.Info(request);
            return Task.CompletedTask;
        }
    }
}
