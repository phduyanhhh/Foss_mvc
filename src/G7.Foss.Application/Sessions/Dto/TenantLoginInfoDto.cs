using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using G7.Foss.MultiTenancy;

namespace G7.Foss.Sessions.Dto;

[AutoMapFrom(typeof(Tenant))]
public class TenantLoginInfoDto : EntityDto
{
    public string TenancyName { get; set; }

    public string Name { get; set; }
}
