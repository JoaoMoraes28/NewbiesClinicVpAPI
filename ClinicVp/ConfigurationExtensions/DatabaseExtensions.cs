using ClinicVp.DataBase;
using ClinicVp.DataBase.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json.Serialization;

namespace ClinicVp.ConfigurationExtensions
{
    public static class DatabaseExtensions
    {

        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services)
        {

            // URL do banco de dados
            var connectionString = $"{Environment.GetEnvironmentVariable("DATABASE_URL")}";
            var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionString);

            dataSourceBuilder.MapEnum<EGender>("gender_option");
            dataSourceBuilder.MapEnum<ECivilState>("civil_state_option");
            dataSourceBuilder.MapEnum<EBloodType>("blood_type_enum");
            dataSourceBuilder.MapEnum<EStatusEmployee>("status_doctor_recepcionist");

            var dataSource = dataSourceBuilder.Build();

            // Relaciona os ENUM`s do .NET com o do banco de dados
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(dataSource, o =>
                {
                    o.MapEnum<EGender>("gender_option");
                    o.MapEnum<ECivilState>("civil_state_option");
                    o.MapEnum<EBloodType>("blood_type_enum");
                    o.MapEnum<EStatusEmployee>("status_doctor_recepcionist");
                })
            );

            // Configura o formato do JSON para ENUM
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.Converters.Add(
                    new JsonStringEnumConverter(System.Text.Json.JsonNamingPolicy.CamelCase, allowIntegerValues: true)
                );
            });

            return services;

        }

    }
}
