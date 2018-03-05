namespace Projectsetup.Domain
{
    public interface IAuthenticatableRequest<out TRequest>: MediatR.IRequest<TRequest>
    {
        IUser User { get; set; }
    }

    public interface IUser{ }
}
