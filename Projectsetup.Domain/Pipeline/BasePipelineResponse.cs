using System;
using Projectsetup.Domain.Services.Authentication;
using Projectsetup.Domain.Services.Validation;

namespace Projectsetup.Domain.Pipeline
{
    public class BasePipelineResponse : IPipelineResponse
    {
        public AuthenticationResult AuthenticationResult { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public BasePipelineResponse(IPipelineRequest<IPipelineResponse> request)
        {
            if (request.AuthenticationResult == null)
            {
                var requestName = request.GetType().Name;
                var msg =
                    $"Request was not authenticated. Maybe an IPipelineAuthenticationHandler<{requestName}> is not registered?";
                throw new NotImplementedException(msg);
            }
            if (request.ValidationResult == null)
            {
                var requestName = request.GetType().Name;
                var msg =
                    $"Request was not authenticated. Maybe an IPipelineValidationHandler<{requestName}> is not registered?";
                throw new NotImplementedException(msg);
            }

            AuthenticationResult = request.AuthenticationResult;
            ValidationResult = request.ValidationResult;
        }
    }
}
