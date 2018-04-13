using System;
using System.Threading.Tasks;
using Autofac;
using MediatR;
using NSubstitute;
using Projectsetup.Domain.Logging;
using Projectsetup.Domain.Pipeline;
using Projectsetup.Domain.Usecases.Ping;
using Projectsetup.Infrastructure;
using Projectsetup.Infrastructure.Logging;
using Projectsetup.Infrastructure.Pipeline;
using Projectsetup.Test.RequestMissingAuth;
using Projectsetup.Test.RequestMissingValidation;
using Xunit;

namespace Projectsetup.Test
{
    public class MediatrShould
    {
        private readonly IMediator _mediatr;
        private readonly ILogger _logger;

        public MediatrShould()
        {
            var missingAuthType = typeof(MissingAuthHandler);
            var missingValType = typeof(MissingValidationHandler);
            _logger = Substitute.For<ILogger>();

            var mediatrModule = new MediatrModule(missingAuthType, missingValType);
            var log4NetModule = new Log4NetModule();

            var builder = AutofacConfig.GetBuilder();
            builder.RegisterModule(mediatrModule);
            builder.RegisterModule(log4NetModule);
            builder.RegisterInstance(_logger).As<ILogger>();

            var container = builder.Build();

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
        public async void FindValidatorForRequest()
        {
            var request = new PingRequest();
            var result = await _mediatr.Send(request);

            Assert.NotNull(result.ValidationResult);
        }

        [Fact]
        public void ThrowIfNoAuthenticatorIsFound()
        {
            var request = new MissingAuthRequest();
            var exception = Assert.ThrowsAsync<NotImplementedException>(async () => await _mediatr.Send(request));
            Assert.Contains("IPipelineAuthenticationHandler<MissingAuthRequest>", exception.Result.Message);
        }

        [Fact]
        public void ThrowIfNoValidationIsFound()
        {
            var request = new MissingValidationRequest();
            var exception = Assert.ThrowsAsync<NotImplementedException>(async () => await _mediatr.Send(request));
            Assert.Contains("IPipelineValidationHandler<MissingValidationRequest>", exception.Result.Message);
        }

        [Fact]
        public async Task LogIncommingRequests()
        {
            var request = new PingRequest();
            await _mediatr.Send(request);

            _logger.ReceivedWithAnyArgs().Info(null);
        }

        [Fact]
        public async Task LogWithCorrelationId()
        {
            var request = new PingRequest();
            await _mediatr.Send(request);

            _logger.Received().Info(Arg.Is<IPipelineRequest<IPipelineResponse>>(x => x.CorrelationId != null));
        }
    }
}
