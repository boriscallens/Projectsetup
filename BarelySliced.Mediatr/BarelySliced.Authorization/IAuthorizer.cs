using System.Security.Claims;

namespace BarelySliced.Authorization
{
    public interface IAuthorizer<in TRequest>
    {
        AuthorizationResult Authorize(TRequest request, ClaimsPrincipal principal);
    }
}
