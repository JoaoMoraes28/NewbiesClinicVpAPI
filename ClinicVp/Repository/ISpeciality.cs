using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public interface ISpeciality
    {

        int Add(Speciality speciality);

        List<Speciality> GetAll();

    }
}
