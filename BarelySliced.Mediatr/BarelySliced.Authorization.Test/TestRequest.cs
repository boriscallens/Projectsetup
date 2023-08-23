using System.Security.Claims;

namespace BarelySliced.Authorization.Test;

public class TestRequest
{
    public Claim RequiredClaim { get; init; }
    public string RequiredRole { get; init; }
}