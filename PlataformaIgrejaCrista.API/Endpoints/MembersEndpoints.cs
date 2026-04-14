using System.Security.Claims;
using PlataformaIgrejaCrista.Application.DTOs;
using PlataformaIgrejaCrista.Application.Interfaces;

namespace PlataformaIgrejaCrista.API.Endpoints
{
    public static class MembersEndpoints
    {
        public static void MapMembersEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/members")
                           .WithTags("Members");

            group.MapGet("/", async (IMemberService service) =>
            {
                var members = await service.GetMembersAsync();
                return Results.Ok(members);
            });

            group.MapPost("/create", async (
                CreateMemberRequestDTO request,
                IMemberService service,
                HttpContext httpContext) =>
            {
                var userId = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userId))
                    return Results.Unauthorized();

                var id = await service.CreateAsync(request, userId);

                return Results.Created($"/members/{id}", new { id });
            });
        }
    }
}