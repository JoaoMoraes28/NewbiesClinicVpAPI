namespace ClinicVp.DataBase.DTOs.PatientAddress
{


    public class PatientAddressResponseDto
    {
        public string UfAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public string Cep { get; set; } = string.Empty;

        public PatientAddressResponseDto( string uf, string city, string district, string street, string number, string cep)
        {
            UfAddress = uf;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }
    }
}