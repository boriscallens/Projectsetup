using Autofac;
using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Ping;
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
            var pingAuthenticator = _container.Resolve<IAuthenticationHandler<PingRequest>>();
            Assert.IsType<PingAuthenticator>(pingAuthenticator);
        }
    }
}
