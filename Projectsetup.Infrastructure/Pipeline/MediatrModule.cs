﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using MediatR;
using MediatR.Pipeline;
using Projectsetup.Domain.Pipeline;

namespace Projectsetup.Infrastructure.Pipeline
{
    public class MediatrModule : Module
    {
        public IEnumerable<Type> MarkerTypes { get; }

        public MediatrModule(params Type[] markerTypes)
        {
            MarkerTypes = markerTypes ?? new Type[0];
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestHandler<>),
                typeof(INotificationHandler<>),
                typeof(IPipelineAuthenticationHandler<>)
            };
            var assemblies = MarkerTypes.Select(type => type.Assembly).Distinct().ToArray();

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                builder
                    .RegisterAssemblyTypes(assemblies)
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            // It appears Autofac returns the last registered types first
            builder.RegisterGeneric(typeof(RequestLogger<>)).As(typeof(IRequestPreProcessor<>));
            builder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(GenericRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(GenericPipelineBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            //builder.RegisterGeneric(typeof(ConstrainedRequestPostProcessor<,>)).As(typeof(IRequestPostProcessor<,>));
            //builder.RegisterGeneric(typeof(ConstrainedPingedHandler<>)).As(typeof(INotificationHandler<>));

            builder.Register<ServiceFactory>(
                ctx =>
                {
                    var c = ctx.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
        }
    }
}
