using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using PlataformaRedencao.Domain.Validation;

namespace PlataformaRedencao.API.Endpoints
{
    public static class ErrorEndpoints
    {
        public static WebApplication MapErrorEndpoints(this WebApplication app)
        {
            app.Map("/error", (HttpContext context) => 
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                return exception switch 
                {
                    DomainValidationException ex => Results.Problem(
                        title: "Requisição inválida.",
                        detail: ex.Message,
                        statusCode: StatusCodes.Status400BadRequest
                    ),
                    
                    _ => Results.Problem(
                        title: "Erro interno do servidor.",
                        detail: "Ocorreu um erro inesperado.",
                        statusCode: StatusCodes.Status500InternalServerError
                    )
                };
            })
            .WithTags("Error")
            .ExcludeFromDescription();

            return app;
        }
    }
}