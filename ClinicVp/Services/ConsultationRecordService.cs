using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.ConsultationRecord;
using ClinicVp.Repository;

namespace ClinicVp.Services
{
    public class ConsultationRecordService
    {

        private readonly AppDbContext _db;
        private readonly IConsultationRecord _repository;

        public ConsultationRecordService(AppDbContext context, IConsultationRecord repository)
        {
            _repository = repository;
            _db = context;
        }

        public async Task<List<ConsultationRecord>> SelectConsultationRecordIdConsultation(int id)
        {
            return await _repository.GetAll(id);
        }

        public async Task<int> InsertConsultationRecord(ConsultatitonRecordWriteDto body)
        {
            ConsultationRecord newConsultationRecord = new(body.ConsultationId,
                body.Syntoms, body.Diagnosis, body.Treatment, body.PatientNotes, body.Notes);

            var id = await _repository.Add(newConsultationRecord);

            return id;
        }

    }
}
