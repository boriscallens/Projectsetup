using System;
using System.Reflection;
using Autofac;
using Projectsetup.Domain.Ping;
using Projectsetup.Infrastructure.MediatrPipeline;

namespace Projectsetup.Infrastructure
{
    public static class AutofacConfig
    {
        public static ContainerBuilder GetBuilder()
        {
            var domainMarkerType = typeof(PingRequest);
            var mediatrModule = new MediatrModule(domainMarkerType);

            var builder = new ContainerBuilder();
            builder.RegisterModule(mediatrModule);
            RegisterDomain(builder, domainMarkerType);

            return builder;
        }

        private static void RegisterDomain(ContainerBuilder builder, Type markerType)
        {
            builder.RegisterAssemblyTypes(markerType.GetTypeInfo().Assembly).AsImplementedInterfaces();
        }
    }
}
