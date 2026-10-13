namespace ClinicVp.DTOs.DoctorAddressDto
{
    public class DoctorAddressWriteDto
    {
        public int DoctorId { get; set; }
        public int UfId { get; set; }
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public DoctorAddressWriteDto(int doctorId, int ufId, string city, string district, string street, string number, string cep)
        {
            DoctorId = doctorId;
            UfId = ufId;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }
    }

}