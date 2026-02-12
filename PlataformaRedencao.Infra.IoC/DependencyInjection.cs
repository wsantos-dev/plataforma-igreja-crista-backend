using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Application.Services;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.Data.Repositories;
using PlataformaRedencao.Application.Security;
using PlataformaRedencao.Infra.IoC.Security;

namespace PlataformaRedencao.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PlataformaRedencaoDbContext>(options =>
            options.UseNpgsql(
                configuration.GetConnectionString("PostgreSql"),
                p => p.MigrationsAssembly(typeof(PlataformaRedencaoDbContext)
                .Assembly.FullName)));

        // Repositories

        services.AddScoped<IChurchRepository, ChurchRepository>();
        services.AddScoped<IMemberRepository, MemberRepository>();
        services.AddScoped<IProfessionRepository, ProfessionRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IUserRepository, UserRepository>();


        // AutoMapper
        services.AddAutoMapper(typeof(DependencyInjection).Assembly);

        // Application services
        services.AddScoped<IChurchService, ChurchService>();
        services.AddScoped<IMemberService, MemberService>();
        services.AddScoped<IProfissionService, ProfissaoService>();
        services.AddScoped<IAddressService, AddressService>();

        // Security
        services.AddScoped<IPasswordHasher, BCryptPasswordHasher>();
        services.AddScoped<AuthService>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IRefreshTokenGenerator, RefreshTokenGenerator>();

        return services;
    }
}
