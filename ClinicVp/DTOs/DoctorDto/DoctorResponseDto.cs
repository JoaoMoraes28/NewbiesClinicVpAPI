using System;
using ClinicVp.DataBase.Models.Enums;

namespace ClinicVp.DTOs.DoctorDto
{
    public class DoctorResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Crm { get; set; }
        public int CrmUfId { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string? Photo { get; set; }
        public EGender Gender { get; set; }
        public EStatusEmployee Status { get; set; }
        public string? Bio { get; set; }
        public DateOnly AdmissionDate { get; set; }

        public DoctorResponseBase(int id, string name, string crm, int crmUfId, string cpf, string email, string phone, string? photo, EGender gender, EStatusEmployee status, string? bio, DateOnly admissionDate)
        {
            Id = id;
            Name = name;
            Crm = crm;
            CrmUfId = crmUfId;
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

        public DoctorResponseDto(DoctorResponseBase doctor)
        {
            Doctor = doctor;
        }
    }
}