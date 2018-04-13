using System;
using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Services.Authentication;
using Projectsetup.Domain.Services.Validation;

namespace Projectsetup.Domain.Pipeline
{
    public abstract class BasePipelineRequest<TResponse> : IPipelineRequest<TResponse>
        where TResponse : IPipelineResponse
    {
        public Guid CorrelationId { get; }
        public IUser User { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public BasePipelineRequest(Guid correlationId)
        {
            CorrelationId = correlationId;
        }
        public BasePipelineRequest()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}
