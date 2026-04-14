using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace PlataformaIgrejaCrista.Infra.Data.Context
{
    public class PlataformaIgrejaCristaDbContextFactory : IDesignTimeDbContextFactory<PlataformaIgrejaCristaDbContext>
    {
        public PlataformaIgrejaCristaDbContext CreateDbContext(string[] args)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../PlataformaIgrejaCrista.API"))
                .AddJsonFile("appsettings.Development.json", optional: true)
                .AddJsonFile("appsettings.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var builder = new DbContextOptionsBuilder<PlataformaIgrejaCristaDbContext>();
            var connectionString = configuration.GetConnectionString("SqlServer");


            builder.UseSqlServer(connectionString);

            return new PlataformaIgrejaCristaDbContext(builder.Options);
        }
    }
}