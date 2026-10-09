using ClinicVp.DataBase.Models;

namespace ClinicVp.DataBase.Repositories
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor?> GetByCrmAsync(string crm, int crmUfId);
        Task<Doctor?> GetByCpfAsync(string cpf);
        Task<IEnumerable<Doctor>> GetActiveDoctorsAsync();
    }
}