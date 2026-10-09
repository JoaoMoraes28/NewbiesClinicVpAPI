using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public class SpecialityRepository : ISpeciality
    {

        private readonly AppDbContext _db;

        public SpecialityRepository(AppDbContext _context)
        {
            _db = _context;
        }

        public int Add(Speciality speciality)
        {
            var response = _db.Specialitys.Add(speciality);
            _db.SaveChanges();

            return response.Entity.Id;
        }

        public List<Speciality> GetAll()
        {
            return _db.Specialitys.ToList();
        }

    }
}
