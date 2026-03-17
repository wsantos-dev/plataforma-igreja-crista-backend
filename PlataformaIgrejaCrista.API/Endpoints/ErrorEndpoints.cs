using Microsoft.AspNetCore.Diagnostics;
using PlataformaIgrejaCrista.Domain.Validation;

namespace PlataformaIgrejaCrista.API.Endpoints
{
    /// <summary>
    /// Global error handling endpoint; maps domain and server errors to Problem Details responses.
    /// </summary>
    public static class ErrorEndpoints
    {
        /// <summary>
        /// Maps the global error handler endpoint.
        /// </summary>
        /// <param name="app">The <see cref="WebApplication"/> to map the endpoint on.</param>
        /// <returns>The <see cref="WebApplication"/> for chaining.</returns>
        public static WebApplication MapErrorEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("/errors")
                           .WithTags("Error");


            group.Map("/error", (HttpContext context) =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

                return exception switch
                {
                    DomainValidationException ex => Results.Problem(
                        title: "Invalid request.",
                        detail: ex.Message,
                        statusCode: StatusCodes.Status400BadRequest
                    ),

                    _ => Results.Problem(
                        title: "Internal server error.",
                        detail: "An unexpected error occurred.",
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