using MediatR;

namespace Projectsetup.Domain.Authentication
{
    public interface IAuthenticatableRequest: IBaseRequest
    {
        IUser User { get; set; }
        AuthenticationResult AuthenticationResult { get; set; }
    }

    public interface IAuthenticatableRequest<out TRequest> : IRequest<TRequest>, IAuthenticatableRequest { }
}
