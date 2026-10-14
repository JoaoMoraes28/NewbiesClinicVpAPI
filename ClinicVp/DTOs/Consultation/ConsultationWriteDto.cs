using ClinicVp.DataBase.Models.Enums;

namespace ClinicVp.DTOs.Consultation
{
    public class ConsultationWriteDto
    {

        public int MedicalRecordId { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public int SpecialityId { get; set; }

        public int RecepcionistId { get; set; }

        public DateOnly ConsultationDate { get; set; }

        public TimeOnly Hour { get; set; }

        public EStatusConsultation Status { get; set; } = EStatusConsultation.SCHEDULED;

        public ConsultationWriteDto(int medicalRecordId, int patientId, int doctorId, int specialityId, int recepcionistId,
            DateOnly consultationDate, TimeOnly hour, EStatusConsultation status)
        {
            MedicalRecordId = medicalRecordId;
            PatientId = patientId;
            DoctorId = doctorId;
            SpecialityId = specialityId;
            RecepcionistId = recepcionistId;
            ConsultationDate = consultationDate;
            Hour = hour;
            Status = status;
        }
    }
}
