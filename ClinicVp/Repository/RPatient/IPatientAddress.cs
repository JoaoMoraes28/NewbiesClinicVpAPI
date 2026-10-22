using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RPatient
{
    public interface IPatientAddress
    {
        Task AddAsync(PatientAddress address);
        Task UpdateAsync(PatientAddress address);
        Task<PatientAddress?> GetId(int patientId);
    }
}
