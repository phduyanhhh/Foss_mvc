using Abp.AutoMapper;
using G7.Foss.Sessions.Dto;

namespace G7.Foss.Web.Views.Shared.Components.TenantChange;

[AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
public class TenantChangeViewModel
{
    public TenantLoginInfoDto Tenant { get; set; }
}
