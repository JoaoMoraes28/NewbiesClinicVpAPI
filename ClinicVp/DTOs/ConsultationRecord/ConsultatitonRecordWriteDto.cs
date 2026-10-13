namespace ClinicVp.DTOs.ConsultationRecord
{
    public class ConsultatitonRecordWriteDto
    {

        public int ConsultationId { get; set; }

        public string Syntoms { get; set; }

        public string Treatment { get; set; }

        public string PatientNotes { get; set; }

        public string Diagnosis { get; set; }

        public string Notes { get; set; }

        public ConsultatitonRecordWriteDto(int consultationId, string syntoms, string treatment, string patientNotes, string diagnosis, string notes)
        {
            ConsultationId = consultationId;
            Syntoms = syntoms;
            Treatment = treatment;
            PatientNotes = patientNotes;
            Diagnosis = diagnosis;
            Notes = notes;
        }

    }
}
