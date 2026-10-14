using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.RConsultation
{
    public class ConsultationRepository : IConsultation
    {
        private readonly AppDbContext _db;

        public ConsultationRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<Consultation> Add(Consultation consultation)
        {
            var newConsultation = await _db.Consultations.AddAsync(consultation);
            await _db.SaveChangesAsync();

            return newConsultation.Entity;
        }

        public async Task ChangeStatus(EStatusConsultation newStatus, Consultation consultation)
        {
            consultation.Status = newStatus;
            await _db.SaveChangesAsync();
        }

        public async Task<List<ConsultationData>> GetAll()
        {
            return await _db.ConsultationsData.ToListAsync();
        }

        public async Task<ConsultationData?> GetId(int id)
        {
            return await _db.ConsultationsData.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Consultation?> GetIdEntity(int id)
        {
            return await _db.Consultations.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
