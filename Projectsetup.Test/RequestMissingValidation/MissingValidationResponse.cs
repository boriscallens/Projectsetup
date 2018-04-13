using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Test.RequestMissingValidation {
    public class MissingValidationResponse: BasePipelineResponse {
        public MissingValidationResponse(MissingValidationRequest request) : base(request)
        { }
    }
}
