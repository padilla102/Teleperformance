using Autofac;
using Teleperformance.Registration.Domain.Ports.UseCases;
using Teleperformance.Registration.Domain.UseCase;

namespace Teleperformance.Registration.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegistrerCompanyUseCase>().As<IRegisterCompanyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<UpdateCompanyUseCase>().As<IUpdateCompanyUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<FindByIdentificationCompanyUseCase>().As<IFindByIdentificationCompanyUseCase>().InstancePerLifetimeScope();
        }
    }
}
