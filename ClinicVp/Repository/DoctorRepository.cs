using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;
using Microsoft.EntityFrameworkCore;


namespace ClinicVp.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DoctorData>> GetAllAsync() =>
            await _context.DoctorsData.ToListAsync();

        public async Task<DoctorData?> GetByIdAsync(int id) =>
            await _context.DoctorsData.FindAsync(id);

        public async Task<int> AddAsync(Doctor entity)
        {
            var id = await _context.Doctors.AddAsync(entity);
            await _context.SaveChangesAsync();

            return id.Entity.Id;
        }

        public async Task UpdateAsync(Doctor entity)
        {
            _context.Doctors.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Doctor doctor)
        {
            doctor.Status = EStatusEmployee.DESACTIVE;

            await _context.SaveChangesAsync();
        }

        public async Task<Doctor?> GetByCrmAsync(string crm, int crmUfId) =>
            await _context.Doctors.FirstOrDefaultAsync(d => d.Crm == crm && d.CrmUfId == crmUfId);

        public async Task<Doctor?> GetByCpfAsync(string cpf) =>
            await _context.Doctors.FirstOrDefaultAsync(d => d.Cpf == cpf);

        public async Task<IEnumerable<Doctor>> GetActiveDoctorsAsync() =>
            await _context.Doctors.Where(d => d.Status == EStatusEmployee.ACTIVE).ToListAsync();

        public async Task<Doctor?> GetByEntityIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }
    }
}