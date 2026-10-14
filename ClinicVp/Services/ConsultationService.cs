using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;
using ClinicVp.DTOs.Consultation;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository.RConsultation;

namespace ClinicVp.Services
{
    public class ConsultationService
    {

        private readonly IConsultation _repository;

        public ConsultationService(IConsultation repository)
        {
            _repository = repository;
        }

        public async Task<List<ConsultationData>> SelectAllConsultation()
        {
            return await _repository.GetAll();
        }

        public async Task<ConsultationData> SelectConsultationId(int id)
        {
            return await _repository.GetId(id) ?? throw new KeyNotFoundException();
        }

        private async Task<Consultation?> SelectConsultationEntityId(int id)
        {
            return await _repository.GetIdEntity(id) ?? throw new KeyNotFoundException();
        }

        public async Task<ResponseWriteDefault> InsertConsultation(ConsultationWriteDto body)
        {
            Consultation consultation = new(body.PatientId, body.DoctorId, body.RecepcionistId, body.MedicalRecordId, body.SpecialityId,
                body.ConsultationDate, body.Hour, body.Status);

            var newConsultation = await _repository.Add(consultation);

            return new ResponseWriteDefault(newConsultation.Id, "Nova consulta criada com sucesso.");
        }

        public async Task<ResponseWriteDefault> UpdateStatusConsultation(int id, EStatusConsultation newStatus)
        {
            var consultation = await SelectConsultationEntityId(id);

            await _repository.ChangeStatus(newStatus, consultation);

            return new ResponseWriteDefault(id, $"Consulta de id {id} alterada para {newStatus}.");
        }

    }
}
