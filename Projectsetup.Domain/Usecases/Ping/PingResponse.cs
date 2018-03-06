using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Usecases.Ping
{
    public class PingResponse : BasePipelineResponse
    {
        public PingResponse(PingRequest request) : base(request) { }
    }
}
