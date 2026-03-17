using PlataformaRedencao.Application.Interfaces;

namespace PlataformaRedencao.API.Endpoints
{
    public static class ProfessionEndpoints
    {
        public static void MapProfessionEndpoins(this WebApplication app)
        {
            var group = app.MapGroup("/professions")
                           .WithTags("Professions");

            group.MapGet("/", async (IProfissionService service) =>
            {
                var professions = await service.GetProfessionsAsync();
                return Results.Ok(professions);
            });

            group.MapGet("/{id:int}", async (
                int id,
                IProfissionService service) =>
            {
                var profession = await service.GetByIdAsync(id);

                return Results.Ok(profession);

            });
        }
    }
}