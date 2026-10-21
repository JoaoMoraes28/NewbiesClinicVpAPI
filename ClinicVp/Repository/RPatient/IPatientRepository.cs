using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;
using ClinicVp.DTOs.PatientDto;

namespace ClinicVp.Repository.RPatient
{

    public interface IPatientRepository
    {
        Task<IEnumerable<PatientData>> GetAllAsync();

        Task<IEnumerable<PatientResponsePreviewDto>> GetAllPatientPreview();

        Task<PatientData?> GetByIdAsync(int id);

        Task<int> AddAsync(Patient patient);

        Task<Patient?> GetByEntityIdAsync(int id);

        Task UpdateAsync(Patient patient);
        Task DeleteAsync(Patient patient);
    }
}