using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PlataformaRedencao.API.Endpoints;
using PlataformaRedencao.Domain.Enums;
using PlataformaRedencao.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


// Dependency injection
builder.Services.AddInfrastructure(builder.Configuration);


// Security
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),

        ClockSkew = TimeSpan.Zero

    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireRole("Admin"));

    options.AddPolicy("PastorOnly", policy =>
        policy.RequireRole(Roles.Pastor.ToString()));

    options.AddPolicy("TreasurerOnly", policy =>
        policy.RequireRole(Roles.Treasurer.ToString()));

    options.AddPolicy("FinanceCommitteeOnly", policy =>
        policy.RequireRole(Roles.FinanceCommittee.ToString()));

    options.AddPolicy("LeaderMinistrieOnly", policy =>
        policy.RequireRole(Roles.LeaderMinistrie.ToString()));

    options.AddPolicy("MemberWithMinistrieOnly", policy =>
        policy.RequireRole(Roles.MemberWithMinistrie.ToString()));

    options.AddPolicy("MemberWithoutMinistrieOnly", policy =>
        policy.RequireRole(Roles.MemberWithoutMinistrie.ToString()));
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

app.UseExceptionHandler();
app.MapErrorEndpoints();
app.MapAuthEndpoints();
app.MapAdminEndpoints();

app.Run();

