using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.RContractDoctor
{
    public class ContractDoctorRepository : IContractDoctor
    {
        private readonly AppDbContext _db;

        public ContractDoctorRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<ContractDoctor> Add(ContractDoctor contractDoctor)
        {
            var response = await _db.ContractsDoctor.AddAsync(contractDoctor);
            await _db.SaveChangesAsync();

            return response.Entity;
        }

        public async Task Delete(int idDoctor)
        {
            await _db.ContractsDoctor.Where(c => c.DoctorId == idDoctor).ExecuteDeleteAsync();
        }

        public async Task<ContractDoctor?> GetId(int doctorId)
        {
            return await _db.ContractsDoctor.FirstOrDefaultAsync(c => c.DoctorId == doctorId);
        }
    }
}
