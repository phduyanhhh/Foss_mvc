using Abp.MultiTenancy;
using G7.Foss.Authorization.Users;

namespace G7.Foss.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
