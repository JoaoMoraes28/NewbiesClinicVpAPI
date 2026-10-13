using ClinicVp.DataBase.Models.Enums;
using ClinicVp.DTOs.DoctorAddressDto;

namespace ClinicVp.DTOs.DoctorDto
{
    public class DoctorWriteDto
    {
        public DoctorBase Doctor { get; set; }

        public DoctorAddressWriteDto Address { get; set; }

        public DoctorWriteDto(DoctorBase doctor, DoctorAddressWriteDto address)
        {
            Doctor = doctor;
            Address = address;
        }
    }

    public class DoctorBase
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public EGender Gender { get; set; }
        public string Phone { get; set; }
        public string? Photo { get; set; }
        public string Crm { get; set; }
        public int CrmUfId { get; set; }
        public EStatusEmployee Status { get; set; }
        public string? Bio { get; set; }

        public DoctorBase(string name, string cpf, string email, EGender gender, string phone, string? photo, string crm, int crmUfId, EStatusEmployee status, string? bio)
        {
            Name = name;
            Cpf = cpf;
            Email = email;
            Gender = gender;
            Phone = phone;
            Photo = photo;
            Crm = crm;
            CrmUfId = crmUfId;
            Status = status;
            Bio = bio;
        }
    }
}