using Abp.AspNetCore.Mvc.ViewComponents;

namespace G7.Foss.Web.Views;

public abstract class FossViewComponent : AbpViewComponent
{
    protected FossViewComponent()
    {
        LocalizationSourceName = FossConsts.LocalizationSourceName;
    }
}
