using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.RRecepcionist
{
    public class RecepcionistAddressRepository : IRecepcoinistAddress
    {

        private readonly AppDbContext _db;

        public RecepcionistAddressRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task Add(RecepcionistAddress address)
        {
            Console.WriteLine(address.RecepcionistId);
            await _db.RecepcionistAddress.AddAsync(address);

            await _db.SaveChangesAsync();
        }

        public async Task<RecepcionistAddress?> Get(int idRecepcionist)
        {
            return await _db.RecepcionistAddress.FirstOrDefaultAsync(a => a.RecepcionistId == idRecepcionist);
        }

        public async Task Update(RecepcionistAddress address, RecepcionistAddress newAddress)
        {
            address.Cep = newAddress.Cep;
            address.City = newAddress.City;
            address.Number = newAddress.Number;
            address.Street = newAddress.Street;
            address.District = newAddress.District;
            address.UfId = newAddress.UfId;

            await _db.SaveChangesAsync();
        }
    }
}
