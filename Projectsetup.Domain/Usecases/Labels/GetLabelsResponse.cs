using System.Collections.Generic;
using Projectsetup.Domain.Pipeline;
using Projectsetup.Domain.Services.Authentication;
using Projectsetup.Domain.Services.Labels;
using Projectsetup.Domain.Services.Validation;

namespace Projectsetup.Domain.Usecases.Labels
{
    public class GetLabelsResponse : IPipelineResponse
    {
        public GetLabelsResponse(IEnumerable<Label> labels)
        {
            Labels = labels;
        }

        public AuthenticationResult AuthenticationResult { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public IEnumerable<Label> Labels { get; }
    }
}
