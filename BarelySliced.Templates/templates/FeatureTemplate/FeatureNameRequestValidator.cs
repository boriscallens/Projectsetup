using FluentValidation;

namespace %NAMESPACE%.Features.FeatureName
{
    public class FeatureNameRequestValidator: AbstractValidator<FeatureNameRequest>
    {
        public FeatureNameRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}