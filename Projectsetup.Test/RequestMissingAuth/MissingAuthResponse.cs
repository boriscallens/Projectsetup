using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Test.RequestMissingAuth {
    public class MissingAuthResponse: BasePipelineResponse {
        public MissingAuthResponse(MissingAuthRequest request) : base(request)
        { }
    }
}
