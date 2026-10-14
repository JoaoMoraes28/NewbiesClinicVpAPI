using ClinicVp.DTOs.DoctorDto;
using ClinicVp.DTOs.ResponsesDefault;

namespace ClinicVp.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync();
        Task<DoctorResponseDto?> GetDoctorByIdAsync(int id);
        Task<ResponseWriteEmployee> CreateDoctorAsync(DoctorWriteDto dto);
        Task<DoctorResponseDto> UpdateDoctorAsync(int id, DoctorWriteDto dto);
        Task<ResponseDeleteDefault> DeleteDoctorAsync(int id);
    }
}