using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository.RUf
{
    public class UfRepository : IUf
    {
        private readonly AppDbContext _db;

        public UfRepository(AppDbContext context)
        {
            _db = context;
        }

        public async Task<List<Uf>> GetAll()
        {

            return await _db.Ufs.ToListAsync();

        }

    }
}
