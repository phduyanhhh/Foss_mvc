using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using G7.Foss.EntityFrameworkCore;
using G7.Foss.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace G7.Foss.Web.Tests;

[DependsOn(
    typeof(FossWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class FossWebTestModule : AbpModule
{
    public FossWebTestModule(FossEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(FossWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(FossWebMvcModule).Assembly);
    }
}