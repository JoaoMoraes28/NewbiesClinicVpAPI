using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models.Views
{
    public class ConsultationData
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("patient_name")]
        public string PatientName { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("born_date")]
        public DateOnly BornDate { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        [Column("doctor_name")]
        public string DoctorName { get; set; }

        [Column("doctor_id")]
        public int DoctorId { get; set; }

        [Column("speciality_name")]
        public string SpecialityName { get; set; }

        [Column("consultation_date")]
        public DateOnly ConsultationDate { get; set; }

        [Column("hour")]
        public TimeOnly Hour { get; set; }

        [Column("status")]
        public EStatusConsultation Status { get; set; }

        public ConsultationData(int id, string patientName, string cpf, string photo, DateOnly bornDate, string notes,
            string phone, string doctorName, int doctorId, string specialityName, DateOnly consultationDate, TimeOnly hour,
            EStatusConsultation status)
        {
            Id = id;
            PatientName = patientName;
            Cpf = cpf;
            Photo = photo;
            BornDate = bornDate;
            Notes = notes;
            Phone = phone;
            DoctorName = doctorName;
            DoctorId = doctorId;
            SpecialityName = specialityName;
            ConsultationDate = consultationDate;
            Hour = hour;
            Status = status;
        }

    }
}
