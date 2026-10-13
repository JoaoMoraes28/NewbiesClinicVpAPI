using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{

    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAllAsync();
        Task<Patient?> GetByIdAsync(int id);
        Task<int> AddAsync(Patient patient);

        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }
}