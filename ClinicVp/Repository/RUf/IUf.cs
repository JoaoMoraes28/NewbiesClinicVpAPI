using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RUf
{
    public interface IUf
    {

        Task<List<Uf>> GetAll();

    }
}
