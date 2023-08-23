namespace BarelySliced.Authorization
{
    public class AuthorizationResult
    {
        public static AuthorizationResult Success => new AuthorizationResult();

        public virtual bool IsValid => Errors.Count == 0;
        public List<AuthorizationError> Errors { get; init; }

        public AuthorizationResult() {
            Errors = new List<AuthorizationError>();
        }
    }
}
