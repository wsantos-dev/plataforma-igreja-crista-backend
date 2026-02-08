using PlataformaRedencao.Application.DTOs.Auth;
using PlataformaRedencao.Application.Services;

namespace PlataformaRedencao.API.Endpoints
{
    public static class AuthEndpoints
    {
        public static WebApplication MapAuthEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/auth")
                           .WithTags("Auth");

            group.MapPost("/cadastrar-usuario", CadastrarUsuarioAsync)
                 .WithName("CadastrarUsuario");

            group.MapPost("/login", LoginAsync)
                 .WithName("Login");

            return app;
        }

        private static async Task<IResult> LoginAsync(LoginRequestDTO requestDto, AuthService authService)
        {
            if (requestDto is null)
                return Results.BadRequest("Requisição inválida.");

            var usuario = await authService.LoginAsync(requestDto);
            return Results.Ok(usuario);
        }

        private static async Task<IResult> CadastrarUsuarioAsync(RegisterUserRequestDTO requestDto, AuthService authService)
        {
            await authService.CadastrarUsuarioAsync(requestDto);
            return Results.Ok();
        }
    }
}
