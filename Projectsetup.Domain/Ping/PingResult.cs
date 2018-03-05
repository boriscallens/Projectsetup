using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Ping {
    public class PingResult: PipelineResult {
        public PingResult(IAuthenticatableRequest request) : base(request) { }
    }
}
