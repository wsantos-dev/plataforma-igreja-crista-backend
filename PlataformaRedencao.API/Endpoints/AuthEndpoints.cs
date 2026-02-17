using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using PlataformaRedencao.Application.Exceptions;
using PlataformaRedencao.Domain.Messages;
using PlataformaRedencao.Infra.Identity.Entities;

namespace PlataformaRedencao.API.Endpoints;

public static class AuthEndpoints
{

    public record RegisterRequest(string Email, string Password);
    public record LoginRequest(string Email, string Password);

    public static void MapAuthEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/auth")
                       .WithTags("Auth");

        group.MapPost("/register", async (UserManager<ApplicationUser> userManager, RegisterRequest request) =>
        {
            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email
            };

            var result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return Results.BadRequest(result.Errors);

            return Results.Ok(new { user.Id, user.Email });
        })
        .WithDisplayName("Register");

        group.MapPost("/login", async (SignInManager<ApplicationUser> signInManager, LoginRequest request) =>
        {
            var result = await signInManager.PasswordSignInAsync(request.Email, request.Password, false, true);

            if (!result.Succeeded)
                throw new UnauthorizedOperationException("UNAUTHORIZED", ErrorMessages.UnauthorizedAccess);

            return Results.Ok(Messages.LoggedInSucess);
        })
        .WithDisplayName("Login");
    }
}
