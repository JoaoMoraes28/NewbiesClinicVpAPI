using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.ConsultationRecord;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository.RConsultationRecord;

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

        public async Task<ResponseWriteDefault> InsertConsultationRecord(ConsultatitonRecordWriteDto body)
        {
            ConsultationRecord newConsultationRecord = new(body.ConsultationId,
                body.Syntoms, body.Diagnosis, body.Treatment, body.PatientNotes, body.Notes);

            var id = await _repository.Add(newConsultationRecord);

            return new ResponseWriteDefault(id, "Registro da consulta salva com sucesso.");
        }

    }
}
