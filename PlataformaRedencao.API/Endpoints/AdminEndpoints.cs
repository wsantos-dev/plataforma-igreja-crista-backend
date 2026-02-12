
namespace PlataformaRedencao.API.Endpoints
{
    public static class AdminEndpoints
    {
        public static WebApplication MapAdminEndpoints(this WebApplication app)
        {
            Console.WriteLine("AdminEndpoints foi chamado");

            var group = app.MapGroup("/admin")
                           .WithTags("Admin");

            group.MapPost("/dashboard", (Delegate)AdminDashoard)
                 .WithName("AdminDashboard")
                 .WithSummary("Área Administrativa");

            return app;
        }
        private static IResult AdminDashoard(HttpContext context)
        {
            return Results.Ok("Administration Area");
        }
    }
}