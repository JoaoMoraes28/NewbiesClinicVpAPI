using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models
{
    [Table("consultation_record")]
    public class ConsultationRecord
    {

        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("consultation_id")]
        public int ConsultationId { get; set; }

        [Column("syntoms")]
        public string Syntoms { get; set; }

        [Column("diagnosis")]
        public string Diagnosis { get; set; }

        [Column("treatment")]
        public string Treatment { get; set; }

        [Column("patient_notes")]
        public string PatientNotes { get; set; }

        [Column("notes")]
        public string Notes { get; set; }

        public ConsultationRecord(int consultationId, string syntoms, string diagnosis, string treatment, string patientNotes, string notes)
        {
            ConsultationId = consultationId;
            Syntoms = syntoms;
            Diagnosis = diagnosis;
            Treatment = treatment;
            PatientNotes = patientNotes;
            Notes = notes;
        }

    }
}
