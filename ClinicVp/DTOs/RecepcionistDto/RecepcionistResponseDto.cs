using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DTOs.RecepcionistAddress;

namespace ClinicVp.DTOs.RecepcionistDto
{
    public class RecepcionistResponseBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Cpf { get; set; }

        public EStatusEmployee Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string? Photo { get; set; }

        public EGender Gender { get; set; }

        public DateOnly AdmissionDate { get; set; }

        public RecepcionistResponseBase(int id, string name, decimal salary, string cpf, DateOnly admissionDate, EStatusEmployee status, string phone, string email, string? photo, EGender gender)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Cpf = cpf;
            Status = status;
            Phone = phone;
            Email = email;
            Photo = photo;
            Gender = gender;
            AdmissionDate = admissionDate;
        }
    }

    public class RecepcionistResponseDto
    {
        public RecepcionistResponseBase Recepcionist { get; set; }

        public RecepcionistAddressResponseDto Address { get; set; }

        public RecepcionistResponseDto(RecepcionistResponseBase recepcionist, RecepcionistAddressResponseDto address)
        {
            Recepcionist = recepcionist;
            Address = address;
        }
    }

}