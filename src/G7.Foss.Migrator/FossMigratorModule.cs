using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using G7.Foss.Configuration;
using G7.Foss.EntityFrameworkCore;
using G7.Foss.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace G7.Foss.Migrator;

[DependsOn(typeof(FossEntityFrameworkModule))]
public class FossMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public FossMigratorModule(FossEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(FossMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            FossConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(FossMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
