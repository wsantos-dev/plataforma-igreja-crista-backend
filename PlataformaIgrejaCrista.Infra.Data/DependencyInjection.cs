using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Domain.Entities;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.Data.Security;

namespace PlataformaRedencao.Infra.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataInfrastructure(
       this IServiceCollection services,
       IConfiguration configuration)
    {
        services.AddDbContext<PlataformaRedencaoDbContext>(options =>
               options.UseNpgsql(
                   configuration.GetConnectionString("PostgreSql"),
                   p => p.MigrationsAssembly(typeof(PlataformaRedencaoDbContext)
                   .Assembly.FullName)
                )
            .UseSnakeCaseNamingConvention()
        );


        services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<PlataformaRedencaoDbContext>()
                .AddDefaultTokenProviders();

        services.AddScoped<IHashingService, Sha256HashingService>();

        return services;
    }
}
