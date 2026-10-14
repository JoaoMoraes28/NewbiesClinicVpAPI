using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RDoctor
{
    public interface IDoctorAddress
    {

        Task AddAsync(DoctorAddress address);

    }
}
