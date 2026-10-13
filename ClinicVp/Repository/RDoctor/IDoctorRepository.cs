using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;

namespace ClinicVp.Repository.RDoctor
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<DoctorData>> GetAllAsync();
        Task<DoctorData?> GetByIdAsync(int id);
        Task<Doctor?> GetByEntityIdAsync(int id);
        Task<Doctor?> GetByCpfAsync(string cpf);
        Task<int> AddAsync(Doctor doctor);
        Task UpdateAsync(Doctor doctor);
        Task DeleteAsync(Doctor doctor);
    }
}