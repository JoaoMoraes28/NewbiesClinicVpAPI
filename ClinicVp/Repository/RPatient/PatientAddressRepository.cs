using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<PatientAddress?> GetId(int patientId)
        {
            return await _db.PatientAddresses.FirstOrDefaultAsync(a => a.PatientId == patientId);
        }

        public async Task UpdateAsync(PatientAddress address)
        {
            _db.PatientAddresses.Update(address);
            await _db.SaveChangesAsync();
        }
    }
}