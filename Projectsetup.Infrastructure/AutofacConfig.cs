using System;
using System.Reflection;
using Autofac;
using Projectsetup.Domain.Usecases.Ping;
using Projectsetup.Infrastructure.Logging;
using Projectsetup.Infrastructure.Pipeline;

namespace Projectsetup.Infrastructure
{
    public static class AutofacConfig
    {
        public static ContainerBuilder GetBuilder()
        {
            var domainMarkerType = typeof(PingRequest);
            var mediatrModule = new MediatrModule(domainMarkerType);
            var loggingModule = new Log4NetModule();

            var builder = new ContainerBuilder();
            builder.RegisterModule(mediatrModule);
            builder.RegisterModule(loggingModule);
            RegisterDomain(builder, domainMarkerType);

            return builder;
        }

        private static void RegisterDomain(ContainerBuilder builder, Type markerType)
        {
            builder.RegisterAssemblyTypes(markerType.GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}
