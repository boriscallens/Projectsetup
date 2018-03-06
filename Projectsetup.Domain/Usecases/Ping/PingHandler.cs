using System.Threading;
using System.Threading.Tasks;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Usecases.Ping
{
    public class PingHandler : IPipelineHandler<PingRequest, PingResponse>
    {
        public Task<PingResponse> Handle(PingRequest request, CancellationToken cancellationToken)
        {
            var pingResult = new PingResponse(request);
            return Task.FromResult(pingResult);
        }
    }
}
