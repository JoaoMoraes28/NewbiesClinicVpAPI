using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.RContract
{
    public class ContractTypeRepository : IContractType
    {

        private readonly AppDbContext _db;

        public ContractTypeRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<ContractType> Add(ContractType contract)
        {
            var id = await _db.ContractTypes.AddAsync(contract);

            await _db.SaveChangesAsync();

            return id.Entity;
        }

        public async Task Delete(int id)
        {
            await _db.ContractTypes.Where(c => c.Id == id).ExecuteDeleteAsync();
        }

        public Task<List<ContractType>> Get()
        {
            return _db.ContractTypes.ToListAsync();
        }

        public async Task<ContractType?> GetId(int id)
        {
            return await _db.ContractTypes.FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
