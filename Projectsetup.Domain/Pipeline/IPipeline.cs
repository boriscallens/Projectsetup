using System.Threading.Tasks;

namespace Projectsetup.Domain.Pipeline
{
    public interface IPipeline
    {
        Task<TResponse> Send<TResponse>(IPipelineRequest<TResponse> request)
            where TResponse : IPipelineResponse;
    }
}
