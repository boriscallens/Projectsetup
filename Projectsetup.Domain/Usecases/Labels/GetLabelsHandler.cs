using System.Threading;
using System.Threading.Tasks;
using Projectsetup.Domain.Pipeline;
using Projectsetup.Domain.Repositories;

namespace Projectsetup.Domain.Usecases.Labels
{
    public class GetLabelsHandler : IPipelineHandler<GetLabelsRequest, GetLabelsResponse>
    {
        private readonly ILabelRepository _labelRepository;

        public GetLabelsHandler(ILabelRepository labelRepository)
        {
            _labelRepository = labelRepository;
        }

        public Task<GetLabelsResponse> Handle(GetLabelsRequest request, CancellationToken cancellationToken)
        {
            return Task
                .Run(() => _labelRepository.GetLabelsFor(request.Culture), cancellationToken)
                .ContinueWith(labelTask => new GetLabelsResponse(labelTask.Result), cancellationToken);
        }
    }
}
