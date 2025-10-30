using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using G7.Foss.Authorization;

namespace G7.Foss;

[DependsOn(
    typeof(FossCoreModule),
    typeof(AbpAutoMapperModule))]
public class FossApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<FossAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(FossApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
