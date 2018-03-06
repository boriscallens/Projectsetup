using Autofac;
using log4net;
using Projectsetup.Domain.Logging;

namespace Projectsetup.Infrastructure.Logging
{
    public class Log4NetModule: Module
    {
        public Log4NetModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(x => new Logger(LogManager.GetLogger(x.GetType()))).As<ILogger>();
        }
    }
}
