using ClinicVp.DataBase.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicVp.DataBase.Models.Views
{
    public class DoctorData
    {

        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("admission_date")]
        public DateOnly AdmissionDate { get; set; }

        [Column("crm")]
        public string Crm { get; set; }

        [Column("cpf")]
        public string Cpf { get; set; }

        [Column("phone")]
        public string Phone { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("bio")]
        public string? Bio { get; set; }

        [Column("photo")]
        public string Photo { get; set; }

        [Column("status")]
        public EStatusEmployee Status { get; set; }

        [Column("gender")]
        public EGender Gender { get; set; }

        [Column("must_change_password")]
        public bool MustChangePassword { get; set; }

        [Column("contract")]
        public string Contract { get; set; }

        [Column("uf_crm")]
        public string UfCrm { get; set; }

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

        public DoctorData(
        int id, string name, DateOnly admissionDate, string crm, string cpf, string phone, string email,
        string? bio, string photo, EStatusEmployee status, EGender gender, bool mustChangePassword, string contract,
        string ufCrm, string ufAddress, string city, string district, string street, string number, string cep)
        {
            Id = id;
            Name = name;
            AdmissionDate = admissionDate;
            Crm = crm;
            Cpf = cpf;
            Phone = phone;
            Email = email;
            Bio = bio;
            Photo = photo;
            Status = status;
            Gender = gender;
            MustChangePassword = mustChangePassword;
            Contract = contract;
            UfCrm = ufCrm;
            UfAddress = ufAddress;
            City = city;
            District = district;
            Street = street;
            Number = number;
            Cep = cep;
        }
    }
}
