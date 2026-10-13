using ClinicVp.DataBase.DTOs;
using ClinicVp.DTOs.PatientDto;

namespace ClinicVp.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
        Task<PatientResponseDto?> GetPatientByIdAsync(int id);
        Task<PatientResponseDto> CreatePatientAsync(PatientWriteDto dto);
        Task<PatientResponseDto> UpdatePatientAsync(int id, PatientWriteDto dto);
        Task DeletePatientAsync(int id);
    }
}