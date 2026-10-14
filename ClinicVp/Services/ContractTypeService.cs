using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.ContractType;
using ClinicVp.DTOs.ResponsesDefault;
using ClinicVp.Repository.RContract;

namespace ClinicVp.Services
{
    public class ContractTypeService
    {

        private readonly IContractType _repository;

        public ContractTypeService(IContractType repository)
        {
            _repository = repository;
        }

        public async Task<List<ContractType>> SelectAllContracts()
        {
            return await _repository.Get();
        }

        private async Task<ContractType?> SelectEntityContractId(int id)
        {
            return await _repository.GetId(id) ?? throw new KeyNotFoundException();
        }

        public async Task<ResponseWriteDefault> InsertContract(ContractWriteDto body)
        {
            ContractType newContract = new(body.Contract);

            var contract = await _repository.Add(newContract);

            return new ResponseWriteDefault(contract.Id, "Novo contrato adicionado com sucesso.");
        }

        public async Task<ResponseDeleteDefault> DeleteContract(int id)
        {
            await SelectEntityContractId(id);

            await _repository.Delete(id);

            return new ResponseDeleteDefault("ContractType", $"Contrato de id {id} deletado com sucesso.");
        }
    }
}
