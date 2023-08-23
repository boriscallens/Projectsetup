using System.Security.Claims;

namespace BarelySliced.Authorization.Test
{
    public class NoOpAuthorizerShould
    {
        private readonly Claim _requiredClaim = new(ClaimTypes.Name, "required Name");
        private readonly Claim _requiredRoleClaim = new(ClaimTypes.Role, "RequiredRole");
        
        [Fact]
        public void NotFailWhenPrincipalHasNoClaims()
        {
            var principalWithoutClaims = new ClaimsPrincipal(new ClaimsIdentity(null, "mock"));
            var request = new TestRequest
            {
                RequiredClaim = _requiredClaim,
                RequiredRole = "RequiredRole"
            };

            var result = new NoOpAuthorizer<TestRequest>().Authorize(request, principalWithoutClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void NotFailForPrincipalWithCorrectClaims()
        {
            var principalWithCorrectClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                _requiredClaim,
                _requiredRoleClaim
            }, "mock"));
            var request = new TestRequest
            {
                RequiredClaim = _requiredClaim,
                RequiredRole = _requiredRoleClaim.Value
            };

            var result = new NoOpAuthorizer<TestRequest>().Authorize(request, principalWithCorrectClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void NotFailForPrincipalWithTooManyClaims()
        {
            var principalWithTooManyClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                _requiredClaim,
                _requiredRoleClaim,
                new Claim(ClaimTypes.Name, "extra Name"),
                new Claim(ClaimTypes.Role, "extra Role")
            }, "mock"));
            var request = new TestRequest
            {
                RequiredClaim = _requiredClaim,
                RequiredRole = _requiredRoleClaim.Value
            };

            var result = new NoOpAuthorizer<TestRequest>().Authorize(request, principalWithTooManyClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void NotFailForPrincipalWithPartialClaims()
        {
            var principalWithPartialClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                _requiredClaim,
            }, "mock"));
            var request = new TestRequest
            {
                RequiredClaim = _requiredClaim,
                RequiredRole = _requiredRoleClaim.Value
            };

            var result = new NoOpAuthorizer<TestRequest>().Authorize(request, principalWithPartialClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }
    }
}


///// <summary>
///// Adds a <see cref="ClaimsAuthorizationRequirement"/>
///// to the current instance.
///// </summary>
///// <param name="claimType">The claim type required.</param>
///// <param name="allowedValues">Values the claim must process one or more of for evaluation to succeed.</param>
///// <returns>A reference to this instance after the operation has completed.</returns>
//public AuthorizationPolicyBuilder RequireClaim(string claimType, params string[] allowedValues)
//{
//    if (claimType == null)
//    {
//        throw new ArgumentNullException(nameof(claimType));
//    }

//    return RequireClaim(claimType, (IEnumerable<string>)allowedValues);
//}
