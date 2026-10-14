using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RRecepcionist
{
    public interface IRecepcoinistAddress
    {

        Task<RecepcionistAddress?> Get(int idRecepcionist);

        Task Add(RecepcionistAddress address);

        Task Update(RecepcionistAddress? address, RecepcionistAddress newAddress);

    }
}
