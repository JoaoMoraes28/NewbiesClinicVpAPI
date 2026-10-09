using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public interface ISpeciality
    {

        Task<int> Add(Speciality speciality);

        Task<List<Speciality>> GetAll();

    }
}
