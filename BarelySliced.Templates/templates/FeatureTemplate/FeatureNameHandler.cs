namespace %NAMESPACE%.Features.FeatureName
{
    public class FeatureNameHandler : MediatR.IRequestHandler<FeatureNameRequest, FeatureNameResponse>
    {
        public Task<FeatureNameResponse> Handle(FeatureNameRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("TODO: Implement your feature here");
        }
    }
}
