using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository
{
    public class ConsultationRecordRepository : IConsultationRecord
    {

        private readonly AppDbContext _db;

        public ConsultationRecordRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<int> Add(ConsultationRecord consultationRecord)
        {
            var id = await _db.ConsultationsRecord.AddAsync(consultationRecord);

            return id.Entity.Id;
        }

        public async Task<List<ConsultationRecord>> GetAll(int id)
        {
            return await _db.ConsultationsRecord.Where(c => c.ConsultationId == id).ToListAsync();
        }
    }
}
