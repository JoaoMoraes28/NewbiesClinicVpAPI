using ClinicVp.DTOs.PatientDto;
using ClinicVp.DTOs.ResponsesDefault;

namespace ClinicVp.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<PatientResponseDto>> GetAllPatientsAsync();
        Task<IEnumerable<PatientResponsePreviewDto>> GetAllPatientsPreviewAsync();
        Task<PatientResponseDto?> GetPatientByIdAsync(int id);
        Task<ResponseWriteDefault> CreatePatientAsync(PatientWriteDto dto);
        Task<PatientResponseDto> UpdatePatientAsync(int id, PatientWriteDto dto);
        Task<ResponseDeleteDefault> DeletePatientAsync(int id);
    }
}