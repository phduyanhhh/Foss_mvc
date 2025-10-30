using Abp.Zero.EntityFrameworkCore;
using G7.Foss.Authorization.Roles;
using G7.Foss.Authorization.Users;
using G7.Foss.MultiTenancy;
using Microsoft.EntityFrameworkCore;

namespace G7.Foss.EntityFrameworkCore;

public class FossDbContext : AbpZeroDbContext<Tenant, Role, User, FossDbContext>
{
    /* Define a DbSet for each entity of the application */

    public FossDbContext(DbContextOptions<FossDbContext> options)
        : base(options)
    {
    }
}
