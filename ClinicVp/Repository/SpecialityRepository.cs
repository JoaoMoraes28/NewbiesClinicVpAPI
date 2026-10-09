using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicVp.Repository
{
    public class SpecialityRepository : ISpeciality
    {

        private readonly AppDbContext _db;

        public SpecialityRepository(AppDbContext _context)
        {
            _db = _context;
        }

        public async Task<int> Add(Speciality speciality)
        {
            var response = await _db.Specialitys.AddAsync(speciality);
            await _db.SaveChangesAsync();

            return response.Entity.Id;
        }

        public async Task<List<Speciality>> GetAll()
        {
            return await _db.Specialitys.ToListAsync();
        }

    }
}
