using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.DataBase
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<Speciality> Specialitys { get; set; }
        public DbSet<Uf> Ufs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorData> DoctorsData { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<DoctorAddress> DoctorAddresses { get; set; }
        public DbSet<PatientAddress> PatientAddresses { get; set; }
        public DbSet<Recepcionist> Recepcionists { get; set; }
        public DbSet<RecepcionistData> RecepcionistData { get; set; }
        public DbSet<RecepcionistAddress> RecepcionistAddress { get; set; }
        public DbSet<ConsultationRecord> ConsultationsRecord { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<ContractDoctor> ContractsDoctor { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<ConsultationData> ConsultationsData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecepcionistData>().HasNoKey().ToView("recepcionist_data");
            modelBuilder.Entity<DoctorData>().HasNoKey().ToView("doctor_data");
            modelBuilder.Entity<ConsultationData>().HasNoKey().ToView("consultation_data");
        }

    }
}
