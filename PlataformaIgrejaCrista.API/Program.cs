using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using PlataformaIgrejaCrista.API.Endpoints;
using PlataformaIgrejaCrista.Application.Exceptions;
using PlataformaIgrejaCrista.Domain.Enums;
using PlataformaIgrejaCrista.Domain.Exceptions;
using PlataformaIgrejaCrista.Infra.IoC;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Dependency injection
builder.Services.AddInfrastructure(builder.Configuration);

var jwtSettings = builder.Configuration.GetSection("Jwt");
var jwtKey = jwtSettings["Key"];

if (string.IsNullOrWhiteSpace(jwtKey))
    throw new InvalidOperationException("Jwt:Key não configurada.");

var key = Convert.FromBase64String(jwtKey);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
        };
    });

builder.Services.AddAuthorization(options =>
{
    foreach (var role in Enum.GetNames(typeof(Roles)))
    {
        options.AddPolicy($"{role}Policy",
            policy => policy.RequireRole(role));
    }
});

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Components ??= new OpenApiComponents();

        // definição do scheme
        document?.Components.SecuritySchemes?["Bearer"] = new OpenApiSecurityScheme
        {
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Name = "Authorization",
            Description = "Bearer {token}"
        };

        document?.Security ??= new List<OpenApiSecurityRequirement>();

        var requirement = new OpenApiSecurityRequirement();

        var schemeReference = new OpenApiSecuritySchemeReference("Bearer");

        requirement.Add(schemeReference, new List<string>());

        document?.Security?.Add(requirement);

        return Task.CompletedTask;
    });
});



// Global error handling
builder.Services.AddProblemDetails();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
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

// Endpoints
app.MapAdminEndpoints();
app.MapAuthEndpoints();
app.MapMembersEndpoints();
app.MapChurchsEndpoints();
app.MapAddressEndpoints();
app.MapProfessionEndpoins();

app.Run();

public partial class Program { }