using ClinicVp.DataBase.Models;
using ClinicVp.DTOs.Speciality;
using ClinicVp.Repository;

namespace ClinicVp.Services
{
    public class SpecialityService
    {

        private readonly ISpeciality _repository;


        public SpecialityService(ISpeciality repository)
        {
            _repository = repository;
        }

        public async Task<List<Speciality>> SelectSpeciality()
        {
            return await _repository.GetAll();
        }

        public async Task<List<Speciality>> SelectSpecialityId(int id)
        {
            return await _repository.GetAll();
        }

        public async Task<int> InsertSpeciality(SpecialityCreateDto specialityDto)
        {
            Speciality speciality = new(specialityDto.SpecialityName);

            var id = await _repository.Add(speciality);

            return id;
        }
    }
}
