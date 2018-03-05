using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Ping
{
    public class PingRequest : IAuthenticatableRequest<PingResult>
    {
        public IUser User { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
    }
}
