using System.Security.Claims;

namespace BarelySliced.Authorization.Test
{
    public class ClaimAuthorizerShould
    {
        private readonly Claim _requiredClaim = new(ClaimTypes.Name, "required Name");
        private readonly Claim _requiredRoleClaim = new(ClaimTypes.Role, "RequiredRole");

        [Fact]
        public void FailAuthorizationWhenAClaimIsMissing()
        {
            var principalWithMissingClaim = new ClaimsPrincipal(new ClaimsIdentity(new[] { _requiredRoleClaim }, "mock"));
            var request = new TestRequest { RequiredClaim = _requiredClaim, RequiredRole = _requiredRoleClaim.Value };

            var result = new TestClaimAuthorizer().Authorize(request, principalWithMissingClaim);
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void FailAuthorizationWhenARoleIsMissing()
        {
            var principalWithMissingRole = new ClaimsPrincipal(new ClaimsIdentity(new[] { _requiredClaim }, "mock"));
            var request = new TestRequest { RequiredClaim = _requiredClaim, RequiredRole = _requiredRoleClaim.Value };

            var result = new TestClaimAuthorizer().Authorize(request, principalWithMissingRole);
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }

        [Fact]
        public void SucceedAuthorizationWhenAllClaimsArePresent()
        {
            var principalWithCorrectClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                _requiredClaim,
                _requiredRoleClaim
            }, "mock"));
            var request = new TestRequest { RequiredClaim = _requiredClaim, RequiredRole = _requiredRoleClaim.Value };

            var result = new TestClaimAuthorizer().Authorize(request, principalWithCorrectClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void SucceedAuthWhenExcessiveClaimsArePresent()
        {
            var principalWithTooManyClaims = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
                _requiredClaim,
                _requiredRoleClaim,
                new Claim(ClaimTypes.Name, "extra Name"),
                new Claim(ClaimTypes.Role, "extra Role")
            }, "mock"));
            var request = new TestRequest { RequiredClaim = _requiredClaim, RequiredRole = _requiredRoleClaim.Value };

            var result = new TestClaimAuthorizer().Authorize(request, principalWithTooManyClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void SucceedAuthWhenNoClaimsAreRequired()
        {
            var principalWithNoClaims = new ClaimsPrincipal(new ClaimsIdentity(null, "mock"));
            var request = new TestRequest { RequiredClaim = _requiredClaim, RequiredRole = _requiredRoleClaim.Value };

            var result = new EmptyTestClaimAuthorizer().Authorize(request, principalWithNoClaims);
            Assert.True(result.IsValid);
            Assert.Empty(result.Errors);
        }

        [Fact]
        public void FailsOnMissingClaimsAddedInConstructor()
        {
            var principalWithNoClaims = new ClaimsPrincipal(new ClaimsIdentity(null, "mock"));
            var request = new TestRequest { RequiredClaim = _requiredClaim, RequiredRole = _requiredRoleClaim.Value };

            var result = new ConstructorClaimAuthorizer().Authorize(request, principalWithNoClaims);
            Assert.False(result.IsValid);
            Assert.NotEmpty(result.Errors);
        }
    }

    public class ConstructorClaimAuthorizer : ClaimAuthorizer<TestRequest>
    {
        public ConstructorClaimAuthorizer()
        {
            RequiredClaims.Add(new(ClaimTypes.Name, "constructor required Name"));
            RequiredClaims.Add(new(ClaimTypes.Role, "constructor RequiredRole"));
        }

        protected override IEnumerable<Claim> AddRequiredClaims(TestRequest request)
        {
            return new List<Claim>
            {
                request.RequiredClaim,
                new(ClaimTypes.Role, request.RequiredRole)
            };
        }
    }

    public class EmptyTestClaimAuthorizer : ClaimAuthorizer<TestRequest>
    {
        protected override IEnumerable<Claim> AddRequiredClaims(TestRequest request)
        {
            return Enumerable.Empty<Claim>();
        }
    }

    public class TestClaimAuthorizer : ClaimAuthorizer<TestRequest>
    {
        protected override IEnumerable<Claim> AddRequiredClaims(TestRequest request)
        {
            return new List<Claim>
            {
                request.RequiredClaim,
                new(ClaimTypes.Role, request.RequiredRole)
            };
        }
    }
}
