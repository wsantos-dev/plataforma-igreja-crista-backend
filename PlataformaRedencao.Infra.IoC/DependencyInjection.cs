using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlataformaRedencao.Domain.Interfaces;
using PlataformaRedencao.Application.Interfaces;
using PlataformaRedencao.Application.Services;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.Data.Repositories;

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

        services.AddScoped<IIgrejaRepository, IgrejaRepository>();
        services.AddScoped<IMembroRepository, MembroRepository>();
        services.AddScoped<IProfissaoRepository, ProfissaoRepository>();
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();

        // Application services
        services.AddScoped<IIgrejaService, IgrejaService>();
        services.AddScoped<IMembroService, MembroService>();
        services.AddScoped<IProfissaoService, ProfissaoService>();
        services.AddScoped<IEnderecoService, EnderecoService>();

        return services;
    }
}
