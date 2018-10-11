using System;
using MediatR;
using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Services.Authentication;
using Projectsetup.Domain.Services.Validation;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineRequest<out TResponse>
        : IRequest<TResponse>
        where TResponse : IPipelineResponse
    {
        Guid CorrelationId { get; }
        IUser User { get; set; }
        AuthenticationResult AuthenticationResult { get; set; }
        ValidationResult ValidationResult { get; set; }
    }
}
