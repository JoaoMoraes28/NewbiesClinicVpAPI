namespace ClinicVp.DTOs.DoctorAddress
{
    public class DoctorAddressResponseDto
    {
        public string UfAddress { get; set; }
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public DoctorAddressResponseDto(string ufAddress, string city, string district, string street, string number, string cep)
        {
            UfAddress = ufAddress;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }
    }
}