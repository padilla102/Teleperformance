using Autofac;
using Teleperformance.Registration.Domain.Ports.Gateways.Repositories;
using Teleperformance.Registration.Domain.Ports.services;
using Teleperformance.Registration.Infrastruture.Data.Repositories;
using Teleperformance.Registration.Infrastruture.Logging;
using Module = Autofac.Module;

namespace Teleperformance.Registration.Infrastruture
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().InstancePerLifetimeScope();
            builder.RegisterType<Logger>().As<ILogger>().SingleInstance();
        }
    }
}
