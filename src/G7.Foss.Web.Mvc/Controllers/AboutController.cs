using Abp.AspNetCore.Mvc.Authorization;
using G7.Foss.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace G7.Foss.Web.Controllers;

[AbpMvcAuthorize]
public class AboutController : FossControllerBase
{
    public ActionResult Index()
    {
        return View();
    }
}
