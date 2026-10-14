using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("consultation")]
    public class Consultation
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("medical_record_id")]
        public int MedicalRecordId { get; set; }

        [Column("patient_id")]
        public int PatientId { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("speciality_id")]
        public int SpecialityId { get; set; }

        [Column("recepcionist_id")]
        public int RecepcionistId { get; set; }

        [Column("consultation_date")]
        public DateOnly ConsultationDate { get; set; }

        [Column("hour")]
        public TimeOnly Hour { get; set; }

        [Column("status")]
        public EStatusConsultation Status { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient? Patient { get; set; }

        [ForeignKey("DoctorId")]
        public virtual Doctor? Doctor { get; set; }

        [ForeignKey("SpecialityId")]
        public virtual Speciality? Speciality { get; set; }

        [ForeignKey("RecepcionistId")]
        public virtual Recepcionist? Recepcionist { get; set; }

        public Consultation(int patientId, int doctorId, int recepcionistId, int medicalRecordId, int specialityId,
            DateOnly consultationDate, TimeOnly hour, EStatusConsultation status)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            RecepcionistId = recepcionistId;
            MedicalRecordId = medicalRecordId;
            SpecialityId = specialityId;
            ConsultationDate = consultationDate;
            Hour = hour;
            Status = status;
        }
    }
}
