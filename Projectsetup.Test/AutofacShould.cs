using Autofac;
using Projectsetup.Domain.Pipeline;
using Projectsetup.Domain.Usecases.Ping;
using Projectsetup.Infrastructure;
using Xunit;

namespace Projectsetup.Test
{
    public class AutofacShould
    {
        private readonly IContainer _container;

        public AutofacShould()
        {
            _container = AutofacConfig.GetBuilder().Build();
        }

        [Fact]
        public void ResolveAuthenticators()
        {
            var pingAuthenticator = _container.Resolve<IPipelineAuthenticationHandler<PingRequest>>();
            Assert.IsType<PingAuthenticator>(pingAuthenticator);
        }
    }
}
