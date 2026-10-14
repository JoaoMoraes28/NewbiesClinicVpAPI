using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository.RPatient
{
    public interface IPatientAddress
    {
        Task AddAsync(PatientAddress address);
    }
}
