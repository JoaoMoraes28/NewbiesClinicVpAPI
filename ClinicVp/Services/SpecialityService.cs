using ClinicVp.DataBase.Models;
using ClinicVp.DTOs;
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

        public List<Speciality> SelectSpeciality()
        {
            return _repository.GetAll();
        }

        public List<Speciality> SelectSpecialityId(int id)
        {
            return _repository.GetAll();
        }

        public int InsertSpeciality(SpecialityCreateDto specialityDto)
        {
            Speciality speciality = new(specialityDto.SpecialityName);

            var id = _repository.Add(speciality);

            return id;
        }
    }
}
