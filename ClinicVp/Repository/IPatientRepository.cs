using ClinicVp.DataBase.Models;

namespace ClinicVp.DataBase.Repositories
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient?> GetByCpfAsync(string cpf);
        Task<IEnumerable<Patient>> GetActivePatientsAsync();
    }
}