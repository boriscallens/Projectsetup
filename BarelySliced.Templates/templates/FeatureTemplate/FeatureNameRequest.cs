using MediatR;

namespace %NAMESPACE%.Features.FeatureName
{
    public struct FeatureNameRequest : IRequest<FeatureNameResponse>
    {
        public string Name { get; init; }
    }
}
