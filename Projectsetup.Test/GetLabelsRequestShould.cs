using System.Globalization;
using NSubstitute;
using Projectsetup.Domain.Repositories;
using Projectsetup.Domain.Services.Labels;
using Projectsetup.Domain.Usecases.Labels;
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

            var mediatr = new MediatrBuilder()
                .WithInstance(labelRepo)
                .Build();

            var request = new GetLabelsRequest(culture);
            var result = await mediatr.Send(request);

            Assert.NotEmpty(result.Labels);
            Assert.All(result.Labels, label => label.Culture.Equals(culture));
        }
    }
}
