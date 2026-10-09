using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.DataBase.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync() => 
            await _context.Doctors.ToListAsync();

        public async Task<Doctor?> GetByIdAsync(int id) => 
            await _context.Doctors.FindAsync(id);

        public async Task AddAsync(Doctor entity)
        {
            await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Doctor entity)
        {
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var doctor = await GetByIdAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Doctor?> GetByCrmAsync(string crm, int crmUfId) =>
            await _context.Doctors.FirstOrDefaultAsync(d => d.Crm == crm && d.CrmUfId == crmUfId);

        public async Task<Doctor?> GetByCpfAsync(string cpf) =>
            await _context.Doctors.FirstOrDefaultAsync(d => d.Cpf == cpf);

        public async Task<IEnumerable<Doctor>> GetActiveDoctorsAsync() =>
            await _context.Doctors.Where(d => d.Status == EStatusEmployee.ACTIVE ).ToListAsync();
    }
}