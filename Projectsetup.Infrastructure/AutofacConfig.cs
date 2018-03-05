using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Projectsetup.Domain;
using Projectsetup.Domain.Authentication;
using Projectsetup.Domain.Ping;

namespace Projectsetup.Infrastructure
{
    public static class AutofacConfig
    {
        public static ContainerBuilder GetBuilder()
        {
            var builder = new ContainerBuilder();

            var domainMarkerType = typeof(PingRequest);

            RegisterDomain(builder, domainMarkerType);
            RegisterMediatr(builder, domainMarkerType);

            return builder;
        }

        private static void RegisterDomain(ContainerBuilder builder, Type markerType)
        {
            builder.RegisterAssemblyTypes(markerType.GetTypeInfo().Assembly).AsImplementedInterfaces();
        }

        private static void RegisterMediatr(ContainerBuilder builder, params Type[] markerType)
        {
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();
            
            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestHandler<>),
                typeof(INotificationHandler<>),
                typeof(IAuthenticationHandler<>)
            };
            var assemblies = markerType.Select(type => type.GetTypeInfo().Assembly).Distinct().ToArray();
            
            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(assemblies)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            // It appears Autofac returns the last registered types first
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(GenericRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(GenericPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(ConstrainedRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(ConstrainedPingedHandler<>)).As(typeof(INotificationHandler<>));

            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });
        }
    }
}
