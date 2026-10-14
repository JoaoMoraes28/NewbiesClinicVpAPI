using ClinicVp.DataBase.Models;
using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DataBase.Models.Views;

namespace ClinicVp.Repository.RConsultation
{
    public interface IConsultation
    {

        Task<List<ConsultationData>> GetAll();

        Task<ConsultationData?> GetId(int id);

        Task<Consultation?> GetIdEntity(int id);

        Task<Consultation> Add(Consultation consultaiton);

        Task ChangeStatus(EStatusConsultation newStatus, Consultation consultation);

    }
}
