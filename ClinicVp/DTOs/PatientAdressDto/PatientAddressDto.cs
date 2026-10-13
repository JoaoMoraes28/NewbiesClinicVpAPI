namespace ClinicVp.DataBase.DTOs
{
    public class PatientAddressCreateUpdateDto
    {
        public int PatientId { get; set; }
        public int UfId { get; set; }
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
    }

    public class PatientAddressResponseDto
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int UfId { get; set; }
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;
    }
}