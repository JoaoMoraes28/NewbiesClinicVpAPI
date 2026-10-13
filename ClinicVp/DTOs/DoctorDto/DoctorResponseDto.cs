using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DTOs.DoctorAddress;

namespace ClinicVp.DTOs.DoctorDto
{
    public class DoctorResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Crm { get; set; }
        public string CrmUf { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Photo { get; set; }
        public EGender Gender { get; set; }
        public EStatusEmployee Status { get; set; }
        public string? Bio { get; set; }
        public DateOnly AdmissionDate { get; set; }

        public DoctorResponseBase(int id, string name, string crm, string crmUf, string cpf, string email, string phone, string? photo, EGender gender, EStatusEmployee status, string? bio, DateOnly admissionDate)
        {
            Id = id;
            Name = name;
            Crm = crm;
            CrmUf = crmUf;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            Photo = photo;
            Gender = gender;
            Status = status;
            Bio = bio;
            AdmissionDate = admissionDate;
        }
    }

    public class DoctorResponseDto
    {
        public DoctorResponseBase Doctor { get; set; }

        public DoctorAddressResponseDto Address { get; set; }

        public DoctorResponseDto(DoctorResponseBase doctor, DoctorAddressResponseDto address)
        {
            Doctor = doctor;
            Address = address;
        }
    }
}