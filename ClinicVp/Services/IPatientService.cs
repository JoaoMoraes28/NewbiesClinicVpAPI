using ClinicVp.DataBase.DTOs;

namespace ClinicVp.DataBase.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
        Task<PatientResponseDto?> GetPatientByIdAsync(int id);
        Task<PatientResponseDto> CreatePatientAsync(PatientCreateUpdateDto dto);
        Task UpdatePatientAsync(int id, PatientCreateUpdateDto dto);
        Task DeletePatientAsync(int id);
    }
}