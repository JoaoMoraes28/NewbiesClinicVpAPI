using ClinicVp.DataBase.Repositories;
using ClinicVp.DataBase.Services;
using ClinicVp.Repository;
using ClinicVp.Services;

namespace ClinicVp.ConfigurationExtensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ISpeciality, SpecialityRepository>();
            services.AddScoped<IRecepcionist, RecepcionistRepository>();
            services.AddScoped<IUf, UfRepository>();
            services.AddScoped<IRecepcoinistAddress, RecepcionistAddressRepository>();
            services.AddScoped<SpecialityService>();
            services.AddScoped<RecepcionistService>();
            services.AddScoped<UfService>();

            return services;
        }

    }
}
