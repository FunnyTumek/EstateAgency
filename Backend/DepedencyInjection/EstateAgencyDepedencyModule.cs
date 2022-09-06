using Autofac;
using AutoMapper;
using Domain.RepositoryInterfaces;
using Persistance.Configurations.MappingToDto;
using Persistance.Repositories;
using Services;
using Services.Abstractions;

namespace DepedencyInjection
{
    public class EstateAgencyDepedencyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<PropertiesService>().As<IPropertiesService>();
            builder.RegisterType<PropertiesRepository>().As<IPropertiesRepository>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();

            })).AsSelf().SingleInstance();
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();
        }
    }
}
