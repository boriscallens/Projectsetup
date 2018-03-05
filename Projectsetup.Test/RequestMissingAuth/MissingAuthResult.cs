using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Test.RequestMissingAuth {
    public class MissingAuthResult: PipelineResult {
        public MissingAuthResult(MissingAuthRequest request) : base(request)
        { }
    }
}
