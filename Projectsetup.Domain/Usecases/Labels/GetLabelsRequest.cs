using System.Globalization;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Usecases.Labels
{
    public class GetLabelsRequest: BasePipelineRequest<GetLabelsResponse>
    {
        public CultureInfo Culture { get; }

        public GetLabelsRequest(CultureInfo culture)
        {
            Culture = culture;
        }
    }
}
