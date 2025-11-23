using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace G7.Foss.EntityFrameworkCore;

public static class FossDbContextConfigurer
{
    public static void Configure(DbContextOptionsBuilder<FossDbContext> builder, string connectionString)
    {
        builder.UseNpgsql(connectionString);
    }

    public static void Configure(DbContextOptionsBuilder<FossDbContext> builder, DbConnection connection)
    {
        builder.UseNpgsql(connection);
    }
}
