using G7.Foss.Configuration;
using G7.Foss.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace G7.Foss.EntityFrameworkCore;

public class FossDbContextFactory : IDesignTimeDbContextFactory<FossDbContext>
{
    public FossDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<FossDbContext>();

        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        FossDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FossConsts.ConnectionStringName));

        return new FossDbContext(builder.Options);
    }
}
