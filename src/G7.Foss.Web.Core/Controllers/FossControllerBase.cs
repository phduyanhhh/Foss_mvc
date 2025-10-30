using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace G7.Foss.Controllers
{
    public abstract class FossControllerBase : AbpController
    {
        protected FossControllerBase()
        {
            LocalizationSourceName = FossConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
