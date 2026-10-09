using ClinicVp.DataBase;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Repositories;
using ClinicVp.DataBase.Services;
using ClinicVp.Repository;
using ClinicVp.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json.Serialization;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

// Injeção de dependência
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ISpeciality, SpecialityRepository>();
builder.Services.AddScoped<SpecialityService>();
builder.Services.AddScoped<RecepcionistService>();
builder.Services.AddScoped<IRecepcionist, RecepcionistRepository>();
builder.Services.AddScoped<DbContext>();

var connectionString = $"{Environment.GetEnvironmentVariable("DATABASE_URL")}";
var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

dataSourceBuilder.MapEnum<EGender>("gender_option");
dataSourceBuilder.MapEnum<ECivilState>("civil_state_option");
dataSourceBuilder.MapEnum<EBloodType>("blood_type_enum");
dataSourceBuilder.MapEnum<EStatusEmployee>("status_doctor_recepcionist");

var dataSource = dataSourceBuilder.Build();

// Relaciona os ENUM`s do .NET com o do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(dataSource, o =>
    {
        o.MapEnum<EGender>("gender_option");
        o.MapEnum<ECivilState>("civil_state_option");
        o.MapEnum<EBloodType>("blood_type_enum");
        o.MapEnum<EStatusEmployee>("status_doctor_recepcionist");
    })
);

// Configura o formato do JSON para ENUM
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.Converters.Add(
        new JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase, allowIntegerValues: true)
    );
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();