using ClinicVp.DataBase.Models;

namespace ClinicVp.Repository
{
    public interface IConsultationRecord
    {
        Task<List<ConsultationRecord>> GetAll(int id);

        Task<int> Add(ConsultationRecord consultationRecord);
    }
}
