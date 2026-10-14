using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RSpeciality
{
    public interface ISpeciality
    {

        Task<int> Add(Speciality speciality);

        Task<List<Speciality>> GetAll();

    }
}
