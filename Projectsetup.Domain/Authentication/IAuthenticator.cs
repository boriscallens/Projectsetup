namespace Projectsetup.Domain.Authentication {
    public interface IAuthenticator {
        AuthenticationResult Authenticate(IUser user);
    }

    class Authenticator : IAuthenticator {
        public AuthenticationResult Authenticate(IUser user)
        {
            var result = new AuthenticationResult();
            // todo: auth stuff
            return result;
        }
    }
}
