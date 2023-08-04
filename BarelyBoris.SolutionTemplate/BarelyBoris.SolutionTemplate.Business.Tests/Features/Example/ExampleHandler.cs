namespace BarelyBoris.SolutionTemplate.Business.Tests.Features.Example
{
    public class ExampleHandler : MediatR.IRequestHandler<ExampleRequest, ExampleResponse>
    {
        public Task<ExampleResponse> Handle(ExampleRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("TODO: Implement your feature here");
        }
    }
}
