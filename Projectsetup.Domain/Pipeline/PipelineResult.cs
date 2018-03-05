using System;
using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Pipeline
{
    public abstract class PipelineResult : IAuthenticatedResult
    {
        public AuthenticationResult AuthenticationResult { get; }

        protected PipelineResult(IAuthenticatableRequest request)
        {
            if (request.AuthenticationResult == null)
            {
                var message =
                    $"Missing authentication. Please make sure there is an IAuthentictionHandler<{request.GetType().Name}> registered.";
                throw new NotImplementedException(message);
            }

            AuthenticationResult = request.AuthenticationResult;
        }
    }
}
