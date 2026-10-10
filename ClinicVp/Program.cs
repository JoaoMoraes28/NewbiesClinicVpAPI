using ClinicVp.ConfigurationExtensions;
using ClinicVp.Exceptions;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Injeção de dependência
builder.Services.AddAplicationServices();
// Configuração extra do banco de dados
builder.Services.AddDatabaseConfiguration();
// Atribuição do IExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionsHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();