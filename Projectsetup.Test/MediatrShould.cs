using System;
using System.Reflection;
using Autofac;
using MediatR;
using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Ping;
using Projectsetup.Infrastructure;
using Projectsetup.Test.RequestMissingAuth;
using Xunit;

namespace Projectsetup.Test
{
    public class MediatrShould
    {
        private readonly IMediator _mediatr;

        public MediatrShould()
        {
            var container = AutofacConfig.GetBuilder();
            container.Build();
            _mediatr = container.Resolve<IMediator>();
        }

        [Fact]
        public async void FindHandlerForRequest()
        {
            var request = new PingRequest();
            var result = await _mediatr.Send(request);

            Assert.NotNull(result);
        }

        [Fact]
        public async void FindAuthenticatorForRequest()
        {
            var request = new PingRequest();
            var result = await _mediatr.Send(request);

            Assert.NotNull(result.AuthenticationResult);
        }

        [Fact]
        public void ThrowIfNoAuthenticatorIsFound()
        {
            var request = new MissingAuthRequest();
            var exception = Assert.ThrowsAsync<NotImplementedException>(async () => await _mediatr.Send(request));
            Assert.Contains(exception.Result.Message, "MissingAuthRequestAuthenticator");
        }
    }

    public class UnauthenticatablePingRequest : IRequest { }
}
