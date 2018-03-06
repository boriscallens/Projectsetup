using System;
using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipelineRequest<out TResponse>
        : MediatR.IRequest<TResponse>
        where TResponse : IPipelineResponse
    {
        Guid CorrelationId { get; }
        IUser User { get; set; }
        AuthenticationResult AuthenticationResult { get; set; }
    }
}
