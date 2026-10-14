using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.ContractType;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository.RContractDoctor;

namespace ClinicVp.Services
{
    public class ContractDoctorService
    {

        private readonly IContractDoctor _repository;

        public ContractDoctorService(IContractDoctor repository)
        {
            _repository = repository;
        }

        private async Task<ContractDoctor?> SelectContractDoctorDoctorId(int doctorId)
        {
            return await _repository.GetId(doctorId) ?? throw new KeyNotFoundException();
        }

        public async Task<ResponseWriteDefault> InsertContractDoctor(ContractDoctorWrite body)
        {
            ContractDoctor newContractDoctor = new(body.ContractId, body.DoctorId);

            var contractDoctor = await _repository.Add(newContractDoctor);

            return new ResponseWriteDefault(contractDoctor.Id, "Novo contrato estabelecido com um doutor(a).");
        }

        public async Task<ResponseDeleteDefault> DeleteContractDoctor(int doctorId)
        {
            await SelectContractDoctorDoctorId(doctorId);

            await _repository.Delete(doctorId);

            return new ResponseDeleteDefault("ContractDoctor", $"Elo de contrato excluido com o doutor de id {doctorId}");
        }
    }
}
