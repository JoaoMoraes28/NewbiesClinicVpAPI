using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;

namespace ClinicVp.Repository.RPatient
{

    public interface IPatientRepository
    {
        Task<IEnumerable<PatientData>> GetAllAsync();

        Task<PatientData?> GetByIdAsync(int id);

        Task<int> AddAsync(Patient patient);

        Task<Patient?> GetByEntityIdAsync(int id);

        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
    }
}