using Projectsetup.Domain;
using Projectsetup.Domain.Authentication;

namespace Projectsetup.Test.RequestMissingAuth
{
    public class MissingAuthRequest : IAuthenticatableRequest<MissingAuthResult>
    {
        public IUser User { get; set; }
        public AuthenticationResult AuthenticationResult { get; set; }
    }
}
