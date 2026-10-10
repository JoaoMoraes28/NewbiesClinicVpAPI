using ClinicVp.DataBase.Models.Enums;

namespace ClinicVp.DTOs
{
    public class RecepcionistDto
    {

        public string Name { get; set; }

        public decimal Salary { get; set; }

        public string Cpf { get; set; }

        public EStatusEmployee Status { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string? Photo { get; set; }

        public string Password { get; set; }

        public EGender Gender { get; set; }

        public RecepcionistDto(string name, decimal salary, string cpf, EStatusEmployee status, string phone, string email, string? photo, string password, EGender gender)
        {
            Name = name;
            Salary = salary;
            Cpf = cpf;
            Status = status;
            Phone = phone;
            Email = email;
            Photo = photo;
            Password = password;
            Gender = gender;
        }

    }
}
