using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RContractDoctor
{
    public interface IContractDoctor
    {

        Task<ContractDoctor> Add(ContractDoctor contractDoctor);

        Task<ContractDoctor?> GetId(int doctorId);

        Task Delete(int idDoctor);

    }
}
