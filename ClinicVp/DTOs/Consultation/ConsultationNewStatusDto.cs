using ClinicVp.DataBase.Models.Enums;

namespace ClinicVp.DTOs.Consultation
{
    public class ConsultationNewStatusDto
    {

        public EStatusConsultation NewStatus { get; set; }

        public ConsultationNewStatusDto(EStatusConsultation newStatus)
        {
            NewStatus = newStatus;
        }

    }
}
