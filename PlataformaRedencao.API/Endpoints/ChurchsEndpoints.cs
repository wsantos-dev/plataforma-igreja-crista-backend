namespace PlataformaRedencao.API.Endpoints
{
    public static class ChurchsEndpoints
    {
        public static void MapChurchsEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/churchs")
                           .WithTags("Churchs");

            group.MapPost("/create", async () =>
            {

            });
        }
    }
}