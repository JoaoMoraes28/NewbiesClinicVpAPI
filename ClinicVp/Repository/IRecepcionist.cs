using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;

namespace ClinicVp.Repository
{
    public interface IRecepcionist
    {

        Task<int> Add(Recepcionist recepcionist);

        Task<List<RecepcionistData>> GetAll();

        Task<RecepcionistData?> GetId(int id);

        Task<Recepcionist?> GetEntityId(int id);

        Task<Recepcionist> Update(Recepcionist recepcionist, Recepcionist newRecepcionist);

        Task Delete(Recepcionist recepcionist);
    }
}
