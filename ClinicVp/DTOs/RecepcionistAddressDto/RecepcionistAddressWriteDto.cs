namespace ClinicVp.DTOs.RecepcionistAddressDto
{
    public class RecepcionistWritetAddressDto
    {

        public string City { get; set; }

        public string District { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Cep { get; set; }

        public int UfId { get; set; }

        public RecepcionistWritetAddressDto(string city, string district, string street, string number, string cep, int ufId)
        {
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
            UfId = ufId;
        }

    }
}
