using G7.Foss.Configuration;
using G7.Foss.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace G7.Foss.EntityFrameworkCore;

/* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
public class FossDbContextFactory : IDesignTimeDbContextFactory<FossDbContext>
{
    public FossDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<FossDbContext>();

        /*
         You can provide an environmentName parameter to the AppConfigurations.Get method. 
         In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
         Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
         https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
         */
        var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

        FossDbContextConfigurer.Configure(builder, configuration.GetConnectionString(FossConsts.ConnectionStringName));

        return new FossDbContext(builder.Options);
    }
}
