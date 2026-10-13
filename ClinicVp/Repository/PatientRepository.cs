using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;
using Microsoft.EntityFrameworkCore;



namespace ClinicVp.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync() => 
            await _context.Patients.ToListAsync();

        public async Task<Patient?> GetByIdAsync(int id) => 
            await _context.Patients.FindAsync(id);

        public async Task<int> AddAsync(Patient entity)
        {
            var idPatient = await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
            return idPatient.Entity.Id;
        }

        public async Task UpdateAsync(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await GetByIdAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Patient>> GetActivePatientsAsync() =>
            await _context.Patients.Where(p => p.Active).ToListAsync();
    }
}