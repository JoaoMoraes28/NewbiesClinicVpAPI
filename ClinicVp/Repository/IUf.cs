using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public interface IUf
    {

        Task<List<Uf>> GetAll();

    }
}
