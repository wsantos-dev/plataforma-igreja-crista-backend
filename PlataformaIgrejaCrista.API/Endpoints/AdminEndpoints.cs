namespace PlataformaIgrejaCrista.API.Endpoints
{
    public static class AdminEndpoints
    {
        public static WebApplication MapAdminEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/admin")
                           .WithTags("Admin")
                           .RequireAuthorization("AdminOnly");

            group.MapPost("/dashboard", (HttpContext context) =>
            {

                return Results.Ok("Administration Area");
            })
            .WithName("AdminDashboard")
            .WithSummary("Área Administrativa");

            return app;
        }
    }
}