using System.Security.Claims;

namespace BarelySliced.Authorization;

public class NoOpAuthorizer<TRequest> : IAuthorizer<TRequest>
{
    public AuthorizationResult Authorize(TRequest request, ClaimsPrincipal principal)
    {
        return AuthorizationResult.Success;
    }
}