using FluentValidation;

namespace BarelyBoris.SolutionTemplate.Business.Features.Example
{
    public class ExampleRequestValidator: AbstractValidator<ExampleRequest>
    {
        public ExampleRequestValidator()
        {
            RuleFor(request => request.Name).NotEmpty();
        }
    }
}