using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Test.RequestMissingHandler {
    public class MissingHandlerResponse: BasePipelineResponse {
        public MissingHandlerResponse(MissingHandlerRequest request) : base(request)
        { }
    }
}
