using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RPatient
{
    public class PatientAddressRepository : IPatientAddress
    {

        private readonly AppDbContext _db;

        public PatientAddressRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task AddAsync(PatientAddress address)
        {
            await _db.PatientAddresses.AddAsync(address);

            await _db.SaveChangesAsync();
        }
    }
}