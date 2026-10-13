using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RDoctor
{
    public class DoctorAddressRepository : IDoctorAddress
    {

        private readonly AppDbContext _db;

        public DoctorAddressRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task AddAsync(DoctorAddress address)
        {
            await _db.DoctorAddresses.AddAsync(address);

            await _db.SaveChangesAsync();
        }
    }
}
