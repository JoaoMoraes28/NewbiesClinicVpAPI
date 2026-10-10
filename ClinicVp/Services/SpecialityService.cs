using ClinicVp.DataBase;
using ClinicVp.DataBase.Models;
using ClinicVp.DTOs;
using ClinicVp.Repository;

namespace ClinicVp.Services
{
    public class SpecialityService
    {

        private readonly ISpeciality _repository;
        private readonly AppDbContext _db;

        public SpecialityService(AppDbContext db, ISpeciality repository)
        {
            _repository = repository;
            _db = db;
        }

        public async Task<List<Speciality>> SelectSpeciality()
        {
            return await _repository.GetAll();
        }

        public async Task<int> InsertSpeciality(SpecialityDto specialityDto)
        {
            Speciality speciality = new(specialityDto.SpecialityName);

            var id = await _repository.Add(speciality);

            return id;
        }
    }
}
