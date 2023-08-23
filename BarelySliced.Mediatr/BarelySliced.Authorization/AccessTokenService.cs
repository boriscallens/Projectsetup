//using System.Security.Claims;

//namespace BarelySliced.Authorization
//{
//    public interface IAccessTokenService
//    {
//        Task<string> GetToken();
//        Task<ClaimsPrincipal> ValidateToken(string jwtToken);
//    }

//    public class AccessTokenService : IAccessTokenService
//    {
//        private readonly IHttpClientFactory _clientFactory;
//        private readonly IdentityClientOptions _options;

//        private readonly SemaphoreSlim _lock = new(1);
//        private DateTime _expiration;
//        private string _token;

//        public AccessTokenService(IHttpClientFactory clientFactory, IdentityClientOptions identity)
//        {
//            _clientFactory = clientFactory;
//            _options = identity;
//        }

//        public async Task<string> GetToken()
//        {
//            if (_expiration >= DateTime.Now)
//            {
//                return _token;
//            }

//            await _lock.WaitAsync();
//            try
//            {
//                if (_expiration >= DateTime.Now)
//                {
//                    return _token;
//                }

//                var client = _clientFactory.CreateClient("identity");

//                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest {
//                    Address = _options.Authority + "/connect/token",
//                    ClientId = _options.ClientId,
//                    ClientSecret = _options.ClientSecret,
//                    Scope = _options.Scope
//                });

//                if (tokenResponse.IsError)
//                {
//                    throw new Exception($"Unable to obtain token: {tokenResponse.Error}", tokenResponse.Exception);
//                }

//                _token = tokenResponse.AccessToken;
//                _expiration = DateTime.Now.AddSeconds(tokenResponse.ExpiresIn - 10);
//                return _token;
//            }
//            finally
//            {
//                _lock.Release();
//            }
//        }

//        public async Task<ClaimsPrincipal> ValidateToken(string jwtToken)
//        {
//            try
//            {
//                var configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{_options.Authority}/.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
//                var openIdConfig = await configurationManager.GetConfigurationAsync();

//                var tokenHandler = new JwtSecurityTokenHandler();
//                var claimsPrincipal = tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters {
//                    IssuerSigningKeys = openIdConfig.SigningKeys,
//                    ValidAudiences = new[] { _options.ClientId },
//                    ValidIssuer = _options.Authority,
//                    ValidateLifetime = true,
//                    ValidateAudience = true,
//                    ValidateIssuer = true,
//                    ValidateIssuerSigningKey = true,
//                    ValidateTokenReplay = true
//                }, out var validatedToken);
//                return claimsPrincipal;
//            }
//            catch
//            {
//                return null;
//            }
//        }
//    }
//}
