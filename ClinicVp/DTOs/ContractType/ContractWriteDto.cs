namespace ClinicVp.DTOs.ContractType
{
    public class ContractWriteDto
    {

        public string Contract { get; set; }

        public ContractWriteDto(string contract)
        {
            Contract = contract;
        }

    }
}
