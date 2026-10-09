using ClinicVp.DataBase.DTOs;

namespace ClinicVp.DataBase.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync();
        Task<DoctorResponseDto?> GetDoctorByIdAsync(int id);
        Task<DoctorResponseDto> CreateDoctorAsync(DoctorCreateUpdateDto dto);
        Task UpdateDoctorAsync(int id, DoctorCreateUpdateDto dto);
        Task DeleteDoctorAsync(int id);
    }
}