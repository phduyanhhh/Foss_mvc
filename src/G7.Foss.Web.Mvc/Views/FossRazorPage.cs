using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace G7.Foss.Web.Views;

public abstract class FossRazorPage<TModel> : AbpRazorPage<TModel>
{
    [RazorInject]
    public IAbpSession AbpSession { get; set; }

    protected FossRazorPage()
    {
        LocalizationSourceName = FossConsts.LocalizationSourceName;
    }
}
