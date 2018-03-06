﻿using System.Threading;
using System.Threading.Tasks;
using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Ping
{
    public class PingAuthenticator : IPipelineAuthenticationHandler<PingRequest>
    {
        private readonly IAuthenticator _authenticator;

        public PingAuthenticator(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }

        public Task Process(PingRequest request, CancellationToken cancellationToken)
        {
            request.AuthenticationResult = _authenticator.Authenticate(request.User);
            return Task.FromResult(request);
        }
    }
}
