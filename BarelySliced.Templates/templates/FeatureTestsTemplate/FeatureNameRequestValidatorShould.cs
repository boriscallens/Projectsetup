using FluentValidation;

namespace %NAMESPACE%.Features.FeatureName
{
    public class FeatureNameRequestValidator: AbstractValidator<FeatureNameRequest>
    {
        public FeatureNameRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
            throw new System.NotImplementedException("TODO: Implement your request validator here. Mind you it should not validate your application state");
        }
    }
}