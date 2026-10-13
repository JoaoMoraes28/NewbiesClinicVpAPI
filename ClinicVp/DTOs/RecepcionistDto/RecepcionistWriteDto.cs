using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DTOs.RecepcionistAddressDto;

namespace ClinicVp.DTOs.RecepcionistDto
{
    public class RecepcionistWriteDto
    {

        public RecepcionistBase Recepcionist { get; set; }

        public RecepcionistWritetAddressDto Address { get; set; }

        public RecepcionistWriteDto(RecepcionistBase recepcionist, RecepcionistWritetAddressDto address)
        {
            Recepcionist = recepcionist;
            Address = address;
        }

    }

    public class RecepcionistBase
    {

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Cpf { get; set; }

        public EStatusEmployee Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string? Photo { get; set; }

        public EGender Gender { get; set; }

        public RecepcionistBase(string name, decimal salary, string cpf, EStatusEmployee status, string phone, string email, string? photo, EGender gender)
        {
            Name = name;
            Salary = salary;
            Cpf = cpf;
            Status = status;
            Phone = phone;
            Email = email;
            Photo = photo;
            Gender = gender;
        }

    }
}
