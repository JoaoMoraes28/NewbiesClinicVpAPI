using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.Recepcionist;

namespace ClinicVp.Repository
{
    public interface IRecepcionist
    {

        Task<int> Add(Recepcionist recepcionist);

        Task<List<Recepcionist>> GetAll();

        Task<List<Recepcionist>> GetId(int id);

        Task<Recepcionist> Update(Recepcionist recepcionist, RecepcionistCreateDto newRecepcionist);

        Task Delete(int id);
    }
}
