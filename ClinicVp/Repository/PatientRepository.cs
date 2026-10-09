using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.DataBase.Repositories
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

        public async Task AddAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
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

        public async Task<Patient?> GetByCpfAsync(string cpf) =>
            await _context.Patients.FirstOrDefaultAsync(p => p.Cpf == cpf);

        public async Task<IEnumerable<Patient>> GetActivePatientsAsync() =>
            await _context.Patients.Where(p => p.Active).ToListAsync();
    }
}