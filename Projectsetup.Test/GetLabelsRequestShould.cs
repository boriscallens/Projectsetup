using System.Globalization;
using Autofac;
using MediatR;
using NSubstitute;
using Projectsetup.Domain.Repositories;
using Projectsetup.Domain.Services.Labels;
using Projectsetup.Domain.Usecases.Labels;
using Projectsetup.Infrastructure;
using Xunit;

namespace Projectsetup.Test
{
    public class GetLabelsRequestShould
    {
        [Fact]
        public async void FetchLabelsForTheRequestedCulture()
        {
            var culture = new CultureInfo("en-GB");
            var labelRepo = Substitute.For<ILabelRepository>();
            labelRepo.GetLabelsFor(culture).Returns(new[] {new Label(culture)});

            // TODO: make an actual autofac builder that follows the builder pattern
            var builder = AutofacConfig.GetBuilder();
            builder.RegisterInstance(labelRepo);
            var autofac = builder.Build();
            var mediatr = autofac.Resolve<IMediator>();

            var request = new GetLabelsRequest(culture);
            var result = await mediatr.Send(request);

            Assert.NotEmpty(result.Labels);
            Assert.All(result.Labels, label => label.Culture.Equals(culture));
        }
    }
}
