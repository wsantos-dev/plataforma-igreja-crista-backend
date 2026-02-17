using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlataformaRedencao.Application.DTOs;
using PlataformaRedencao.Application.Interfaces;

namespace PlataformaRedencao.API.Endpoints
{
    public static class AddressEndpoints
    {
        public static void MapAddressEndpoints(this WebApplication app)
        {
            var group = app.MapGroup("/address")
                           .WithTags("Address");

            group.MapGet("/", async (IAddressService service) =>
            {
                var addresses = await service.GetAddressAsync();
                return Results.Ok(addresses);
            });

            group.MapGet("/{id:int}", async (int id, IAddressService service) =>
            {
                var address = await service.GetByIdAsync(id);
                return address is null ? Results.NotFound() : Results.Ok(address);
            });

            group.MapPut("/update/{id:int}", async (int id, AddressDTO dto, IAddressService service) =>
            {
                if (id != dto.Id)
                    return Results.BadRequest("ID mismatch");

                await service.UpdateAsync(dto);
                return Results.NoContent();
            });
        }
    }
}