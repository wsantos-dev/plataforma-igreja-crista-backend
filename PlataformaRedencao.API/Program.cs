using Microsoft.EntityFrameworkCore;
using PlataformaRedencao.API.Endpoints;
using PlataformaRedencao.Infra.Data.Context;
using PlataformaRedencao.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);


// Injeção de Dependência
builder.Services.AddInfrastructure(builder.Configuration);

// Adiciona suporte ao Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


/*builder.Services.AddDbContext<PlataformaRedencaoDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("PostgreSql")
    )
);*/

// erros globais
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configuração do Swagger no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseExceptionHandler();
app.MapErrorEndpoints();
app.MapAuthEndpoints();

app.Run();

