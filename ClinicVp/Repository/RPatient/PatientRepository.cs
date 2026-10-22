using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Views;
using ClinicVp.DTOs.PatientDto;
using Microsoft.EntityFrameworkCore;



namespace ClinicVp.Repository.RPatient
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PatientData>> GetAllAsync() =>
            await _context.PatientsData.Where(p => p.Active == true).ToListAsync();

        public async Task<PatientData?> GetByIdAsync(int id) =>
            await _context.PatientsData.FirstOrDefaultAsync(p => p.Id == id && p.Active == true);

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

        public async Task DeleteAsync(Patient patient)
        {
            patient.Active = false;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PatientData>> GetActivePatientsAsync() =>
            await _context.PatientsData.Where(p => p.Active == true).ToListAsync();


        public async Task<Patient?> GetByEntityIdAsync(int id)
        {
            return await _context.Patients.Where(p => p.Active).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<PatientResponsePreviewDto>> GetAllPatientPreview()
        {
            return await _context.Patients.Where(p => p.Active).OrderBy(p => p.Name).Select(p => new PatientResponsePreviewDto(p.Id, p.Name, p.Photo, p.Cpf, p.Phone)).ToListAsync();
        }
    }
}