using ClinicVp.Repository.RConsultationRecord;
using ClinicVp.Repository.RContract;
using ClinicVp.Repository.RContractDoctor;
using ClinicVp.Repository.RDoctor;
using ClinicVp.Repository.RPatient;
using ClinicVp.Repository.RRecepcionist;
using ClinicVp.Repository.RSpeciality;
using ClinicVp.Repository.RUf;
using ClinicVp.Services;

namespace ClinicVp.ConfigurationExtensions
{
    public static class ServiceExtensions
    {

        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IDoctorAddress, DoctorAddressRepository>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ISpeciality, SpecialityRepository>();
            services.AddScoped<IRecepcionist, RecepcionistRepository>();
            services.AddScoped<IUf, UfRepository>();
            services.AddScoped<IRecepcoinistAddress, RecepcionistAddressRepository>();
            services.AddScoped<IConsultationRecord, ConsultationRecordRepository>();
            services.AddScoped<IContractType, ContractTypeRepository>();
            services.AddScoped<IContractDoctor, ContractDoctorRepository>();
            services.AddScoped<SpecialityService>();
            services.AddScoped<RecepcionistService>();
            services.AddScoped<UfService>();
            services.AddScoped<ContractTypeService>();
            services.AddScoped<ContractDoctorService>();

            return services;
        }

    }
}
