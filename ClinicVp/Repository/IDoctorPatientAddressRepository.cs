using ClinicVp.DataBase.Models;

namespace ClinicVp.DataBase.Repositories
{
    public interface IDoctorAddressRepository : IRepository<DoctorAddress>
    {
        Task<IEnumerable<DoctorAddress>> GetByDoctorIdAsync(int doctorId);
    }

    public interface IPatientAddressRepository : IRepository<PatientAddress>
    {
        Task<IEnumerable<PatientAddress>> GetByPatientIdAsync(int patientId);
    }
}