namespace ClinicVp.DTOs.ContractType
{
    public class ContractDoctorWrite
    {

        public int ContractId { get; set; }

        public int DoctorId { get; set; }

        public ContractDoctorWrite(int contractId, int doctorId)
        {
            ContractId = contractId;
            DoctorId = doctorId;
        }

    }
}
