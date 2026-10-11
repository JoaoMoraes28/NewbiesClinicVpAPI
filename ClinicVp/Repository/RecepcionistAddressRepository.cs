using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.Repository;

namespace ClinicVp
{
    public class RecepcionistAddressRepository : IRecepcoinistAddress
    {

        private readonly AppDbContext _db;

        public RecepcionistAddressRepository(AppDbContext context)
        {
            _db = context;
        }

        public Task Add(RecepcionistAddress address)
        {
            throw new NotImplementedException();
        }

        public Task<RecepcionistAddress> Get(int idRecepcionist)
        {
            throw new NotImplementedException();
        }
    }
}
