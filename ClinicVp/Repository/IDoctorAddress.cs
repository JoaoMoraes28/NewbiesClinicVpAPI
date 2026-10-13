using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public interface IDoctorAddress
    {

        Task AddAsync(DoctorAddress address);

    }
}
