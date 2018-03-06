using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Domain.Logging
{
    public interface ILogger
    {
        void Debug(object message);
        void Error(object message);
        void Fatal(object message);
        void Info(object message);
        void Info(IPipelineRequest<IPipelineResponse> message);
        void Warn(object message);
    }
}
