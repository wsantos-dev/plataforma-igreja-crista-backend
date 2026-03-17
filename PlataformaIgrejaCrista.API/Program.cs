using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PlataformaRedencao.API.Endpoints;
using PlataformaRedencao.Application.Exceptions;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Domain.Exceptions;
using PlataformaRedencao.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


// Dependency injection
builder.Services.AddInfrastructure(builder.Configuration);


// Security
var jwtSettings = builder.Configuration.GetSection("Jwt");

var jwtKey = jwtSettings["Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("Jwt:Key não configurada.");

var key = Convert.FromBase64String(jwtKey);


builder.Services.AddAuthorization(options =>
{
    foreach (var role in Enum.GetNames(typeof(Roles)))
    {
        options.AddPolicy($"{role}Policy",
            policy => policy.RequireRole(role));
    }
});


// Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new()
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "Bearer",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Enter: Bearer { your token }"
    });

    c.AddSecurityRequirement(new()
    {
        {
            new()
            {
                Reference = new()
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Global error handling
builder.Services.AddProblemDetails();

var app = builder.Build();

// Swagger in development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        var exception = context.Features
            .Get<IExceptionHandlerFeature>()?
            .Error;

        var problemDetails = exception switch
        {
            UserNotFoundException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status404NotFound
            },

            MemberAlreadyExistsException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status409Conflict
            },

            ChurchNotFoundException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status404NotFound
            },

            InvalidCpfException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status400BadRequest
            },

            BusinessRuleValidationException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status400BadRequest
            },

            EntityNotFoundException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status404NotFound
            },

            ConflictException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status409Conflict
            },

            UseCaseValidationException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status400BadRequest
            },

            UnauthorizedAccessException ex => new ProblemDetails
            {
                Title = ex.Message,
                Status = StatusCodes.Status401Unauthorized
            },

            _ => new ProblemDetails
            {
                Title = "An unexpected error occurred.",
                Status = StatusCodes.Status500InternalServerError
            }
        };

        context.Response.StatusCode = problemDetails.Status!.Value;
        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});

app.MapErrorEndpoints();
app.MapAdminEndpoints();
app.MapAuthEndpoints();
app.MapMembersEndpoints();
app.MapChurchsEndpoints();
app.MapAddressEndpoints();
app.MapProfessionEndpoins();

app.Run();

