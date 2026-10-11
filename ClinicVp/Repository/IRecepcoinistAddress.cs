using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public interface IRecepcoinistAddress
    {

        Task<RecepcionistAddress> Get(int idRecepcionist);

        Task Add(RecepcionistAddress address);

    }
}
