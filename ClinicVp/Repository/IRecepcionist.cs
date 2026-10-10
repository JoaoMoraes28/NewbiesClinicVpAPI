using ClinicVp.DataBase.Models;
using ClinicVp.DTOs;

namespace ClinicVp.Repository
{
    public interface IRecepcionist
    {

        Task<int> Add(Recepcionist recepcionist);

        Task<List<Recepcionist>> GetAll();

        Task<Recepcionist?> GetId(int id);

        Task<Recepcionist> Update(Recepcionist recepcionist, RecepcionistDto newRecepcionist);

        Task Delete(Recepcionist recepcionist);
    }
}
