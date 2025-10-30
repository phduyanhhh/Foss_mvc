using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using G7.Foss.Authorization.Users;
using G7.Foss.Editions;

namespace G7.Foss.MultiTenancy;

public class TenantManager : AbpTenantManager<Tenant, User>
{
    public TenantManager(
        IRepository<Tenant> tenantRepository,
        IRepository<TenantFeatureSetting, long> tenantFeatureRepository,
        EditionManager editionManager,
        IAbpZeroFeatureValueStore featureValueStore)
        : base(
            tenantRepository,
            tenantFeatureRepository,
            editionManager,
            featureValueStore)
    {
    }
}
