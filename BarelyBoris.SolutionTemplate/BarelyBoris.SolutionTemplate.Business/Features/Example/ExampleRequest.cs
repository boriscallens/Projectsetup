using MediatR;

namespace BarelyBoris.SolutionTemplate.Business.Features.Example
{
    public struct ExampleRequest : IRequest<ExampleResponse>
    {
        public string Name { get; init; }
    }
}
