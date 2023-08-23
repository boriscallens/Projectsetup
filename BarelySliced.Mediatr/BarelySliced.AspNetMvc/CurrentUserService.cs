//using System.Security.Claims;
//using BarelySliced.Authorization;
//using Microsoft.AspNetCore.Http;

//namespace BarelySliced.AspNetMvc
//{
//    public class CurrentUserService : ICurrentUserService
//    {
//        private string? _name;
//        private string? _uniqueName;
//        private string? _preferredName;
//        private readonly IAccessTokenService _accessTokenService;

//        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IAccessTokenService accessTokenService)
//        {
//            _accessTokenService = accessTokenService;
//            if (httpContextAccessor.HttpContext == null) return;

//            SetCurrentUser(httpContextAccessor.HttpContext.User);
//            httpContextAccessor.HttpContext.Features.Set<ICurrentUserService>(this);
//        }

//        public string UserId { get; private set; }

//        public string UserName => _name ?? _preferredName ?? _uniqueName ?? UserId;

//        public IEnumerable<string>? Roles { get; private set; }

//        public IEnumerable<string>? OrgUnits { get; private set; }

//        public bool IsInRole(string role)
//        {
//            return Roles?.Any(item => item == role) ?? false;
//        }

//        public async Task<bool> Impersonate(string accessToken)
//        {
//            var user = await _accessTokenService.ValidateToken(accessToken);
//            var success = user != null;

//            if (success) { SetCurrentUser(user); }
//            return success;
//        }

//        private void SetCurrentUser(ClaimsPrincipal claimsPrincipal)
//        {
//            UserId = claimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value 
//                      ?? claimsPrincipal?.FindFirst("client_id")?.Value 
//                      ?? throw new ArgumentException($"Couldn't find user id in either NameIdentifier or client_id claims", nameof(claimsPrincipal));
//            _name = claimsPrincipal?.Identity?.Name;
//            _uniqueName = claimsPrincipal?.FindFirst("unique_name")?.Value;
//            _preferredName = claimsPrincipal?.FindFirst("preferred_name")?.Value;
//            Roles = claimsPrincipal?.FindAll("role").Select(claim => claim.Value.ToLower());
//        }
//    }
//}
