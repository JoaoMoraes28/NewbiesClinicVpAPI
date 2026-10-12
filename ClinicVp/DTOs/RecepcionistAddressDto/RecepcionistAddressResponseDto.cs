namespace ClinicVp.DTOs.RecepcionistAddress
{
    public class RecepcionistAddressResponseDto
    {
        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Cep { get; set; }

        public string UfAddress { get; set; }

        public RecepcionistAddressResponseDto(string city, string district, string street, string number, string cep, string ufAddress)
        {
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
            UfAddress = ufAddress;
        }

    }
}
