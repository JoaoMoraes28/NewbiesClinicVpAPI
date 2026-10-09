using ClinicVp.DataBase;
using ClinicVp.DataBase.Repositories;
using ClinicVp.DataBase.Services;
using ClinicVp.Repository;
using ClinicVp.Services;
using Microsoft.EntityFrameworkCore;

DotNetEnv.Env.Load();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

// Injeção de dependência
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<ISpeciality, SpecialityRepository>();
builder.Services.AddScoped<SpecialityService>();
builder.Services.AddScoped<DbContext>();

var connectionString = $"{Environment.GetEnvironmentVariable("DATABASE_URL")}";

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();