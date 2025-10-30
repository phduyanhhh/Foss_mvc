using Abp.Modules;
using Abp.Reflection.Extensions;
using G7.Foss.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace G7.Foss.Web.Host.Startup
{
    [DependsOn(
       typeof(FossWebCoreModule))]
    public class FossWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public FossWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(FossWebHostModule).GetAssembly());
        }
    }
}
