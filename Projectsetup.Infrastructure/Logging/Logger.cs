using log4net;
using Projectsetup.Domain.Logging;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Infrastructure.Logging
{
    public class Logger : ILogger
    {
        private readonly ILog _log;

        public Logger(ILog log)
        {
            _log = log;
        }

        public void Debug(object message)
        {
            _log.Debug(message);
        }

        public void Error(object message)
        {
            _log.Error(message);
        }

        public void Fatal(object message)
        {
            _log.Fatal(message);
        }

        public void Info(object message)
        {
            _log.Info(message);
        }

        public void Info(IPipelineRequest<IPipelineResponse> message)
        {
            _log.Info(message);
        }

        public void Warn(object message)
        {
            _log.Warn(message);
        }
    }
}
