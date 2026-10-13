using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicVp.DTOs.DoctorDto;

namespace ClinicVp.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorResponseDto>> GetAllDoctorsAsync();
        Task<DoctorResponseDto?> GetDoctorByIdAsync(int id);
        Task<DoctorResponseDto> CreateDoctorAsync(DoctorWriteDto dto);
        Task<DoctorResponseDto> UpdateDoctorAsync(int id, DoctorWriteDto dto);
        Task DeleteDoctorAsync(int id);
    }
}