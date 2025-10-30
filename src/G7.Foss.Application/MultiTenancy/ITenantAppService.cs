using Abp.Application.Services;
using G7.Foss.MultiTenancy.Dto;

namespace G7.Foss.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

