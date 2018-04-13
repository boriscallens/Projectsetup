using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Services.Authentication {
    public interface IAuthenticator {
        AuthenticationResult Authenticate(IUser user);
    }

    class SomeAuthenticator : IAuthenticator {
        public AuthenticationResult Authenticate(IUser user)
        {
            var result = new AuthenticationResult();
            // todo: auth stuff
            return result;
        }
    }
}
