using System;
using Projectsetup.Domain.Authentication;

namespace Projectsetup.Domain.Pipeline
{
    public class BasePipelineResponse : IPipelineResponse
    {
        public AuthenticationResult AuthenticationResult { get; set; }

        protected BasePipelineResponse(IPipelineRequest<IPipelineResponse> request)
        {
            if (request.AuthenticationResult == null)
            {
                var requestName = request.GetType().Name;
                var msg =
                    $"Request was not authenticated. Maybe an IPipelineAuthenticationHandler<{requestName}> is not registered?";
                throw new NotImplementedException(msg);
            }

            AuthenticationResult = request.AuthenticationResult;
        }
    }
}
