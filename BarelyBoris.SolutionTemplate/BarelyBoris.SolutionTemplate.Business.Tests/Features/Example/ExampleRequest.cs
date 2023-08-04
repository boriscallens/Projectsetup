using MediatR;

namespace BarelyBoris.SolutionTemplate.Business.Tests.Features.Example
{
    public struct ExampleRequest : IRequest<ExampleResponse>
    {
        public string Name { get; init; }
    }
}
