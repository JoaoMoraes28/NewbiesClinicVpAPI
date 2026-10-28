using ClinicVp.DataBase.DTOs.PatientAddress;
using ClinicVp.DataBase.Models.Enums;


namespace ClinicVp.DTOs.PatientDto
{

    public class PatientResponseBase
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string? Photo { get; set; }
        public string? PhoneEmergency { get; set; }
        public int? Height { get; set; }
        public decimal? Weight { get; set; }
        public EBloodType? BloodType { get; set; }
        public string? Professional { get; set; }
        public ECivilState CivilState { get; set; }
        public EGender Gender { get; set; }
        public DateOnly BornDate { get; set; }
        public bool Active { get; set; }
        public string? Notes { get; set; }

        public PatientResponseBase(int id, string name, string cpf, string email, string phone, string? professional, DateOnly bornDate, bool active, string? phoneEmergency,
            int? height, decimal? weight, EBloodType? bloodType, ECivilState civilState, EGender gender, string? notes, string? photo)
        {
            Id = id;
            Name = name;
            Cpf = cpf;
            Email = email;
            Phone = phone;
            Professional = professional;
            BornDate = bornDate;
            Active = active;
            PhoneEmergency = phoneEmergency;
            Height = height;
            Weight = weight;
            BloodType = bloodType;
            CivilState = civilState;
            Gender = gender;
            Notes = notes;
            Photo = photo;
        }
    }

    public class PatientResponseDto
    {
        public PatientResponseBase Patient { get; set; }
        public PatientAddressResponseDto Address { get; set; }
        public PatientResponseDto(PatientResponseBase patient, PatientAddressResponseDto address)
        {
            Patient = patient;
            Address = address;
        }
    }

    public class PatientResponsePreviewDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Photo { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }

        public PatientResponsePreviewDto(int id, string name, string? photo, string cpf, string phone)
        {
            Id = id;
            Name = name;
            Photo = photo;
            Cpf = cpf;
            Phone = phone;
        }
    }
}