namespace %NAMESPACE%.Features.FeatureName
{
    public class FeatureNameHandlerShould : IClassFixture<TestFixture>
    {
        public FeatureNameHandlerShould(TestFixture fixture)
        {
            // Get your required services to inject here
        }

        [Fact]
        public async Task DoTheFeature()
        {
            var request = new FeatureNameRequest();
            var handler = new FeatureNameHandler();
            var response = await handler.Handle(request, CancellationToken.None);

            Throw new NotImplementedException("TODO: Test if your feature implements the requirements.");
        }
    }
}