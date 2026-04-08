using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaIgrejaCrista.Domain.Entities;
using PlataformaIgrejaCrista.Domain.Interfaces;
using PlataformaIgrejaCrista.Infra.Data.Context;
using PlataformaIgrejaCrista.Infra.Data.Security;

namespace PlataformaIgrejaCrista.Infra.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContext<PlataformaIgrejaCristaDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("PostgreSql"),
                   p => p.MigrationsAssembly(typeof(PlataformaIgrejaCristaDbContext)
                   .Assembly.FullName)
                )
            .UseSnakeCaseNamingConvention()
        );


        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PlataformaIgrejaCristaDbContext>()
                .AddDefaultTokenProviders();

        services.AddScoped<IHashingService, Sha256HashingService>();

        return services;
    }
}
