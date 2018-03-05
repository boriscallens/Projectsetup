using MediatR.Pipeline;

namespace Projectsetup.Domain.Authentication {
    public interface IAuthenticationHandler<in TRequest> : IRequestPreProcessor<TRequest> { }
}
