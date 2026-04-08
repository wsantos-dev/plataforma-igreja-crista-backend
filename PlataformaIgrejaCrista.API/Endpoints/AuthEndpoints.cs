using PlataformaIgrejaCrista.Application.DTOs;
using PlataformaIgrejaCrista.Application.Interfaces;
using PlataformaIgrejaCrista.Domain.Entities;

namespace PlataformaIgrejaCrista.API.Endpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/auth")
                       .WithTags("Authentication");

        group.MapGet("/users", async (IIdentityService identityService) =>
        {
            var users = await identityService.GetAllUserAsync();
            return Results.Ok(users);

        })
        .WithDisplayName("GetAllUsers");

        group.MapPost("/register", async (IIdentityService identityService, UserDTO request) =>
        {
            var user = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var (accessToken, refreshToken) = await identityService.RegisterAsync(request.UserName, request.Password, request.Email);


            return Results.Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        })
        .WithDisplayName("Register");

        group.MapPost("/login", async (IIdentityService identityService, UserDTO request) =>
        {
            var (accessToken, refreshToken) = await identityService.LoginAsync(request.UserName, request.Password);

            return Results.Ok(new { AccessToken = accessToken, RefreshToken = refreshToken });
        })
        .WithDisplayName("Login");
    }
}
