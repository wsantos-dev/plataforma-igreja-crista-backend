using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace PlataformaRedencao.Infra.IoC.Configuration;

public static class IdentityConfiguration
{
    public static IServiceCollection AddIdentityConfiguration(
        this IServiceCollection services)
    {
        services.Configure<IdentityOptions>(options =>
        {
            options.Password.RequireDigit = true;
            options.Password.RequiredLength = 6;
            options.Password.RequireUppercase = true;
            options.User.RequireUniqueEmail = true;
        });

        return services;
    }

}
