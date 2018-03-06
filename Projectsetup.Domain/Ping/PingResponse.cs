using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Ping
{
    public class PingResponse : BasePipelineResponse
    {
        public PingResponse(PingRequest request) : base(request) { }
    }
}
