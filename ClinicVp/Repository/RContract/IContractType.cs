using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RContract
{
    public interface IContractType
    {

        Task<List<ContractType>> Get();

        Task<ContractType?> GetId(int id);

        Task<ContractType> Add(ContractType contract);

        Task Delete(int id);

    }
}
