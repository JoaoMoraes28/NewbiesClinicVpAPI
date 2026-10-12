using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models.Views
{
    public class RecepcionistData
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("admission_date")]
        public DateOnly AdmissionDate { get; set; }

        [Column("salary")]
        public decimal Salary { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("status")]
        public EStatusEmployee Status { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("photo")]
        public string? Photo { get; set; }

        [Column("gender")]
        public EGender Gender { get; set; }

        [Column("must_change_password")]
        public bool MustChangePassword { get; set; }

        [Column("uf_address")]
        public string UfAddress { get; set; }

        [Column("city")]
        public string City { get; set; }

        [Column("district")]
        public string District { get; set; }

        [Column("street")]
        public string Street { get; set; }

        [Column("number")]
        public string Number { get; set; }

        [Column("cep")]
        public string Cep { get; set; }

        public RecepcionistData(int id, string name, DateOnly admissionDate, decimal salary, string cpf, EStatusEmployee status, string phone,
            string email, string? photo, EGender gender, bool mustChangePassword, string ufAddress, string city, string district, string street,
            string number, string cep)
        {
            Id = id;
            Name = name;
            AdmissionDate = admissionDate;
            Salary = salary;
            Cpf = cpf;
            Status = status;
            Phone = phone;
            Email = email;
            Photo = photo;
            Gender = gender;
            MustChangePassword = mustChangePassword;
            UfAddress = ufAddress;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }

    }
}
