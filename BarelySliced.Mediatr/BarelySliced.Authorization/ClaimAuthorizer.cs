using System.Security.Claims;

namespace BarelySliced.Authorization;

public abstract class ClaimAuthorizer<TRequest> : IAuthorizer<TRequest>
{
    protected List<Claim> RequiredClaims { get; } = new();

    public AuthorizationResult Authorize(TRequest request, ClaimsPrincipal principal)
    {
        RequiredClaims.AddRange(AddRequiredClaims(request));

        var claimsByIsValid = RequiredClaims
            .Where(requiredClaim => !IsClaimSatisfied(requiredClaim, principal))
            .Select(failedClaim => new AuthorizationError());

        return new AuthorizationResult { Errors = claimsByIsValid.ToList() };
    }

    protected abstract IEnumerable<Claim> AddRequiredClaims(TRequest request);

    private static bool IsClaimSatisfied(Claim requiredClaim, ClaimsPrincipal principal)
    {
        return principal.HasClaim(requiredClaim.Type, requiredClaim.Value);
    }
}
